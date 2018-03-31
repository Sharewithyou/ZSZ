using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        T Add(T t);

        /// <summary>
        /// 批量增加实体
        /// </summary>
        /// <param name="list"></param>
        List<T> AddRange(List<T> list);

        /// <summary>
        /// 标记删除 标记当前对象，必须把必填字段都填写，否则会报错：System.Data.Entity.Validation.DbEntityValidationException
        /// </summary>
        /// <param name="t"></param>
        void MarkDelete(T t);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        void Delete(T t);

        //1，EF修改常用方法
        //(1) 先查询出实体，然后再修改
        //(2) 设置不修改的字段IsModified为false
        //(3) 使用 EntityFramework.Extended 扩展，缺点是EF的上下文日志不能捕获执行的sql,

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        void Update(T t);

        /// <summary>
        /// 修改实体的部分字段
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fileds">修改实体的相关字段</param>
        void UpdateEntityFields(T t, List<string> fileds);

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

        /// <summary>
        /// 清空表中的数据
        /// </summary>
        /// <param name="tableName"></param>
        int Clear(string tableName);

    }
}
