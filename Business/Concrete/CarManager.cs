using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            try
            {
                if (car.Description.Length >= 2)
                {
                    if (car.DailyPrice > 0)
                    {
                        _carDal.Add(car);
                        Console.WriteLine(car.Description + " sisteme eklendi.");
                    }
                    else
                    {
                        Console.WriteLine("Araba günlük kiralama fiyatı 0'dan büyük olmalı.");
                    }

                }
                else
                {
                    Console.WriteLine("Araba ismi 2 karakterden küçük olamaz!");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            
            
        }

        public void Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                Console.WriteLine(car.Description + " sistemden silindi.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll().ToList();
        }

        public Car Get(int carId)
        {
            return _carDal.Get(x=> x.Id == carId);
        }

        public void Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                Console.WriteLine(car.Description + " güncellendi.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
