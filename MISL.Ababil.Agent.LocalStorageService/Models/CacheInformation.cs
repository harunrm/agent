using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.LocalStorageService.Models
{
    public class CacheInformation
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public string objectName { get; set; }
        public string description { get; set; }
        public string servicePath { get; set; }
        public long lastUpdateTime { get; set; }
    }
}