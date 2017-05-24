using CarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWebApp.DAL
{
    public class CarInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            var cars = new List<Car>
            {
                new Car() {Id =1, Price=1000, ProductionYear=2009, PassedKms=200000, Brand="Audi", Type = "Sedan", Model="A5"},
                new Car() {Id =2, Price=2000, ProductionYear=2005, PassedKms=150000, Brand="Nissan", Type = "Pickup", Model="PATROL"},
                new Car() {Id =3, Price=3000, ProductionYear=2011, PassedKms=56000, Brand="Fiat", Type = "Sport", Model="BRAVO"}
            };
            cars.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();

        }
    }
}