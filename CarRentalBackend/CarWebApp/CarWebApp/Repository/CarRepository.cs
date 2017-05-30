using CarWebApp.DAL;
using CarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWebApp.Repository
{
    class CarRepository : ICarRepository
    {
        CarContext db = new CarContext();

        public List<Car> GetAll()
        {
            WebApiConfig.Logger.info("CarRepository->GetAll");

            return db.Cars.ToList();
        }

        public Car Get(int Id)
        {
            WebApiConfig.Logger.info("CarRepository->Get with id = "+Id.ToString());

            return db.Cars.Find(Id);
        }

        public int Create(Car Car)
        {
            WebApiConfig.Logger.info("enter CarRepository->Create with id = " + Car.Id.ToString());

            var Created = db.Cars.Add(Car);
            db.SaveChanges();
            WebApiConfig.Logger.info("return from CarRepository->Create with id = " + Car.Id.ToString());

            return Created.Id;
        }

        public Car Update(Car Car)
        {
            WebApiConfig.Logger.info("enter CarRepository->Update with id = " + Car.Id.ToString());

            db.Entry(Car).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            WebApiConfig.Logger.info("return from CarRepository->Update with id = " + Car.Id.ToString());

            return Car;
        }

        public void Delete(int Id)
        {
            WebApiConfig.Logger.info("enter CarRepository->Delete with id = " + Id.ToString());

            var Deleted = db.Cars.Find(Id);
            db.Cars.Remove(Deleted);
            db.SaveChanges();
            WebApiConfig.Logger.info("return from CarRepository->Delete with id = " + Id.ToString());

        }

        public bool CarExists(int key)
        {
            WebApiConfig.Logger.info("CarRepository->CarExists with id = " + key.ToString());

            return db.Cars.Any(p => p.Id == key);
        }
    }
}