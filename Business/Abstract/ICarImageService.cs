using Core2.Utilities.Results.DataResults;
using Core2.Utilities.Results.Results;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete( CarImage carImage);

        IDataResult<CarImage> GetByCarImageId(int carImageId);
        IDataResult<List<CarImage>> GetByCarId(int carId);

        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetDefaultImage(int carId);
    }
}
