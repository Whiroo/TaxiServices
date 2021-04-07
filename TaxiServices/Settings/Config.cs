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
        public static string PathToSaveSettings = Environment.CurrentDirectory + "\\settings.xml\\";

        public static int Commission = 20; // Дефолтное значение

        // Адрес сервера, куда будем отправлять статистику
        public static string ServerURL = "localhost:8080";

        // Токен Телеграмм бота, используется с/вместо api сервера
        public static string TelegramBotToken = "";

        // Пароль, для получения доступа к панели разработчика
        public static string DevPassword = "whiroo";

        // Проверяем, куда будем отправлять данные
        public static bool UseServer = true;

        // Аналогично вышеуказанного
        public static bool UseTelegram = false;

        public static bool IsFirstStart = true;

        public static string UserId = "";


    }
}
