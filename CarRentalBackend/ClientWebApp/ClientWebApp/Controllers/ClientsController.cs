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
            WebApiConfig.Logger.info("ClientsController->Get all clients");

            //return db.Clients;
            return db.GetAll().AsQueryable<Client>();
        }

        [EnableQuery]
        public SingleResult<Client> Get([FromODataUri] int key)
        {
            WebApiConfig.Logger.info("enter ClientsController->Get client with id = " + key.ToString());
            IQueryable<Client> result = db.GetAll().Where(p => p.Id == key).AsQueryable<Client>();
            WebApiConfig.Logger.info("return from ClientsController->Get client with id = " + key.ToString());
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Client client)
        {
            WebApiConfig.Logger.info("enter ClientsController->Post client with id = " + client.Id.ToString());

            if (!ModelState.IsValid)
            {
                WebApiConfig.Logger.warning("return from ClientsController->Post client BAD REQUEST");

                return BadRequest(ModelState);
            }
            //db.Clients.Add(client);
            //await db.SaveChangesAsync();
            db.Create(client);
            WebApiConfig.Logger.info("return from ClientsController->Post client with id = " + client.Id.ToString());

            return Created(client);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Client update)
        {
            WebApiConfig.Logger.info("enter ClientsController->Put client with id = " + key.ToString());

            if (!ModelState.IsValid)
            {
                WebApiConfig.Logger.warning("return from ClientsController->Put BAD REQUEST");

                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                WebApiConfig.Logger.warning("return from ClientsController->Put where key!=update.Id");

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
                    WebApiConfig.Logger.warning("return from ClientsController->Put where client doesn't exist");
                    return NotFound();
                }
                else
                {
                    WebApiConfig.Logger.error("exception thrown in ClientsController->Put client with id = " + key.ToString());

                    throw;
                }
            }
            WebApiConfig.Logger.info("return from ClientsController->Put client with id = " + key.ToString());

            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            WebApiConfig.Logger.info("enter ClientsController->Delete client with id = " + key.ToString());

            /*var product = await db.Clients.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Clients.Remove(product);
            await db.SaveChangesAsync();*/
            db.Delete(key);
            WebApiConfig.Logger.info("return from ClientsController->Delete client with id = " + key.ToString());

            return StatusCode(HttpStatusCode.NoContent);
        }


        private bool ClientExists(int key)
        {
            WebApiConfig.Logger.info("enter ClientsController->ClientExists with id = " + key.ToString());

            //return db.Clients.Any(p => p.ID == key);
            if (db.Get(key) != null)
            {
                WebApiConfig.Logger.info("return from ClientsController->ClientExists with id = " + key.ToString());

                return true;
            }
            WebApiConfig.Logger.warning("return from ClientsController->ClientExists with id = " + key.ToString()+" db.Get(key)==null");
            return false;
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
