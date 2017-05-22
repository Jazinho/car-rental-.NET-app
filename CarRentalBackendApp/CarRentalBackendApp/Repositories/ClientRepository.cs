using CarRentalBackendApp.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CarRentalBackendApp.Repositories
{
    class ClientRepository : IClientRepository
    {
        //  static string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //  static string parentPath = Path.GetFullPath(Path.Combine(currentPath, "..\\..\\.."));
        //  private readonly string ClientConnection = parentPath + @"\clients.db";
        private readonly string ClientConnection = @"??????????????????\clients.db";
        public List<Client> GetAll()
        {
            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                var res = repo.FindAll();

                return res.Select(x => Map(x)).ToList();
            }
        }

        public int Create(Client Client)
        {
            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                var dbObj = InvMap(Client);

                if (repo.FindById(Client.Id) == null)
                    repo.Insert(dbObj);
                else
                    repo.Update(dbObj);

                return dbObj.Id;
            }
        }

        public Client Get(int Id)
        {
            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                return Map(repo.FindById(Id));
            }
        }

        public Client Update(Client Client)
        {
            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                var dbObj = InvMap(Client);
                if (repo.Update(dbObj))
                    return Map(dbObj);
                else
                    return null;
            }
        }

        public bool Delete(int Id)
        {
            using (var db = new LiteDatabase(ClientConnection))
            {
                var repo = db.GetCollection<ClientDB>("clients");
                return repo.Delete(Id);
            }
        }

        internal Client Map(ClientDB ClientDB)
        {
            if (ClientDB == null)
                return null;
            Client Client = new Client() { Id = ClientDB.Id, Name = ClientDB.Name, Surname = ClientDB.Surname };
            String[] str = ClientDB.RentingHistory.Split('#');
            foreach (var num in str)
            {
                if (!num.Equals(""))
                {
                    Client.RentingHistory.Add(int.Parse(num));
                }
            }
            return Client;
        }

        internal ClientDB InvMap(Client Client)
        {
            if (Client == null)
                return null;
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
            return ClientDB;

        }
    }
}