using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace MISL.Ababil.Agent.LocalStorageService
{
    public class LocalStorageIO
    {
        public bool Reset()
        {
            try
            {
                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ababil Cache");
                Directory.Delete(folder, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadJsonToLocalStorage(string key, out string json)
        {
            json = "";
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ababil Cache");
            if (!Directory.Exists(folder))
            {
                json = null;
                return false;
            }
            key = Path.Combine(folder, key);
            if (!File.Exists(key))
            {
                json = null;
                return false;
            }
            StreamReader streamReader = new StreamReader(key, Encoding.Unicode);
            {
                json = streamReader.ReadToEnd();
            }
            streamReader.Close();
            return true;
        }

        public void SaveJsonToLocalStorage(string key, ref string json)
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ababil Cache");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            key = Path.Combine(folder, key);
            StreamWriter sw = new StreamWriter(key, false, Encoding.Unicode);
            {
                sw.Write(json);
            }
            sw.Close();
        }

        public void SaveObjectToLocalStorage(object objectToCache, string key)
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ababil Cache");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string cacheFileName = Path.Combine(folder, key);
            StreamWriter sw = new StreamWriter(cacheFileName, false, Encoding.Unicode);
            {
                string json = JsonConvert.SerializeObject(objectToCache);
                sw.Write(json);
            }
            sw.Close();
        }
    }
}