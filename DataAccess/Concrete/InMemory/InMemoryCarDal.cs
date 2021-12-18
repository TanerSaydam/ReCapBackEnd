using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=1990,DailyPrice=10000,Description="Renault"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=1997,DailyPrice=18000,Description="Mercedes"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2000,DailyPrice=19000,Description="Audi"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine(car.Description + " kayıtlara eklendi.");
        }

        public void Delete(Car car)
        {
            Car carFind = _cars.Find(a => a.Id == car.Id);
            _cars.Remove(carFind);
            Console.WriteLine(car.Description + " kayıtlardan silindi.");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public IList<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            return _cars.Find(a => a.Id == carId);
        }

        public void Update(Car car)
        {
            Car carFind = _cars.Find(a => a.Id == car.Id);
            _cars.Remove(carFind);
            _cars.Add(carFind);
            Console.WriteLine(car.Description + " kayıtı güncellendi.");
        }
    }
}
