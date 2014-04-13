using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Car.Test.DAL
{
    public interface IBaseRepository<T> where T : class,new()
    {
        IEnumerable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IEnumerable<T> LoadEntitiesByCache(Expression<Func<T, bool>> whereLambda);
        T AddEntity(T entity);
        T UpdateEntity(T entity);
        void ClearCache();
        void SaveChanges();
    }

}