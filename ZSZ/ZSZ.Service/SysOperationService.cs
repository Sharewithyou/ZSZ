using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Entity;

namespace ZSZ.Service
{
    public class SysOperationService:BaseService<T_SysOperations>, ISysOperationService
    {
        public ISysOperationDal SysOperationDal { get; set; }
        public SysOperationService(ISysOperationDal currentDal) : base(currentDal)
        {
            this.SysOperationDal = currentDal;
        }
    }
}
