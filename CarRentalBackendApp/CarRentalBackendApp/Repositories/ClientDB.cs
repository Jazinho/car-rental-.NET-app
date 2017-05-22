using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalBackendApp.Repositories
{
    class ClientDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RentingHistory { get; set; }
    }
}