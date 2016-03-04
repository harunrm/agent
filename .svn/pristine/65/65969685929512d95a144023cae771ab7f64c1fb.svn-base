using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace MISL.Ababil.Agent.Communication
{
    public class DocumentCom
    {
        public string saveDocumentList(string jsonString)
        {
            WebClient client = new WebClient();
            try
            {

                string path = SessionInfo.rootServiceUrl + "resources/document/save";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(typeof(String));
                    //    responseString = ser.ReadObject(ms) as String;
                    //}

                    return responseString;

                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }


            //string responseString = "";
            //string path = SessionInfo.rootServiceUrl + "resources/document/save";
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    responseString = JsonCom.postJsonForValue(reqparm, path, jsonString);
            //    // responseString = JsonCom.postJsonString(connHeaders, reqparm, path, jsonString);
            //}
            //catch (Exception ex)
            //{
            //    responseString = ex.Message;
            //}
            //if (responseString == "OK")
            //{
            //    return "Document saved successfully";
            //}
            //else if (responseString == "NotFound")
            //{
            //    return "Document save failed";
            //}
            //else
            //    return responseString;
        }

        public byte[] getDocFileByID(long id)
        {
            byte[] Data = null;
            string path = SessionInfo.rootServiceUrl + "resources/document/file/" + id;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as Document;
                    //}
                    Data = JsonConvert.DeserializeObject<byte[]>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<Document> getDocumentList(string docName)
        {
            List<Document> Data = new List<Document>();
            string path = SessionInfo.rootServiceUrl + "resources/document/name/" + docName;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as List<Document>;
                    //}
                    Data = JsonConvert.DeserializeObject<List<Document>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public DocumentInfo getDocumentListById(string docId)
        {
            DocumentInfo Data = new DocumentInfo();
            string path = SessionInfo.rootServiceUrl + "resources/document/info/" + docId;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as List<Document>;
                    //}
                    Data = JsonConvert.DeserializeObject<DocumentInfo>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public List<DocumentType> getDocumentTypeList()
        {
            List<DocumentType> Data = new List<DocumentType>();
            string path = SessionInfo.rootServiceUrl + "resources/document/type";
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as List<Document>;
                    //}
                    Data = JsonConvert.DeserializeObject<List<DocumentType>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public Document getDocumentFile(string docId)
        {
            Document Data = new Document();
            string path = SessionInfo.rootServiceUrl + "resources/document/docdata/" + docId;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as Document;
                    //}
                    Data = JsonConvert.DeserializeObject<Document>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public Document deleteDocumentById(string docId)
        {
            Document Data = new Document();
            string path = SessionInfo.rootServiceUrl + "resources/document/delete/" + docId;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as Document;
                    //}
                    Data = JsonConvert.DeserializeObject<Document>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }


    }
}
