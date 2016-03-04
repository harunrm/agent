using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models
{
    public class Address
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public string addressLineOne { get; set; }
        public string addressLineTwo { get; set; }
        public Thana thana { get; set; }
        public PostalCode postalCode { get; set; }
        public District district { get; set; }
        public Division division { get; set; }
        public Country country { get; set; }
        [JsonIgnore]
        public int? commonAddressIndex { get; set; }
        [JsonIgnore]
        public string commonAddressName { get; set; }
    }
}
