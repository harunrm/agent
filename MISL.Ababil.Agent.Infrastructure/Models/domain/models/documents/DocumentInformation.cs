using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documents.definition;


namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.documents
{
    public class DocumentInformation
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public long ownerId { get; set; }
        public DocumentOwnerType documentOwnerType { get; set; }
        public DocumentType documentType { get; set; }
        public FileType fileType { get; set; }
        public Boolean isItprovided { get; set; }

       // private Set<DocumentPropertyValue> values;

        //public long getId() {
        //    return id;
        //}

        //public void setId(long id) {
        //    this.id = id;
        //}

        //public DocumentType getDocumentType() {
        //    return documentType;
        //}

        //public void setDocumentType(DocumentType documentType) {
        //    this.documentType = documentType;
        //}

        //public FileType getFileType() {
        //    return fileType;
        //}

        //public void setFileType(FileType fileType) {
        //    this.fileType = fileType;
        //}

        //public Set<DocumentPropertyValue> getValues() {
        //    return values;
        //}

        //public void setValues(Set<DocumentPropertyValue> values) {
        //    this.values = values;
        //}

        //public Boolean getIsItprovided() {
        //    return isItprovided;
        //}

        //public void setIsItprovided(Boolean isItprovided) {
        //    this.isItprovided = isItprovided;
        //}

        //public long getOwnerId() {
        //    return ownerId;
        //}

        //public void setOwnerId(long ownerId) {
        //    this.ownerId = ownerId;
        //}

        //public DocumentOwnerType getDocumentOwnerType() {
        //    return documentOwnerType;
        //}

        //public void setDocumentOwnerType(DocumentOwnerType documentOwnerType) {
        //    this.documentOwnerType = documentOwnerType;
        // }

    }
}
