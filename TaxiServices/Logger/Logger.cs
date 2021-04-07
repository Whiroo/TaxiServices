using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServices.Classes
{
    class Logger
    {
        private static readonly object _sync = new object();

        /// <summary>
        /// Кастомный логер для удобства
        /// </summary>
        /// <param name="ex"></param>
        public static void Write(Exception ex)
        {
            try
            {
                
                var pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog); 
                var filename = Path.Combine(pathToLog,
                    $"{AppDomain.CurrentDomain.FriendlyName}_{DateTime.Now:dd.MM.yyy}.log");
                var fullText =
                    $"[{DateTime.Now:dd.MM.yyy HH:mm:ss.fff}] [{ex.TargetSite.DeclaringType}.{ex.TargetSite.Name}()] {ex.Message}\r\n";
                lock (_sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
                // Просто игнорим
            }
        }
    }
}
