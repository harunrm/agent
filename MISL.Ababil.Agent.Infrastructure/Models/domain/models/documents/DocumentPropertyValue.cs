using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documents;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documents.definition;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.documents
{
    public class DocumentPropertyValue
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public DocumentPropertyDefinition propertyDefinition { get; set; }
        public string value { get; set; }

        //public long getId() {
        //    return id;
        //}

        //public void setId(long id) {
        //    this.id = id;
        //}

        //public DocumentPropertyDefinition getPropertyDefinition() {
        //    return propertyDefinition;
        //}

        //public void setPropertyDefinition(
        //        DocumentPropertyDefinition propertyDefinition) {
        //    this.propertyDefinition = propertyDefinition;
        //}

        //public string getValue() {
        //    return value;
        //}

        //public void setValue(string value) {
        //    this.value = value;
        //}

    }
}
