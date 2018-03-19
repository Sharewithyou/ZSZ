using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model;
using ZSZ.IDAL;
using ZSZ.IService;


namespace ZSZ.Service
{
    public class SysMenuService : BaseService<T_SysMenus>, ISysMenuService
    {
        private ISysMenuDal MenuDal;
        public override void SetDal()
        {
            Dal = MenuDal;
        }
    }
}
