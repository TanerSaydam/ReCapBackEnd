using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
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
            InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
            inMemoryCarDal.Add(car1);            
            inMemoryCarDal.Add(car2);

            Console.WriteLine("----------------------------------------");

            //Car listesi ekrana yazdırılıyor
            foreach (var item in inMemoryCarDal.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine("----------------------------------------");

            //car2 kayıtı listeden siliniyor.
            inMemoryCarDal.Delete(car2);

            Console.WriteLine("----------------------------------------");

            //Car listesi tekrar ekrana yazdırılıyor
            foreach (var item in inMemoryCarDal.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine("----------------------------------------");

            //car1'in bilgisi değiştirip sistemden update işlemi yapılıyor
            car1.Description = "New Wolksvagen";
            inMemoryCarDal.Update(car1);

            Console.WriteLine("----------------------------------------");

            //Car listesi tekrar ekrana yazdırılıyor
            foreach (var item in inMemoryCarDal.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine("----------------------------------------");

            //Son olarak GetById ile 1 id'sine sahip kayıt bulunup ekrana bilgileri yazdırılıyor
            var findCar = inMemoryCarDal.GetById(1);
            Console.WriteLine(findCar.Description);

            Console.ReadLine();
        }
    }
}
