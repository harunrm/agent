using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt
{
   public class Document
    {
        //private long serialVersionUID = 1L;

        //public long id { get; set; }
        //public String documentName { get; set; }
        //public String documentDescription { get; set; }

        //[JsonConverter(typeof(ByteArrayConverter))]
        //public byte[] documentData { get; set; }
        //public DocumentInfo documentInformation { get; set; }

        private long serialVersionUID = 1L;

        public long id { get; set; }
        public string docNumber { get; set; }
        public string documentName { get; set; }
        public string issuePlace { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime expireDate { get; set; }
        [JsonConverter(typeof(ByteArrayConverter))]
        public byte[] documentData { get; set; }
        public DocumentType documentType { get; set; }
    }
}
