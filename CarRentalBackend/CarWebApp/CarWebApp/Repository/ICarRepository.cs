using CarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApp.Repository
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
