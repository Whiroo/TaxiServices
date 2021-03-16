using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServices
{
    public class Driver
    {
       
        public int ID { get; set; }
        public int Number { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Orders { get; set; }
        public string Online { get; set; }
        public string Location { get; set; }

        
        public Driver(int id, string model, string color, int order)
        {
            this.ID = id;
            this.Model = model;
            this.Color = color;
            this.Orders = order;
        }
        public Driver() { }
    }
}
