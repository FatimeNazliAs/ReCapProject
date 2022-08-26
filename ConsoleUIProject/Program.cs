using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUIProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();
            CarDto();
        }

        private static void CarDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var c in carManager.GetCarDetails())
            {

                Console.WriteLine(c.BrandName + " /" + c.ColorName + " /" + c.DailyPrice
                    + " /" + c.Description);

            }
        }

        private static void BrandTest()
        {
            Brand brand = new Brand();
            brand.Name = "pasat";
            EfBrandDal brandDal = new EfBrandDal();
            brandDal.Add(brand);
            Brand brand2 = new Brand();
            

           

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var c in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(c.Id);
            }
            
            
            Car car = new Car();
            //car.Id = 6;
            car.BrandId = 5;
            car.ColorId = 3;
            car.ModelYear = 2013;
            car.DailyPrice = 900;
            car.Description = "guzel araba";
            
            EfCarDal carDal = new();
            //carDal.Add(car);
           // carDal.Delete(car);
            
            Car car3 = new Car();
            car3.BrandId = 8;
            car3.ColorId = 4;
            car3.ModelYear = 2018;
            car3.DailyPrice = 900;
            car3.Description = "kotu araba";
            carDal.Add(car3);





        }
    
    
    
    
    }
}
