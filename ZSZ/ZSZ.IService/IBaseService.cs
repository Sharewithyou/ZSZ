using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model.Model;

namespace ZSZ.IService
{
    public interface IBaseService<T> where T : class
    {
        MsgResult AddEntity(T entity);
        MsgResult UpdateEntity(T entity);
        MsgResult MarkDeleteEntity(T entity);
        MsgResult Clear(string tableName);
       
        //1，使用 IEnumerable<> 结果就已经将所有的数据查询出来，最后在内存中进行操作所有对于IEnumerable的过滤，排序等操作，都是在内存中发生的。也就是说数据已经从数据库中获取到了内存中，只是在内存中进行过滤和排序操作。

        //2，使用 IQueryable<T> 对于IQueryable的过滤，排序等操作，都会先缓存到表达式树中，只有当真正遍历发生的时候，才会将表达式树由IQueryProvider执行获取数据操作。（只有遍历的时候才会最后生成sql语句，查询数据）

        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<s>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderByLambda, int pageIndex, int pageSize, bool isAsc, out int totalCount);
    }
}
