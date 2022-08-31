using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //CarDto();
            //CarErrorSuccess();

            //CustomerAdd();
            RentalDto();

        }

        private static void RentalDto()
        {
            EfRentalDal efRentalDal = new EfRentalDal();
            RentalManager rentalManager = new RentalManager(efRentalDal);
            foreach (var item in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(item.CustomerId + " " + item.RentDate + " " + item.ReturnDate);
            }
        }

        private static void CustomerAdd()
        {
            EfCustomerDal efCustomerDal = new EfCustomerDal();
            CustomerManager customerManager = new CustomerManager(efCustomerDal);
            Customer customer = new Customer();
            customer.CompanyName = "BetNaz";
            customerManager.Add(customer);
            Customer customer2 = new Customer();
            customer2.CompanyName = "NazBet";
            //customerManager.Add(customer2);
        }

        private static void CarErrorSuccess()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var c in carManager.GetCarDetails().Data)
                {

                    Console.WriteLine(c.BrandName + " /" + c.ColorName + " /" + c.DailyPrice
                        + " /" + c.Description);

                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var c in carManager.GetCarDetails().Data)
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
            //foreach (var c in carManager.GetCarsByColorId(1))
            //{
            //    Console.WriteLine(c.Id);
            //}

            Car car = new Car();
            car.BrandId = 8;
            car.ColorId = 8;
            car.ModelYear = 2012;
            car.DailyPrice = 900;
            car.Description = "guzel araba";

            EfCarDal carDal = new();

            carDal.Add(car);
       

            //Car car3 = new Car();
            //car3.BrandId = 7;
            //car3.ColorId = 5;
            //car3.ModelYear = 2016;
            //car3.DailyPrice = 900;
            //car3.Description = "kotu araba";
            //carDal.Add(car3);




        }


    }
}
