using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaxiServices.Settings
{
    public class ConfigEngine
    {
        public Config settings;

        public ConfigEngine()
        {
            settings = new Config();
        }

        
        public async void SaveSettingsAsync(Config cfg)
        {
            await Task.Run(() =>
            {
                var xml = new XmlSerializer(typeof(Config));
                var sw = new StreamWriter(settings.PathToSaveSettings);
                xml.Serialize(sw, cfg);
                sw.Close();
            });
        }

        public async void LoadSettingAsync()
        {
            if (File.Exists(settings.PathToSaveSettings))
            {
                await Task.Run(() =>
                {
                    var xml = new XmlSerializer(typeof(Config));
                    var sr = new StreamReader(settings.PathToSaveSettings);
                    settings = (Config) xml.Deserialize(sr);
                    sr.Close();
                });
            }
        }
    }
}
