using ClientWebApp.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebApp.Repository
{
    class ClientRepository : IClientRepository
    {
        //  static string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //  static string parentPath = Path.GetFullPath(Path.Combine(currentPath, "..\\..\\.."));
        //  private readonly string ClientConnection = parentPath + @"\clients.db";
        private readonly string ClientConnection = @"C:\Users\Jan\Documents\Visual Studio 2015\Projects\car-rental-.NET-app\CarRentalBackend\ClientWebApp\ClientWebApp\clients.db";
        public List<Client> GetAll()
        {
            WebApiConfig.Logger.info("enter ClientsController->GetAll");

            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                var res = repo.FindAll();
                WebApiConfig.Logger.info("return from ClientsController->GetAll");

                return res.Select(x => Map(x)).ToList();
            }
        }

        public int Create(Client Client)
        {
            WebApiConfig.Logger.info("enter ClientsController->Create");

            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                var dbObj = InvMap(Client);

                if (repo.FindById(Client.Id) == null)
                    repo.Insert(dbObj);
                else
                    repo.Update(dbObj);

                WebApiConfig.Logger.info("return from ClientsController->Create");

                return dbObj.Id;
            }
        }

        public Client Get(int Id)
        {
            WebApiConfig.Logger.info("enter ClientsController->Get with id = "+Id.ToString());

            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                WebApiConfig.Logger.info("return from ClientsController->Get with id = " + Id.ToString());

                return Map(repo.FindById(Id));
            }
        }

        public Client Update(Client Client)
        {
            WebApiConfig.Logger.info("enter ClientsController->Update with id = " + Client.Id.ToString());

            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                var dbObj = InvMap(Client);

                if (repo.Update(dbObj))
                {
                    WebApiConfig.Logger.info("return from ClientsController->Update with id = " + Client.Id.ToString());
                    return Map(dbObj);
                }
                else
                {
                    WebApiConfig.Logger.warning("return from ClientsController->Update with id = " + Client.Id.ToString()+ " UPDATE FAILED");
                     
                    return null;
                }
            }
        }

        public bool Delete(int Id)
        {
            WebApiConfig.Logger.info("enter ClientsController->Delete with id = " + Id.ToString());

            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                WebApiConfig.Logger.info("return from ClientsController->Delete with id = " + Id.ToString());

                return repo.Delete(Id);
            }
        }

        internal Client Map(ClientDB ClientDB)
        {
            WebApiConfig.Logger.info("enter ClientsController->Map with id = " + ClientDB.Id.ToString());

            if (ClientDB == null) {
                WebApiConfig.Logger.warning("return from ClientsController->Map ClientDB==null");

                return null;
            }
            Client Client = new Client() { Id = ClientDB.Id, Name = ClientDB.Name, Surname = ClientDB.Surname };
            /* String[] str = ClientDB.RentingHistory.Split('#'); //NullPointer
             foreach (var num in str)
             {
                 if (!num.Equals(""))
                 {
                     Client.RentingHistory.Add(int.Parse(num));
                 }
             }*/
            WebApiConfig.Logger.info("return from ClientsController->Map with id = " + ClientDB.Id.ToString());

            return Client;
        }

        internal ClientDB InvMap(Client Client)
        {
            WebApiConfig.Logger.info("enter ClientsController->InvMap with id = " + Client.Id.ToString());

            if (Client == null)
            {
                WebApiConfig.Logger.warning("return from ClientsController->InvMap where Client==null");

                return null;
            }
            ClientDB ClientDB = new ClientDB()
            {
                Id = Client.Id,
                Name = Client.Name,
                Surname = Client.Surname
            };
            string str = "";
            foreach (var ren in Client.RentingHistory)
            {
                str += ren.ToString() + "#";
            }
            ClientDB.RentingHistory = str;
            WebApiConfig.Logger.info("return  from ClientsController->InvMap with id = " + Client.Id.ToString());

            return ClientDB;

        }
    }
}