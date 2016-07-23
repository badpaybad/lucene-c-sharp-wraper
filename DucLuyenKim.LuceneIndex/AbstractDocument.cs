using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Lucene.Net.Documents;

namespace DucLuyenKim.LuceneIndex
{
    [Serializable]
    public class AbstractDocument
    {
        private string _luceneObjectType = string.Empty;
        private string _luceneObjectId = string.Empty;
        private string _luceneObjectSortField = string.Empty;
        private string _luceneObjectSortValue = string.Empty;
        private string _luceneObjectByJson = string.Empty;
        private Dictionary<string, string> _propertyNameAndValue = new Dictionary<string, string>();
        private string _luceneObjectByXml = string.Empty;

        public string Lucene_ObjectByXml
        {
            get { return _luceneObjectByXml; }
            set { _luceneObjectByXml = value; }
        }

        public string Lucene_ObjectType
        {
            get { return _luceneObjectType; }
            set { _luceneObjectType = value; }
        }

        public string Lucene_ObjectId
        {
            get { return _luceneObjectId; }
            set { _luceneObjectId = value; }
        }

        public string Lucene_ObjectSortField
        {
            get
            {
                if (string.IsNullOrEmpty(_luceneObjectSortField)) return "Lucene_ObjectId";
                return _luceneObjectSortField;
            }
            set { _luceneObjectSortField = value; }
        }

        public string Lucene_ObjectSortValue
        {
            get { return _luceneObjectSortValue; }
            set { _luceneObjectSortValue = value; }
        }

        public string Lucene_ObjectByJson
        {
            get { return _luceneObjectByJson; }
            set { _luceneObjectByJson = value; }
        }

        public Dictionary<string, string> PropertyNameAndValue
        {
            get { return _propertyNameAndValue; }
            set { _propertyNameAndValue = value; }
        }

        public AbstractDocument()
        {
        }

        public Document ToLuceneDocument()
        {
            Document doc = new Document();
            doc.Add(new Field("Lucene_ObjectId", this.Lucene_ObjectId ?? "", Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Lucene_ObjectType", this.Lucene_ObjectType ?? "", Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Lucene_ObjectSortField", string.IsNullOrEmpty(this.Lucene_ObjectSortField) ? "Lucene_ObjectId" : this.Lucene_ObjectSortField, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Lucene_ObjectSortValue", string.IsNullOrEmpty(this.Lucene_ObjectSortValue) ? (this.Lucene_ObjectId ?? "") : this.Lucene_ObjectSortValue, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Lucene_ObjectByJson", this.Lucene_ObjectByJson ?? "", Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Lucene_ObjectByXml", this.Lucene_ObjectByJson ?? "", Field.Store.YES, Field.Index.ANALYZED));

            if (PropertyNameAndValue != null && PropertyNameAndValue.Count > 0)
            {
                foreach (var p in PropertyNameAndValue)
                {
                    doc.Add(new Field(p.Key, p.Value, Field.Store.YES, Field.Index.ANALYZED));
                }
            }

            return doc;
        }

        public AbstractDocument BuildAbstactDocument(Document luceneDoc)
        {
            this.Lucene_ObjectId = luceneDoc.Get("Lucene_ObjectId");
            this.Lucene_ObjectType = luceneDoc.Get("Lucene_ObjectType");
            this.Lucene_ObjectSortValue = luceneDoc.Get("Lucene_ObjectSortValue");
            this.Lucene_ObjectSortField = luceneDoc.Get("Lucene_ObjectSortField");
            this.Lucene_ObjectByJson = luceneDoc.Get("Lucene_ObjectByJson");
            this.Lucene_ObjectByXml = luceneDoc.Get("Lucene_ObjectByXml");
            this.PropertyNameAndValue = new Dictionary<string, string>();
            var fils = luceneDoc.GetFields();
            foreach (var f in fils)
            {
                if (!f.Equals("Lucene_ObjectId") && !f.Equals("Lucene_ObjectType") && !f.Equals("Lucene_ObjectSortValue") && !f.Equals("Lucene_ObjectSortField"))
                {
                    if (!this.PropertyNameAndValue.ContainsKey(f.Name))
                    {
                        this.PropertyNameAndValue.Add(f.Name, f.StringValue);
                    }
                }
            }
            return this;
        }

        //public T BuildFromJson<T>()
        //{
        //    if (string.IsNullOrEmpty(Lucene_ObjectByJson)) return default(T);

        //    return new JavaScriptSerializer().Deserialize<T>(Lucene_ObjectByJson);
        //}

        //public T BuildFromXml<T>()
        //{
        //    if (string.IsNullOrEmpty(this.Lucene_ObjectByXml)) return default(T);
        //    XmlSerializer deserializer = new XmlSerializer(typeof(T));
        //    object obj = deserializer.Deserialize(new XmlTextReader(new StringReader(this.Lucene_ObjectByXml)));

        //    return (T)obj;
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[[{0}:{1}]]\r\n", "Lucene_ObjectId", this.Lucene_ObjectId);
            sb.AppendFormat("[[{0}:{1}]]\r\n", "Lucene_ObjectType", this.Lucene_ObjectType);
            sb.AppendFormat("[[{0}:{1}]]\r\n", "Lucene_ObjectSortField", this.Lucene_ObjectSortField);
            sb.AppendFormat("[[{0}:{1}]]\r\n", "Lucene_ObjectSortValue", this.Lucene_ObjectSortValue);
            foreach (var pv in PropertyNameAndValue)
            {
                sb.AppendFormat("[[{0}:{1}]]\r\n", pv.Key, pv.Value);
            }
            return sb.ToString();
        }

        public string PlainString { get { return this.ToString(); } }
    }

    //public static class CastObject
    //{
    //    //public static string ToJson(this object obj)
    //    //{

    //    //}

    //    public static string ToXml<T>(this T obj)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(T));

    //        TextWriter xmlWriter = new StringWriter();
    //        serializer.Serialize(xmlWriter, obj);
    //        return xmlWriter.ToString();
    //    }
    //}
}