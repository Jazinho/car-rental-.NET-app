using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<int> RentingHistory;

        public Client() { RentingHistory = new List<int>(); }
    }
}