using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;
using ZSZ.Service;

namespace ZSZ.Service
{
    public class AdminUserService : BaseService<T_AdminUsers>, IAdminUserService
    {
        public IAdminUserDal AdminUerDal { get; set; }
        public AdminUserService(IAdminUserDal currentDal) : base(currentDal)
        {
            this.AdminUerDal = currentDal;
        }

     

    
    }
}
