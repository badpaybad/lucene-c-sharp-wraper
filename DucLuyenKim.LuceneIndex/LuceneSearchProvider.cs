using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;

namespace DucLuyenKim.LuceneIndex
{
    public class LuceneSearchProvider
    {
        private static string _rootIndexFolder = string.Empty;
        static object _writeLock = new object();
        public static string RootIndexFolder
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(_rootIndexFolder))
                        _rootIndexFolder = HttpContext.Current.Server.MapPath("~/App_Data/Index");

                    return _rootIndexFolder;
                }
                catch
                {
                    if (string.IsNullOrEmpty(_rootIndexFolder))
                        _rootIndexFolder = AppDomain.CurrentDomain.BaseDirectory.Trim(new[] { '/', '\\' }) + "\\Indexed";

                    return _rootIndexFolder;
                }
            }
        }

        private static string[] specialString = new string[] { "\\", "+", "-", "&&", "||", "!", "(", ")", "{", "}", "[", "]", "^", "\"", "~", "*", "?", ":" };


        private static FSDirectory _directoryTemp;

        private static FSDirectory _directory
        {
            get
            {

                if (_directoryTemp == null)
                {
                    if (!System.IO.Directory.Exists(RootIndexFolder))
                    {
                        System.IO.Directory.CreateDirectory(RootIndexFolder);
                    }
                    _directoryTemp = FSDirectory.Open(new DirectoryInfo(RootIndexFolder));

                    AddOrUpdateToIndex(new AbstractDocument()
                    {
                        Lucene_ObjectId = "http://badpaybad.info",
                        Lucene_ObjectType = "http://badpaybad.info"
                    });
                }
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                var lockFilePath = RootIndexFolder.Trim(new[] { '/', '\\' }) + "\\write.lock";
                if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                return _directoryTemp;


            }
        }

        static LuceneSearchProvider()
        {

        }

        #region add or remove item for index
        public static void RemoveIndexed(AbstractDocument doc)
        {
            if (doc == null) return;
            RemoveIndexed(doc.Lucene_ObjectType, doc.Lucene_ObjectId);
        }

        public static void RemoveIndexed(string objType, string objId)
        {
            objType = NormalizeKeywords(objType);
            objId = NormalizeKeywords(objId);
            //Query qObjId = new TermQuery(new Term("Lucene_ObjectId", objId));
            //Query qObjType = new TermQuery(new Term("Lucene_ObjectType", objType));
            //BooleanQuery qMerger = new BooleanQuery();
            //qMerger.Add(qObjId, Occur.SHOULD);
            //qMerger.Add(qObjType, Occur.SHOULD);
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//
            var ptemp = new QueryParser(Version.LUCENE_30, "Lucene_ObjectId", analyzer);
            var qtemp = ptemp.Parse(string.Format("+Lucene_ObjectId:\"{0}\"+Lucene_ObjectType:\"{1}\"", objId, objType));

            //try
            //{
            //    var searcher = new IndexSearcher(_directory, false);
            //    var hitsLimit = searcher.MaxDoc;
            //    var hits = searcher.Search(qtemp, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
            //    searcher.Dispose();

            //    IndexReader reader = IndexReader.Open(_directory, false);
            //    foreach (var hit in hits)
            //    {
            //        reader.DeleteDocument(hit.Doc);
            //    }
            //    reader.Dispose();
            //}
            //catch
            //{
            //    //if folder indexed have no segment* file
            //}

            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                writer.DeleteDocuments(qtemp);
                writer.Commit();

                writer.Optimize();
                writer.Dispose();
            }
            analyzer.Close();

        }

        public static void AddOrUpdateToIndex(AbstractDocument doc)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//

            RemoveIndexed(doc);

            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                writer.AddDocument(doc.ToLuceneDocument());
                writer.Optimize();
                analyzer.Close();
                writer.Dispose();
            }
        }

        /// <summary>
        /// Lucene_ObjectType: key
        /// Lucene_ObjectId: value
        /// </summary>
        /// <param name="objTypeAndId"></param>
        public static void RemoveIndexed(List<KeyValuePair<string, string>> objTypeAndId)
        {
            var qDeleteDocs = new BooleanQuery();
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//

            foreach (var doc in objTypeAndId)
            {
                // RemoveIndexed(doc);
                var objType = NormalizeKeywords(doc.Key);
                var objId = NormalizeKeywords(doc.Value);

                //Query qObjId = new TermQuery(new Term("Lucene_ObjectId", objId));
                //Query qObjType = new TermQuery(new Term("Lucene_ObjectType", objType));
                //BooleanQuery qMerger = new BooleanQuery();
                //qMerger.Add(qObjId, Occur.SHOULD);
                //qMerger.Add(qObjType, Occur.MUST);


                var ptemp = new QueryParser(Version.LUCENE_30, "Lucene_ObjectId", analyzer);
                var qtemp = ptemp.Parse(string.Format("+Lucene_ObjectId:\"{0}\"+Lucene_ObjectType:\"{1}\"", objId, objType));


                qDeleteDocs.Add(qtemp, Occur.SHOULD);
            }
            //try
            //{
            //    var searcher = new IndexSearcher(_directory, false);
            //    var hitsLimit = searcher.MaxDoc;
            //    var hits = searcher.Search(qDeleteDocs, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
            //    searcher.Dispose();

            //    IndexReader reader = IndexReader.Open(_directory, false);
            //    foreach (var hit in hits)
            //    {
            //        reader.DeleteDocument(hit.Doc);
            //    }
            //    reader.Dispose();
            //}
            //catch
            //{
            //    //if folder indexed have no segment* file
            //}
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                writer.DeleteDocuments(qDeleteDocs);
                writer.Commit();

                writer.Optimize();
                writer.Dispose();
            }
            analyzer.Close();

        }

        public static void RemoveIndexed(List<AbstractDocument> docs)
        {
            var keyVals = docs.Select(i => new KeyValuePair<string, string>(i.Lucene_ObjectType, i.Lucene_ObjectId)).ToList();
            RemoveIndexed(keyVals);
        }

        public static void AddOrUpdateToIndex(List<AbstractDocument> docs)
        {
            RemoveIndexed(docs);

            var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//

            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                foreach (var doc in docs)
                {
                    writer.AddDocument(doc.ToLuceneDocument());
                }
                writer.Optimize();
                analyzer.Close();
                writer.Dispose();
            }
        }

        public static void Optimize()
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                analyzer.Close();
                writer.Optimize();
                writer.Dispose();
            }
        }

        public static bool RemoveAllIndexed()
        {
            try
            {
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//
                using (var writer = new IndexWriter(_directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    writer.DeleteAll();
                    analyzer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="query">http://lucene.apache.org/core/2_9_4/queryparsersyntax.html#Wildcard%20Searches</param>
        ///// <returns></returns>
        //public static List<AbstractDocument> Search(Query query)
        //{

        //    var results = new List<AbstractDocument>();
        //    // set up lucene searcher
        //    using (var searcher = new IndexSearcher(_directory, false))
        //    {
        //        var hitsLimit = 1000;
        //        var analyzer = new StandardAnalyzer(Version.LUCENE_30);

        //        var hits = searcher.Search(query, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;

        //        results = hits.Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

        //        analyzer.Close();
        //        searcher.Dispose();

        //    }
        //    return results;
        //}

        public static List<AbstractDocument> Search(string objectType, out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            totalRecords = 0;
            if (string.IsNullOrEmpty(objectType))
            {
                return new List<AbstractDocument>();
            }
            var results = new List<AbstractDocument>();
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hitsLimit = searcher.MaxDoc;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//

                var parser = new QueryParser(Version.LUCENE_30, "Lucene_ObjectType", analyzer);
                var query = parser.Parse(string.Format("Lucene_ObjectType:\"{0}\"", objectType));

                var hits = searcher.Search(query, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                totalRecords = hits.LongCount();
                results = hits.Skip(skip).Take(take).Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

                analyzer.Close();
                searcher.Dispose();
            }
            return results;
        }

        public static List<AbstractDocument> Search(string objectType, string field, string keywords, out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            totalRecords = 0;
            if (string.IsNullOrEmpty(objectType) || string.IsNullOrEmpty(field))
            {
                return new List<AbstractDocument>();
            }
            keywords = NormalizeKeywords(keywords);

            var results = new List<AbstractDocument>();
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hitsLimit = searcher.MaxDoc;
                var analyzer = new KeywordAnalyzer();//new StandardAnalyzer(Version.LUCENE_30);

                var parser = new QueryParser(Version.LUCENE_30, "Lucene_ObjectType", analyzer);
                var query = parser.Parse(string.Format("Lucene_ObjectType:\"{0}\"", objectType));

                if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(keywords))
                {
                    query = parser.Parse(string.Format("+Lucene_ObjectType:\"{0}\"+{1}:\"{2}\"", objectType,field,keywords));
                }
                
                var hits = searcher.Search(query, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                totalRecords = hits.LongCount();
                results = hits.Skip(skip).Take(take).Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

                analyzer.Close();
                searcher.Dispose();
            }
            return results;
        }

        public static List<AbstractDocument> Search(string objectType, string[] fields, string keywords, out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            totalRecords = 0;
            if (string.IsNullOrEmpty(objectType) || fields == null || fields.Length == 0)
            {
                return new List<AbstractDocument>();
            }
            keywords = NormalizeKeywords(keywords);

            var results = new List<AbstractDocument>();

            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hitsLimit = searcher.MaxDoc;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//

                var objTypeParse = new QueryParser(Version.LUCENE_30, "Lucene_ObjectType", analyzer);
                var objTypeQuery = objTypeParse.Parse(string.Format("Lucene_ObjectType:\"{0}\"", objectType));

                var groupFieldQuery = new BooleanQuery();
                foreach (var f in fields)
                {
                    var tempParse = new QueryParser(Version.LUCENE_30, f, analyzer);
                    var tempQuery = tempParse.Parse(string.Format("{0}:\"{1}\"", f, keywords));
                    groupFieldQuery.Add(tempQuery, Occur.SHOULD);

                   // groupFieldQuery.Add(new WildcardQuery(new Term(f, keywords + "*")), Occur.SHOULD);
                }

                var finalQuery = new BooleanQuery();
                finalQuery.Add(objTypeQuery, Occur.MUST);
                finalQuery.Add(groupFieldQuery, Occur.MUST);

                var hits = searcher.Search(finalQuery, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                totalRecords = hits.LongCount();
                results = hits.Skip(skip).Take(take).Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

                analyzer.Close();
                searcher.Dispose();
            }
            return results;
        }

        public static List<AbstractDocument> Search(string field, string keywords, out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            totalRecords = 0;
            if (string.IsNullOrEmpty(field))
            {
                return new List<AbstractDocument>();
            }
            keywords = NormalizeKeywords(keywords);

            var results = new List<AbstractDocument>();
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hitsLimit = searcher.MaxDoc;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//

                var parser = new QueryParser(Version.LUCENE_30, field, analyzer);
                var query = parser.Parse(string.Format("{0}:\"{1}\"", field, keywords));

                var groupFiledQuery = new BooleanQuery();

               // groupFiledQuery.Add(new WildcardQuery(new Term(field, keywords+"*")), Occur.SHOULD);
                groupFiledQuery.Add(query, Occur.SHOULD);

                var hits = searcher.Search(groupFiledQuery, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                totalRecords = hits.LongCount();
                results = hits.Skip(skip).Take(take).Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

                analyzer.Close();
                searcher.Dispose();
            }
            return results;
        }

        public static List<AbstractDocument> Search(string[] fields, string keywords, out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            totalRecords = 0;
            if (fields == null || fields.Length == 0)
            {
                return new List<AbstractDocument>();
            }
            keywords = NormalizeKeywords(keywords);
            
            var results = new List<AbstractDocument>();
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hitsLimit = searcher.MaxDoc;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//

                var groupFieldQuery = new BooleanQuery();
                foreach (var f in fields)
                {
                    var tempParse = new QueryParser(Version.LUCENE_30, f, analyzer);
                    var tempQuery = tempParse.Parse(string.Format("{0}:\"{1}\"", f, keywords));

                    groupFieldQuery.Add(tempQuery, Occur.SHOULD);

                    //groupFieldQuery.Add(new WildcardQuery(new Term(f, keywords + "*")), Occur.SHOULD);
                }

                var finalQuery = groupFieldQuery;// new BooleanQuery();
               // finalQuery.Add(groupFieldQuery, Occur.MUST);

                var hits = searcher.Search(finalQuery, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                totalRecords = hits.LongCount();
                results = hits.Skip(skip).Take(take).Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

                analyzer.Close();
                searcher.Dispose();
            }
            return results;
        }

        public static List<AbstractDocument> SearchByAllFields(string keywords, out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            totalRecords = 0;
            if (string.IsNullOrEmpty(keywords))
            {
                return new List<AbstractDocument>();
            }
            var results = new List<AbstractDocument>();
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hitsLimit = searcher.MaxDoc;
                var analyzer = new KeywordAnalyzer();//new StandardAnalyzer(Version.LUCENE_30);

                var fields = searcher.IndexReader.GetFieldNames(IndexReader.FieldOption.ALL);

                var groupFieldQuery = new BooleanQuery();
                var listFields = fields.ToList();
                foreach (string f in listFields)
                {
                    var ptemp = new QueryParser(Version.LUCENE_30, f, analyzer);

                    var qtemp = ptemp.Parse(string.Format("{0}:\"{1}\"", f, keywords));
                    groupFieldQuery.Add(qtemp, Occur.SHOULD);

                    //groupFieldQuery.Add(new WildcardQuery(new Term(f, keywords + "*")), Occur.SHOULD);
                }

                var finalQuery = groupFieldQuery;// new BooleanQuery();
                //finalQuery.Add(groupFiledQuery, Occur.MUST);

                var hits = searcher.Search(finalQuery, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                totalRecords = hits.LongCount();
                results = hits.Skip(skip).Take(take).Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

                analyzer.Close();
                searcher.Dispose();
            }
            return results;
        }

        public static List<AbstractDocument> SearchByAllFields(string objectType, string keywords, out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            totalRecords = 0;
            if (string.IsNullOrEmpty(keywords))
            {
                return new List<AbstractDocument>();
            }
            var results = new List<AbstractDocument>();
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hitsLimit = searcher.MaxDoc;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//
                var fields = searcher.IndexReader.GetFieldNames(IndexReader.FieldOption.ALL);

                var paserObjType = new QueryParser(Version.LUCENE_30, "Lucene_ObjectType", analyzer);
                var queryObjType = paserObjType.Parse(string.Format("Lucene_ObjectType:\"{0}\"", objectType));

                var gquery = new BooleanQuery();
                var list = fields.ToList();
                foreach (string f in list)
                {
                    var ptemp = new QueryParser(Version.LUCENE_30, f, analyzer);
                    var qtemp = ptemp.Parse(string.Format("{0}:\"{1}\"", f, keywords));
                    gquery.Add(qtemp, Occur.SHOULD);

                   // gquery.Add(new WildcardQuery(new Term(f, keywords + "*")), Occur.SHOULD);
                }

                var finalQuery = new BooleanQuery();
                finalQuery.Add(queryObjType, Occur.MUST);
                finalQuery.Add(gquery, Occur.MUST);

                var hits = searcher.Search(finalQuery, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                totalRecords = hits.LongCount();
                results = hits.Skip(skip).Take(take).Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

                analyzer.Close();
                searcher.Dispose();
            }
            return results;
        }

        public static List<AbstractDocument> GetAllIndexedRecords(out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            List<AbstractDocument> result = new List<AbstractDocument>();
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hits = searcher.Search(new MatchAllDocsQuery(), searcher.MaxDoc).ScoreDocs;
                totalRecords = hits.LongCount();
                result =
                    hits.Skip(skip)
                        .Take(take)
                        .Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc)))
                        .ToList();
                searcher.Dispose();
            }
            return result;
        }

        /// <summary>
        /// http://lucene.apache.org/core/2_9_4/queryparsersyntax.html#Wildcard%20Searches
        /// </summary>
        /// <param name="fieldDefault"></param>
        /// <param name="query">http://lucene.apache.org/core/2_9_4/queryparsersyntax.html#Wildcard%20Searches</param>
        /// <param name="totalRecords"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static List<AbstractDocument> TestQuery(string fieldDefault, string query, out long totalRecords, int skip = 0, int take = int.MaxValue)
        {
            totalRecords = 0;
            if (string.IsNullOrEmpty(query))
            {
                return new List<AbstractDocument>();
            }
            if (string.IsNullOrEmpty(fieldDefault))
            {
                fieldDefault = "Lucene_ObjectId";
            }
            var results = new List<AbstractDocument>();
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hitsLimit = searcher.MaxDoc;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);//new KeywordAnalyzer();//

                var ptemp = new QueryParser(Version.LUCENE_30, fieldDefault, analyzer);
                var qtemp = ptemp.Parse(query);

                var hits = searcher.Search(qtemp, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                totalRecords = hits.LongCount();
                results = hits.Skip(skip).Take(take).Select(i => new AbstractDocument().BuildAbstactDocument(searcher.Doc(i.Doc))).ToList();

                analyzer.Close();
                searcher.Dispose();

            }
            return results;
        }

        public static string NormalizeKeywords(string keywords)
        {
            keywords = keywords ?? string.Empty;
            keywords = keywords.Trim();
            foreach (var s in specialString)
            {
                keywords = keywords.Replace(s, "\\" + s);
            }
            return keywords;
        }

    }
}