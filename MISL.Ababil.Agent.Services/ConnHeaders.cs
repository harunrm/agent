using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Services
{
    public class ConnHeaders
    {
        public static string username { get; set; }
        public static string token { get; set; }
        public static string rootServiceUrl { get; set; }
    }
    public class LoggedUserRights
    {
        public static string token { get; set; }
        public static List<string> rights { get; set; }
    }
}
