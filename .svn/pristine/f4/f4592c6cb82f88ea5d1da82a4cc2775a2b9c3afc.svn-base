using System;
using System.Collections;
using System.Configuration;
using System.Net;
using MISL.Ababil.Agent.Infrastructure.Models.common;

namespace MISL.Ababil.Agent.Communication
{
    public class ConfigCom
    {
        //private const string ConfigPropertiesLocation = "http://localhost/config/config.properties";
        //private static readonly string ConfigPropertiesLocation = "http://192.168.1.223:8088/config/config.properties";
        private static readonly string ConfigPropertiesLocation = ConfigurationManager.AppSettings["servicerooturl"].ToString() + "updater/config.properties";

        private const char ConfigSeparator = '\n';
        private const char PropertySeparator = '=';
        private static string _configData = "";
        private static readonly Hashtable ConfigValues = new Hashtable();

        public static string RefreshConfigFromServer()
        {
            WebClient client = new WebClient();
            try
            {
                _configData = client.DownloadString(ConfigPropertiesLocation);
                ConfigValues.Clear();
                string[] configLines = _configData.Split(ConfigSeparator);
                foreach (string configLine in configLines)
                {
                    string[] paramValuePair = configLine.Split(PropertySeparator);
                    if (paramValuePair.GetUpperBound(0) == 1)
                        ConfigValues[paramValuePair[0]] = paramValuePair[1];
                }
            }
            catch (Exception exception)
            {
                // ignored
            }
            return _configData;
        }

        public static string GetCachedConfig()
        {
            if (string.IsNullOrEmpty(_configData))
            {
                return RefreshConfigFromServer();
            }
            return _configData;
        }

        public static string GetServerConfigParameter(string parameterName)
        {
            GetCachedConfig();
            if (ConfigValues.ContainsKey(parameterName))
            {
                return ConfigValues[parameterName].ToString();
            }
            return "";
        }

    }
}