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
    class Config
    {
        public static int Commission = 20; // Дефолтное значение

        // Адрес сервера, куда будем отправлять статистику
        public string ServerURL = "localhost:8080";

        // Токен Телеграмм бота, используется с/вместо api сервера
        public static string TelegramBotToken = "";


    }
}
