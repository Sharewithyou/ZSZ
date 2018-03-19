using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.IDAL
{
    public interface IBaseDal<T> where T : class
    {
        /// <summary>
        /// 增加实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        void Add(T t);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        void Delete(T t);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        void Update(T t);

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize">数据大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isAsc">排序规则</param>
        /// <param name="OrderByLambda"></param>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda, out int totalCount);

        /// <summary>
        /// 一个业务中有可能涉及到对多张表的操作,那么可以将操作的数据,打上相应的标记,最后调用该方法,将数据一次性提交到数据库中,避免了多次链接数据库。
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

    }
}
