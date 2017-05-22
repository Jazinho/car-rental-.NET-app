using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalBackendApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int ProductionYear { get; set; }
        public int PassedKms { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
    }
}