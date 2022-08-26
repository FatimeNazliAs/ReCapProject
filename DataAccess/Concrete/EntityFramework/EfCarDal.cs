using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext ctx = new ReCapContext())
            {
                var result = from c in ctx.Car
                             join b in ctx.Brand
                             on c.BrandId equals b.Id
                             join co in ctx.Color
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 BrandName = b.Name,
                                 ColorName=co.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }



    }
}
