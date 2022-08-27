using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext ctx = new TContext())
            {
                //referansı yakala
                var addedEntity = ctx.Entry(entity);
                // o aslında eklenecek bir nesne
                addedEntity.State = EntityState.Added;
                ctx.SaveChanges();
                Console.WriteLine("added");

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                //referansı yakala
                var deletedEntity = ctx.Entry(entity);
                // o aslında eklenecek bir nesne
                deletedEntity.State = EntityState.Deleted;
                ctx.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext ctx = new TContext())
            {
                return ctx.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext ctx = new TContext())
            {
                return filter == null ?
                        ctx.Set<TEntity>().ToList()
                        : ctx.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext ctx = new TContext())
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
