using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Model;

namespace ZSZ.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public IBaseDal<T> BaseDal { get; set; }
        public BaseService(IBaseDal<T> currentDal)
        {
            this.BaseDal = currentDal;
        }

        public MsgResult AddEntity(T entity)
        {
            MsgResult result = new MsgResult();          
            try
            {
                BaseDal.Add(entity);
                BaseDal.SaveChanges();                         
                result.IsSuccess = true;
                result.Message = "增加成功";
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                {
                    sb.AppendLine(ve.PropertyName + ":" + ve.ErrorMessage);
                }
                result.IsSuccess = false;
                result.Message = "增加失败：" + sb.ToString();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "增加失败：" + ex.Message;
            }

            return result;
        }

        public MsgResult UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public MsgResult MarkDeleteEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> LoadPageEntities<s>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderByLambda, int pageIndex, int pageSize, bool isAsc, out int totalCount)
        {
            throw new NotImplementedException();
        }



        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }
    }
}
