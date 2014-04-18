using System.Data;
using System.Linq;
using Car.Test.Cache;
using Car.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;


namespace Car.Test.DAL
{
    public class BaseRepository<T> where T:class,new()
    {
        protected CarModelContainer DataContext { get; private set; }
        public ICacheProvider Cache { get; set; }

        public BaseRepository(ICacheProvider cacheProvider)
        {
            this.DataContext = new CarModelContainer();
            this.Cache = cacheProvider;
        }

        public BaseRepository():this(new DefaultCacheProvider()){}

        public virtual IEnumerable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            IEnumerable<T> temp = DataContext.Set<T>().Where(whereLambda).AsEnumerable();
            return temp;
        }

        public virtual IEnumerable<T> LoadEntitiesByCache(Expression<Func<T, bool>> whereLambda)
        {
            IEnumerable<T> entities = Cache.Get(typeof(T).ToString()) as IEnumerable<T>;
            if (entities == null)
            {
                entities = DataContext.Set<T>().Where(whereLambda).AsEnumerable();
                if (entities.Any())
                {
                    Cache.Set(typeof(T).ToString(),entities,3);
                }
            }
            return entities;
        }

        public virtual T AddEntity(T entity)
        {
            DataContext.Set<T>().Add(entity);
            return entity;
        }

        public virtual T UpdateEntity(T entity)
        {
            if (entity != null)
            {
                DataContext.Set<T>().Attach(entity);
                DataContext.Entry(entity).State = EntityState.Modified;

            }
            return entity;
        }

        public void ClearCache()
        {
            Cache.InValidate(typeof(T).ToString());
        }

        public int SaveChanges()
        {
            return DataContext.SaveChanges();
        }
    }
}