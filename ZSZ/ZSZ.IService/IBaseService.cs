using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model.Models.DTO;

namespace ZSZ.IService
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// 增加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        MsgResult AddEntity(T entity);

        /// <summary>
        /// 批量增加实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        MsgResult AddRange(List<T> list);

        /// <summary>
        /// 跟新实体部分字段
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldNames"></param>
        /// <returns></returns>
        MsgResult UpdateEntityFields(T entity, List<string> fieldNames);

        /// <summary>
        /// 不跟新实体某些字段
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldNames"></param>
        /// <returns></returns>
        MsgResult UpdateWithOutFields(T entity, List<string> fieldNames);

        /// <summary>
        /// 跟新实体所有字段
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        MsgResult UpdateEntity(T entity);

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        MsgResult MarkDeleteEntity(T entity);

        /// <summary>
        /// 清除某个表的数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        MsgResult Clear(string tableName);

      



        //1，使用 IEnumerable<> 结果就已经将所有的数据查询出来，最后在内存中进行操作所有对于IEnumerable的过滤，排序等操作，都是在内存中发生的。也就是说数据已经从数据库中获取到了内存中，只是在内存中进行过滤和排序操作。

        //2，使用 IQueryable<T> 对于IQueryable的过滤，排序等操作，都会先缓存到表达式树中，只有当真正遍历发生的时候，才会将表达式树由IQueryProvider执行获取数据操作。（只有遍历的时候才会最后生成sql语句，查询数据）

        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<s>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderByLambda, int pageIndex, int pageSize, bool isAsc, out int totalCount);
    }
}
