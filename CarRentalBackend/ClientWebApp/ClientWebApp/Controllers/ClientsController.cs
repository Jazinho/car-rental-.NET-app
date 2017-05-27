using ClientWebApp.Models;
using ClientWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace ClientWebApp.Controllers
{
    public class ClientsController : ODataController
    {
        ClientRepository db = new ClientRepository();


        [EnableQuery]
        public IQueryable<Client> Get()
        {
            //return db.Clients;
            return db.GetAll().AsQueryable<Client>();
        }

        [EnableQuery]
        public SingleResult<Client> Get([FromODataUri] int key)
        {
            IQueryable<Client> result = db.GetAll().Where(p => p.Id == key).AsQueryable<Client>();
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //db.Clients.Add(client);
            //await db.SaveChangesAsync();
            db.Create(client);
            return Created(client);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Client update)
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
                if (!ClientExists(key))
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
            /*var product = await db.Clients.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Clients.Remove(product);
            await db.SaveChangesAsync();*/
            db.Delete(key);
            return StatusCode(HttpStatusCode.NoContent);
        }


        private bool ClientExists(int key)
        {
            //return db.Clients.Any(p => p.ID == key);
            if (db.Get(key) != null) return true; return false;
        }
        /*
        protected override void Dispose(bool disposing)
        {
            //ClientContext db = new ClientContext();
            db.Dispose();
            base.Dispose(disposing);
        }*/

    }
}
