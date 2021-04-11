using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServices
{
    /// <summary>
    /// Класс для настройки параметров комиссии, хоста сервера или токена tgbot'a
    /// </summary>
    public class  Config
    {
        
        //Путь до файла с настройками
        public  string PathToSaveSettings = Environment.CurrentDirectory + @"\Lib" + "\\settings.xml";

        public  int Commission = 20; // Дефолтное значение

        // Адрес сервера, куда будем отправлять статистику
        public  string ServerURL = "localhost:8080";

        // Токен Телеграмм бота, используется с/вместо api сервера
        public  string TelegramBotToken = "";

        // Пароль, для получения доступа к панели разработчика
        public  string DevPassword = "whiroo";

        // Проверяем, куда будем отправлять данные
        public bool UseServer = true;

        // Аналогично вышеуказанного
        public bool UseTelegram = false;

        public bool IsFirstStart = true;

        public string UserId = "";


    }
}
