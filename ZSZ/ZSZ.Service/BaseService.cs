using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IDAL;
using ZSZ.IService;

namespace ZSZ.Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {

        public BaseService()
        {
            SetDal();
        }

        public abstract void SetDal();

        public IBaseDal<T> Dal { get; set; }

     
        public T AddEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public bool EditEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> LoadPageEntities<s>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderByLambda, int pageIndex, int pageSize, bool isAsc, out int totalCount)
        {
            throw new NotImplementedException();
        }
    }
}
