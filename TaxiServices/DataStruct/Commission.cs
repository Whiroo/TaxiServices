using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServices.Classes
{
    /// <summary>
    /// Класс для таблицы в БД
    /// </summary>
    public class Commission
    {
        public int ID { get; set; }
        public int DriverNumber { get; set; }
        public string DriverModel { get; set; }
        public int PerWeek { get; set; }
        public string Paid { get; set; }
    }
}
