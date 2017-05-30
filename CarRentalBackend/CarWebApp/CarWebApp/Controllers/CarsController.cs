using CarWebApp.DAL;
using CarWebApp.Models;
using CarWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace CarWebApp.Controllers
{
    public class CarsController : ODataController
    {

        CarRepository db = new CarRepository();
        /*
        [HttpGet]
        [ODataRoute("Dalajlama(Postal={postalCode})")]
        public IHttpActionResult GetSalesTaxRate([FromODataUri] int postalCode)
        {
            double rate = 5.6;  // Use a fake number for the sample.
            return Ok(rate);
        }*/


        [EnableQuery]
        public IQueryable<Car> Get()
        {
            //   Logger logger = new Logger(Logger.State.INFO);
            WebApiConfig.Logger.info("CarsController->Get all cars");
            return db.GetAll().AsQueryable<Car>();
        }

        [EnableQuery]
        public SingleResult<Car> Get([FromODataUri] int key)
        {
            WebApiConfig.Logger.info("enter CarsController->Get car with id = "+key.ToString());
            IQueryable<Car> result = db.GetAll().AsQueryable<Car>().Where(p => p.Id == key);
            WebApiConfig.Logger.info("return from CarsController->Get car with id = " + key.ToString());
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Car car)
        {
            WebApiConfig.Logger.info("enter CarsController->Post car = " + car.ToString());
            if (!ModelState.IsValid)
            {
                WebApiConfig.Logger.warning("return from CarsController->Post car = " + car.ToString()+" BAD REQUEST");

                return BadRequest(ModelState);
            }
            db.Create(car);
            WebApiConfig.Logger.info("return from CarsController->Post car = " + car.ToString());
            return Created(car); //(IHttpActionResult) db.Get(car.Id);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Car update)
        {
            WebApiConfig.Logger.info("enter CarsController->Put car where id = " + key.ToString());

            if (!ModelState.IsValid)
            {
                WebApiConfig.Logger.warning("return from CarsController->Put car where id = " + key.ToString()+" BAD REQUEST");

                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                WebApiConfig.Logger.warning("return from CarsController->Put car where id = " + key.ToString() + " key != update.Id");

                return BadRequest();
            }
            //db.Entry(update).State = EntityState.Modified;
            db.Update(update);
            try
            {
                //await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!db.CarExists(key))
                {
                    WebApiConfig.Logger.warning("return from CarsController->Put where car doesn't exist");

                    return NotFound();
                }
                else
                {
                    WebApiConfig.Logger.error("exception thrown in CarsController->Put car where id = " + key.ToString());

                    throw;
                }
            }
            WebApiConfig.Logger.info("return from CarsController->Put car where id = " + key.ToString());

            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            WebApiConfig.Logger.info("enter CarsController->Delete car with id = " + key.ToString());

            /*var product = await db.Cars.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Cars.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);*/
            db.Delete(key);
            WebApiConfig.Logger.info("return from CarsController->Delete car with id = " + key.ToString());

            return StatusCode(HttpStatusCode.NoContent);
        }

        /*
        private bool CarExists(int key)
        {
            //return db.Cars.Any(p => p.Id == key);
            //funkcja w repo by się przydała
            if (db.Get(key) == null) return false; else return true;
        }*/
        protected override void Dispose(bool disposing)
        {
            WebApiConfig.Logger.info("enter CarsController->Dispose with disposing = "+disposing.ToString());

            CarContext db = new CarContext(); //UWAGA!!!
            db.Dispose();
            base.Dispose(disposing);
            WebApiConfig.Logger.info("return from CarsController->Dispose with disposing = " + disposing.ToString());

        }


    }
}
