using ClientWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebApp.Repository
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        int Create(Client Client);
        Client Get(int Id);
        Client Update(Client Client);
        bool Delete(int Id);
    }
}
