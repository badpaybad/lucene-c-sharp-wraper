using System;
using System.Collections.Generic;
using System.Linq;
using DucLuyenKim.LuceneIndex;

namespace DucLuyenKim.LuceneTest
{
    public class SampleObjectIndexServices
    {
        
        List<SampleObject> _data = new List<SampleObject>();
        static SampleObjectIndexServices _instance = new SampleObjectIndexServices();
        public static SampleObjectIndexServices Instance { get { return _instance; } }

        private SampleObjectIndexServices()
        {

        }

        public void AddRandom()
        {
            var sample = new SampleObject();
            sample.SampleId = new Random().Next();
            sample.SampleVersion = "Version: " + sample.SampleId;
            sample.SampleDescription = "Description for version: " + sample.SampleId;
            sample.SampleNotIndexField = "No index field for version: " + sample.SampleId;
            _data.Add(sample);

            LuceneSearchProvider.AddOrUpdateToIndex(BuildIndexDocument(sample));
        }

        AbstractDocument BuildIndexDocument(SampleObject obj)
        {
            var doc = new AbstractDocument();
            doc.Lucene_ObjectId = obj.SampleId.ToString();
            doc.Lucene_ObjectType = typeof(SampleObject).ToString();

            doc.PropertyNameAndValue.Add("SampleVersion", obj.SampleVersion);
            doc.PropertyNameAndValue.Add("SampleDescription", obj.SampleDescription);

            return doc;
        }

        SampleObject BuildFromIndexedDocument(AbstractDocument doc)
        {
            return _data.FirstOrDefault(i => i.SampleId == Convert.ToInt32(doc.Lucene_ObjectId));
        }

        public List<SampleObject> Search(string keywords)
        {
            long totalRecords;
            return LuceneSearchProvider.SearchByAllFields(typeof(SampleObject).ToString(), keywords, out totalRecords)
                .Select(i => BuildFromIndexedDocument(i)).ToList();
        }

        public List<SampleObject> SelectAll()
        {
            long totalRecords;
            return LuceneSearchProvider.Search(typeof(SampleObject).ToString(),out totalRecords)
                .Select(i => BuildFromIndexedDocument(i)).ToList();
        } 
    }
}