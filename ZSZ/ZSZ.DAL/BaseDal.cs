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
        // 1, Dbcontext

        // 2, Set<T>() 只是获取EF模型的一种方式

        private DbContext dbContext = DbContextFactory.Create();

        public void Add(T t)
        {
            //set只是获取EF模型的一种方式而已，在适合使用它的场景使用，比如要在底层做一些封装的时候。
            //entry 获取给定实体的DbEntityEntry对象，该对象提供对实体信息的访问以及对实体执行操作的能力。
            //DbContext.Entry方法用于访问被跟踪的实体并对其执行操作，比如修改值或设置EntityState，
            //Attach() 将给定实体附加到集的基础上下文中。也就是说，将实体以“未更改”的状态放置到上下文中，就好像从数据库读取了该实体一样。 
            //如果您有一个您知道已存在于数据库中的实体，但该实体目前没有被上下文跟踪，那么您可以告诉上下文使用DbSet上的Attach方法跟踪该实体。该实体将在上下文中处于未更改状态
            //如果调用SaveChanges而不对附加实体进行任何其他操作，则不会对数据库进行更改。这是因为实体处于未更改状态
            //dbContext.Set<T>().Add(t);  
            //通过调用DbSet上的Add方法可以将新实体添加到上下文中。这会使实体进入添加状态
            //向上下文添加新实体的另一种方法是将其状态更改为已添加
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
