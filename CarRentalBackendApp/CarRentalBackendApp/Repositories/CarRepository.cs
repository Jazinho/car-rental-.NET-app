using CarRentalBackendApp.DAL;
using CarRentalBackendApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalBackendApp.Repositories
{
    class CarRepository : ICarRepository
    {
        CarContext db = new CarContext();

        public List<Car> GetAll()
        {
            return db.Cars.ToList();
        }

        public Car Get(int Id)
        {
            return db.Cars.Find(Id);
        }

        public int Create(Car Car)
        {
            var Created = db.Cars.Add(Car);
            db.SaveChanges();

            return Created.Id;
        }

        public Car Update(Car Car)
        {
            db.Entry(Car).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Car;
        }

        public void Delete(int Id)
        {
            var Deleted = db.Cars.Find(Id);
            db.Cars.Remove(Deleted);
            db.SaveChanges();
        }
    }
}