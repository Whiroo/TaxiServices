using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaxiServices.Settings
{
    public static class ConfigEngine
    {
        private static Config _settings;

        
        public static async void SaveSettingsAsync()
        {
            await Task.Run(() =>
            {
                var xml = new XmlSerializer(typeof(Config));
                var sw = new StreamWriter(Config.PathToSaveSettings);
                xml.Serialize(sw, _settings);
                sw.Close();
            });
        }

        public static async void LoadSettingAsync()
        {
            if (File.Exists(Config.PathToSaveSettings))
            {
                await Task.Run(() =>
                {
                    var xml = new XmlSerializer(typeof(Config));
                    var sr = new StreamReader(Config.PathToSaveSettings);
                    _settings = (Config) xml.Deserialize(sr);
                    sr.Close();
                });
            }
        }
    }
}
