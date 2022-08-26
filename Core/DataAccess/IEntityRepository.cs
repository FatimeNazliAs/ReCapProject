using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint
    //class: referans tip olabilir demek
    //where T : class,IEntity => t ientity ya da onu implemente eden bir nesne olabilir.
    //where T : class,IEntity,new() => ientity newlenemez o yuzden kendisini kullanmamıs oluruz


    //kategorilere gore filtreler yapar dataya
    //filtre=null => tüm data isteyebilir
    public interface IEntityRepository<T> where T : class,IEntity, new()
    {
  
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        //filtre zorunlu hale geldi
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);




    }
}
