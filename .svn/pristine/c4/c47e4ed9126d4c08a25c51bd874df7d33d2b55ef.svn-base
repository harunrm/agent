using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace MISL.Ababil.Agent.Services
{
    public class DocumentServices
    {
        DocumentCom objDocumentCom = new DocumentCom();
        public string saveDocumentList(DocumentInfo documentInfo)
        {
            // var json = new JavaScriptSerializer().Serialize(documentInfo);
            var json = JsonConvert.SerializeObject(documentInfo);
            string returnMsg = objDocumentCom.saveDocumentList(json);
            return returnMsg;
        }

        public List<Document> getDocumentList(string docName)
        {
            return objDocumentCom.getDocumentList(docName);
        }

        public DocumentInfo getDocumentListById(string docId)
        {
            return objDocumentCom.getDocumentListById(docId);
        }

        public List<DocumentType> getDocumentTypeList()
        {
            return objDocumentCom.getDocumentTypeList();
        }

        public Document getDocumentFile(string docId)
        {
            return objDocumentCom.getDocumentFile(docId);
        }

        public Document deleteDocumentById(string docId)
        {
            return objDocumentCom.deleteDocumentById(docId);
        }


        public byte[] getDocFileByID(long id)
        {
            return objDocumentCom.getDocFileByID(id);
        }

        public bool isDocumentAvailable(long docId)
        {
            DocumentInfo docInfo = getDocumentListById(docId.ToString());
            if (docInfo != null)
            {
                if (docInfo.documents.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
