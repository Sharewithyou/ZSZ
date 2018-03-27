using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Model;
using ZSZ.Service;

namespace ZSZ.Service
{
    public class AdminUserService : BaseService<AdminUser>, IAdminUserService
    {
        public IAdminUserDal AdminUerDal { get; set; }
        public AdminUserService(IAdminUserDal currentDal) : base(currentDal)
        {
            this.AdminUerDal = currentDal;
        }

        public MsgResult AddAdminUser(AdminUser user)
        {
            return null;
        }
    }
}
