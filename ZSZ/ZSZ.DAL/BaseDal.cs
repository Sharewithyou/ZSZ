using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IDAL;
namespace ZSZ.DAL
{
    public class BaseDal<T> : IBaseDal<T> where T : class
    {
        private DbContext dbContext = DbContextFactory.Create();

        public void Add(T t)
        {
            //set只是获取EF模型的一种方式而已，在适合使用它的场景使用，比如要在底层做一些封装的时候。
            //dbContext.Set<T>().Add(t);
            dbContext.Entry<T>(t).State = EntityState.Added;
        }

        public void AddRange(List<T> list)
        {
            dbContext.Set<T>().AddRange(list);
        }

        /// <summary>
        /// 标记删除-IsDeleted
        /// </summary>
        /// <param name="t"></param>
        public void MarkDelete(T t)
        {
            foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
            {
                if (p.GetValue(t) == null)
                {

                    dbContext.Entry<T>(t).Property(p.Name).CurrentValue = "";
                }
            }
            dbContext.Set<T>().Attach(t);
            dbContext.Entry<T>(t).Property("IsDeleted").IsModified = true;
        }

        public void Delete(T t)
        {
            //dbContext.Set<T>().Remove(t);
            dbContext.Entry<T>(t).State = EntityState.Deleted;
        }

        public void Update(T t)
        {
            //dbContext.Set<T>().AddOrUpdate(t);
            dbContext.Entry<T>(t).State = EntityState.Modified;
        }

        public void UpdateEntityFields(T t, List<string> fieldNames)
        {
            if (fieldNames != null && fieldNames.Count > 0)
            {
                dbContext.Set<T>().Attach(t);
                foreach (var item in fieldNames)
                {
                    dbContext.Entry<T>(t).Property(item).IsModified = true;
                }
            }
            else
            {
                dbContext.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda, out int totalCount)
        {
            var temp = dbContext.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, type>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageIndex);
            }
            else
            {
                temp = temp.OrderByDescending<T, type>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageIndex);
            }
            return temp;
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0 ;
        }

       
    }
}
