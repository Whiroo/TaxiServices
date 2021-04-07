using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaxiServices.Settings
{
    class ConfigEngine
    {
        public Config settings;

        public ConfigEngine()
        {
            settings = new Config();
        }

        public void SaveSettings()
        {
            var xml = new XmlSerializer(typeof(Config));
            var sw = new StreamWriter(Config.PathToSaveSettings);
            xml.Serialize(sw, settings);
            sw.Close();
        }

        public void LoadSetting()
        {
            if (File.Exists(Config.PathToSaveSettings))
            {
                var xml = new XmlSerializer(typeof(Config));
                var sr = new StreamReader(Config.PathToSaveSettings);
                settings = (Config) xml.Deserialize(sr);
                sr.Close();
            }
        }
    }
}
