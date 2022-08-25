using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUIProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var c in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(c.Id.ToString());
            }
            {

            }


        }
    }
}
