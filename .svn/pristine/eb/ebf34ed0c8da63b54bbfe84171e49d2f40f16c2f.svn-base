using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis
{
   public class SectorCodeInfo
    {
       public String code { get; set; }
       public String name { get; set; }
       public long sectorType { get; set; }
       [JsonIgnore]
       private string _nameWithCode;
       [JsonIgnore]
       public string NameWithCode
       {
           get
           {
               return name + " (" + code +")";
           }
           //set
           //{
           //    this._nameWithCode = name + " " + code;
           //}
       }
    }
}
