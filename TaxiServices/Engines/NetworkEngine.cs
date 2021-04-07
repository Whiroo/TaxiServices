using System;
using System.IO;
using System.Net.Http;
using TaxiServices.Classes;

namespace TaxiServices.Engines
{
    /// <summary>
    /// Класс для работы с удаленным сервером, используется для отправки статистики по заказам и комиссиям
    /// </summary>
    class NetworkEngine
    {

        /// <summary>
        /// Загружаем файл статистики на сервер
        /// </summary>
        public static async void UploadStatisticFileAsync()
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

        /// <summary>
        /// Делаем пост запрос на проверку ключа, только при первом запуске
        /// </summary>
        /// <param name="key">Идентификатор пользователя</param>
        public static async void SendKeyToServerAsync(string key)
        {
            //TODO
            //Надо доделать роут апи под команду
        }

        /// <summary>
        /// Необходимо только мне, можно вырезать
        /// </summary>
        public static async void CheckPaymentForMe()
        {
            //TODO
            //Надо доделать роут апи под команду
        }

        /// <summary>
        /// Отпрвляем файл с ошибками на сервер
        /// </summary>
        public static async void UploadLogFileAsync()
        {
            //TODO
        }
    }
}
