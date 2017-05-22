using CarRentalBackendApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBackendApp.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        Car Get(int Id);
        int Create(Car car);
        Car Update(Car car);
        void Delete(int Id);
    }
}
