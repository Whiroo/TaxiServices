using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxiServices.Classes
{
    /// <summary>
    /// Класс для работы с удаленным сервером, используется для отправки статистики по заказам и комиссиям
    /// </summary>
    class NetworkEngine
    {
        public static async void UploadStatisticFileAsync(string createfiledata)
        {
            try
            {
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                using (var fileStream = File.OpenRead(Directory.GetCurrentDirectory() + @"\Stat\" + $"{Engine.WhatsTime(true)}"))
                {
                    HttpContent fileStreamContent = new StreamContent(fileStream);

                    var filename = Path.GetFileName(Directory.GetCurrentDirectory() + @"\Stat\" + $"{Engine.WhatsTime(true)}");

                    // эмулируем <input type="file" name="upload"/>
                    formData.Add(fileStreamContent, "upload", filename);

                    // эмулируем (action="{url}" method="post")
                    var respond = await client.PostAsync(@"http://localhost:8080/upload", formData);
                    
                    // Надо добавить обработку ответа


                }
            }
            catch (Exception e)
            {
                Logger.Write(e);
            }
        }
    }
}
