using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core2.Aspects.Autofac.Validation;
using Core2.Utilities.Results.DataResults;
using Core2.Utilities.Results.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        
        
        
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (DateTime.Now.Hour ==16)
            {
                Console.WriteLine(Messages.CarNameInvalid);
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);

            }
  
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        public IResult Delete(Car car)
        {
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Car>> GetCarsById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

      
    }
}
