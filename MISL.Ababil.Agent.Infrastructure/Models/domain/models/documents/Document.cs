using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.documents
{
    public class Document
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public DocumentInformation documentInformation { get; set; }
        public byte[] documentData { get; set; }
        public string fileName { get; set; }

        //public long getId() {
        //    return id;
        //}
        //public void setId(long id) {
        //    this.id = id;
        //}
        //public DocumentInformation getDocumentInformation() {
        //    return documentInformation;
        //}
        //public void setDocumentInformation(DocumentInformation documentInformation) {
        //    this.documentInformation = documentInformation;
        //}
        //public byte[] getDocumentData() {
        //    return documentData;
        //}
        //public void setDocumentData(byte[] documentData) {
        //    this.documentData = documentData;
        //}
        //public string getFileName() {
        //    return fileName;
        //}
        //public void setFileName(string fileName) {
        //    this.fileName = fileName;
        //}

    }
}
