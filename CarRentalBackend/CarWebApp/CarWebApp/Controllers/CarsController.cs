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
            return db.GetAll().AsQueryable<Car>();
        }

        [EnableQuery]
        public SingleResult<Car> Get([FromODataUri] int key)
        {
            IQueryable<Car> result = db.GetAll().AsQueryable<Car>().Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Create(car);
            return Created(car); //(IHttpActionResult) db.Get(car.Id);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Car update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            /*var product = await db.Cars.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Cars.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);*/
            db.Delete(key);
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
            CarContext db = new CarContext(); //UWAGA!!!
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}
