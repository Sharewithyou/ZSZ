using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IDAL;

namespace ZSZ.Service
{
    public class BaseService<T> where T : class , IBaseDal<T>
    {
        public int Add(T t)
        {
            throw new NotImplementedException();
        }

        public int Delete(T t)
        {
            throw new NotImplementedException();
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetModels(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, System.Linq.Expressions.Expression<Func<T, type>> OrderByLambda, System.Linq.Expressions.Expression<Func<T, bool>> WhereLambda)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

      
    }
}
