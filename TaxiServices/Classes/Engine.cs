using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using TaxiServices.Classes;

namespace TaxiServices
{
    /// <summary>
    ///     Основные методы
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
        ///     Добавление в очередь
        /// </summary>
        /// <param name="driver">Водитель</param>
        /// <param name="city">True = Водитель в городской очереди, False = Водитель в очереди на поселке</param>
        public static void AddDriverToQueue(Driver driver, bool city)
        {
            if (city == false)
                Drivers.Enqueue(driver);
            else
                CityDrivers.Enqueue(driver);
        }

        /// <summary>
        ///     Удаление с очереди
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
        ///     Обновление datagrida, скорее костыль
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
                MessageBox.Show("Не удалось посчитать количество заказов и коммиссию");
                throw;
            }
        }

        public static void SaveOldData(List<Commission> data)
        {
            var json = new JsonSerializer();

            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\old"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\old");
            else
                using (var fs =
                    new FileStream(Directory.GetCurrentDirectory() + @"\old\" + $"{DateTime.Now:d}",
                        FileMode.OpenOrCreate))
                {
                    var jsondata = JsonConvert.SerializeObject(data);
                    var arrayData = Encoding.UTF8.GetBytes(jsondata);
                    fs.Write(arrayData, 0, arrayData.Length);
                }
        }

        public static bool WhatsTime(string time)
        {
            if (time != _nowTime.ToString("t")) return false;
            MessageBox.Show("Yes");
            return true;
        }

        // Ужасно, надо переделать.
        public static async void ResetCommissionsAsync(List<Driver> data)
        {
            await Task.Run(() =>
            {
                foreach (var driver in data.Where(driver => driver.Orders != 0)) driver.Orders = 0;
            });
        }
    }
}
