using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Models;

namespace ZSZ.Service
{
    public class BtnPermissionService : IBtnPermissionService
    {
        public IAdminUserDal AdminUserDal { get; set; }
        public ISysPermissionDal SysPermissionDal { get; set; }
        public BtnPermissionService(IAdminUserDal adminUserDal,ISysPermissionDal sysPermissionDal)
        {
            this.AdminUserDal = adminUserDal;
            this.SysPermissionDal = sysPermissionDal;
        }
        public bool IsValid(int userId, string controller, string action)
        {
            var model = AdminUserDal.GetModels(x => x.Id == userId).FirstOrDefault();
            if (model != null)
            {
                //SysPermissionDal.GetModels(x=>x.Id)
                //List<T_SysOperations> list 
                return false;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }
}
