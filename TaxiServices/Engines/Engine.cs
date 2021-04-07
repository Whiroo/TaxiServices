using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaxiServices.Classes;

namespace TaxiServices.Engines
{
    /// <summary>
    ///  Основные методы
    /// </summary>
    internal class Engine
    {
        private static readonly Queue<Driver> Drivers = new Queue<Driver>();
        private static readonly Queue<Driver> CityDrivers = new Queue<Driver>();
        private static DateTime _nowTime = DateTime.Now;

        public static int CalcCommission(int orders)
        {
            return orders * Config.Commission;
        }

        /// <summary>
        /// Добавление в очередь
        /// </summary>
        /// <param name="driver">Водитель</param>
        /// <param name="city">True = Водитель в городской очереди, False = Водитель в очереди на поселке</param>
        public static void AddDriverToQueue(Driver driver, bool city)
        {
            try
            {
                if (city == false)
                    Drivers.Enqueue(driver);
                else
                    CityDrivers.Enqueue(driver);
            }
            catch (Exception e)
            {
                Logger.Write(e);
            }
        }

        /// <summary>
        /// Удаление с очереди
        /// </summary>
        /// <param name="driver">Водитель</param>
        /// <param name="city">True = Водитель в городской очереди, False = Водитель в очереди на поселке</param>
        public static void DeleteDriverFromQueue(Driver driver, bool city)
        {
            if (city == false)
                Drivers.Dequeue();
            else
                CityDrivers.Dequeue();
        }
        /// <summary>
        /// Удаление не первого элемента очереди
        /// </summary>
        /// <param name="driver">Водитель</param>
        /// <param name="city">В городе или нет</param>
        /// <param name="notfirst">Всегда true, если хотим удалить не первого</param>
        public static async void DeleteDriverFromQueue(Driver driver, bool city, bool notfirst)
        {
            // Быстрый костыль из говна и палок
            try
            {
                if (city == false && notfirst)
                {
                    await Task.Run(() =>
                    {
                        var temp = Drivers.ToList();
                        temp.Remove(driver);
                        Drivers.Clear();
                        foreach (var d in temp)
                        {
                            Drivers.Enqueue(d);
                        }
                    });

                }
            }
            catch (Exception e)
            {
                Logger.Write(e);
            }
        }

        /// <summary>
        /// Обновление datagrida, скорее костыль
        /// </summary>
        /// <param name="city">True = Водитель в городской очереди, False = Водитель в очереди на поселке</param>
        /// <returns></returns>
        public static List<Driver> Refresh(bool city)
        {
            return city == false ? Drivers.ToList() : CityDrivers.ToList();
        }

        public static int[] CalcAllOrderPerWeek(List<Driver> drivers)
        {

            try
            {
                var temp = new int[2];
                temp[0] = drivers.Sum(driver => driver.Orders);
                temp[1] = CalcCommission(temp[0]);
                return temp;
            }
            catch (Exception e)
            {
                Logger.Write(e);
                throw;
            }
        }

        public static async void SaveOldDataAsync(List<Commission> data)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Old"))
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Old");
                    else
                        using (var fs =
                            new FileStream(Directory.GetCurrentDirectory() + @"\Old\" + $"{DateTime.Now:d}",
                                FileMode.OpenOrCreate))
                        {
                            var jsondata = JsonConvert.SerializeObject(data);
                            var arrayData = Encoding.UTF8.GetBytes(jsondata);
                            fs.Write(arrayData, 0, arrayData.Length);
                        }
                });
            }
            catch (Exception e)
            {
                Logger.Write(e);
            }
        }
        /// <summary>
        /// Иключительно для удобства, вернет время на данный момент
        /// </summary>
        /// <param name="day">Если true, возвращает день, если false, то час</param>
        /// <returns></returns>
        public static string WhatsTime(bool day)
        {
            return _nowTime.ToString(day ? "d" : "t");
        }

        // Ужасно, надо переделать.
        public static async void ResetCommissionsAsync(List<Driver> data)
        {
            await Task.Run(() =>
            {
                foreach (var driver in data.Where(driver => driver.Orders != 0)) driver.Orders = 0;
            });

        }

        /// <summary>
        /// Запись статистики в JSON файл
        /// </summary>
        /// <param name="datatext"></param>
        public static async void WriteToFileWithTimeAsync(StatisticsData datatext)
        {
            try
            {
                
                await Task.Run(() =>
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Stat"))
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Stat");
                    else
                        using (var fs =
                            new FileStream(Directory.GetCurrentDirectory() + @"\Stat\" + $"{DateTime.Now:d}",
                                FileMode.Append))
                        {
                            var jsondata = JsonConvert.SerializeObject(datatext);
                            var arrayData = Encoding.UTF8.GetBytes(jsondata);
                            fs.Write(arrayData, 0, arrayData.Length);
                        }
                });
            }
            catch (Exception e)
            {
                Logger.Write(e);
            }
        }

        public static string GetIDUser()
        {
            Dictionary<string, string> ids;
            ids = new Dictionary<string, string>();
            ManagementObjectSearcher searcher;
            searcher = new ManagementObjectSearcher("root\\CIMV2",
                "SELECT UUID FROM Win32_ComputerSystemProduct");
            foreach (var o in searcher.Get())
            {
                var queryObj = (ManagementObject) o;
                ids.Add("UUID", queryObj["UUID"].ToString());
            }

            string id = ids.Aggregate("", (current, x) => current + x.Value);
            return id;
        }

    }
}

