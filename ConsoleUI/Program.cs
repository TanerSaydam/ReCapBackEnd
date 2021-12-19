using Business.Concrete;
using DataAccess.Concrete.EntiyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ders7Odev();

            CarManager carManager = new CarManager(new EfCarDal());
            
            //Car car1 = new Car();
            //car1.BrandId = 1;
            //car1.ColorId = 2;
            //car1.DailyPrice = 15000;
            //car1.Description = "";

            //carManager.Add(car1);

            //car1.Description = "S700";
            //carManager.Update(car1);

            //carManager.Delete(car1);

            foreach (var item in carManager.GetListCarDetail())
            {
                Console.WriteLine(item.CarName + " - " + item.BrandName + " - " + item.ColorName + " - " + item.DailyPrice);
            }



            Console.ReadLine();
        }

        private static void Ders7Odev()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            //Yeni kayıtlar oluşturuluyor
            Car car1 = new Car();
            car1.Id = 4;
            car1.BrandId = 2;
            car1.ColorId = 3;
            car1.DailyPrice = 15000;
            car1.Description = "Wolksvagen";

            Car car2 = new Car();
            car2.Id = 5;
            car2.BrandId = 1;
            car2.ColorId = 2;
            car2.DailyPrice = 45000;
            car2.Description = "Peugeot";

            //Yeni kayıtlar inMemory üzerinden ekleniyor            
            carManager.Add(car1);
            carManager.Add(car2);

            Console.WriteLine("----------------------------------------");

            //Car listesi ekrana yazdırılıyor
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine("----------------------------------------");

            //car2 kayıtı listeden siliniyor.
            carManager.Delete(car2);

            Console.WriteLine("----------------------------------------");

            //Car listesi tekrar ekrana yazdırılıyor
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine("----------------------------------------");

            //car1'in bilgisi değiştirip sistemden update işlemi yapılıyor
            car1.Description = "New Wolksvagen";
            carManager.Update(car1);

            Console.WriteLine("----------------------------------------");

            //Car listesi tekrar ekrana yazdırılıyor
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine("----------------------------------------");

            //Son olarak GetById ile 1 id'sine sahip kayıt bulunup ekrana bilgileri yazdırılıyor
            var findCar = carManager.Get(1);
            Console.WriteLine(findCar.Description);
        }
    }
}
