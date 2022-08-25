using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapContext ctx = new ReCapContext())
            {
                //referansı yakala
                var addedEntity = ctx.Entry(entity);
                // o aslında eklenecek bir nesne
                addedEntity.State = EntityState.Added;
                ctx.SaveChanges();

            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext ctx = new ReCapContext())
            {
                //referansı yakala
                var deletedEntity = ctx.Entry(entity);
                // o aslında eklenecek bir nesne
                deletedEntity.State = EntityState.Deleted;
                ctx.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext ctx = new ReCapContext())
            {
                return ctx.Set<Car>().SingleOrDefault(filter);  

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext ctx = new ReCapContext())
            {
                return filter == null ?
                        ctx.Set<Car>().ToList()
                        : ctx.Set<Car>().Where(filter).ToList();

            }
        }

        public void Update(Car entity)
        {
            using (ReCapContext ctx = new ReCapContext())
            {
                //referansı yakala
                var updatedEntity = ctx.Entry(entity);
                // o aslında eklenecek bir nesne
                updatedEntity.State = EntityState.Modified;
                ctx.SaveChanges();

            }
        }
    }
}
