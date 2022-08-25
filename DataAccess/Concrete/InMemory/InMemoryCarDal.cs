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
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id=1, BrandId=1, ColorId=15, ModelYear=1985, DailyPrice=750000, Description="Sedan"},
                new Car{ Id=2, BrandId=1, ColorId=22, ModelYear=2002, DailyPrice=645000, Description="HatcBack"},
                new Car{ Id=3, BrandId=2, ColorId=5, ModelYear=2006, DailyPrice=822000, Description="Station Wagon"},
                new Car{ Id=4, BrandId=2, ColorId=15, ModelYear=1998, DailyPrice=532000, Description="Sedan"},
                new Car{ Id=5, BrandId=3, ColorId=22, ModelYear=2008, DailyPrice=942000, Description="HatcBack"}
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id ==car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int categoryId)
        {
            return _cars.Where(c => c.Id == categoryId).Single();

        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id= car.Id;
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear= car.ModelYear;   
            carToUpdate.DailyPrice= car.DailyPrice;
            carToUpdate.Description= car.Description;

        }
    }
}
