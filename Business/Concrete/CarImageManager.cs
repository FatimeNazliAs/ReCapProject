using Business.Abstract;
using Business.Constants;
using Core2.Utilities.Business;
using Core2.Utilities.Helpers;
using Core2.Utilities.Results.DataResults;
using Core2.Utilities.Results.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result!=null)
            {
                return result;

            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstans.ImagesPath);
            if (carImage.ImagePath==null)
            {
                carImage.ImagePath = "default.jpg";
            }
            carImage.Date= DateTime.Now;    
            _carImageDal.Add(carImage);
            return new SuccessResult();
        
        
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstans.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carId));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);

            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));

        }

        public IDataResult<CarImage> GetByCarImageId(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carImageId));
        }

        public IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId= carId ,Date=DateTime.Now, ImagePath = "default.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);





        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            //public string Update(IFormFile file, string filePath, string root)
            carImage.ImagePath = _fileHelper.Update(file, PathConstans.ImagesPath + carImage.ImagePath, PathConstans.ImagesPath);

            _carImageDal.Update(carImage);
            return new SuccessResult();
        
        
        
        }



        
        
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>5)
            {
                return new SuccessResult(Messages.CarImageLimitExceeded);

            }
            return new ErrorResult();
        }
    }
}
