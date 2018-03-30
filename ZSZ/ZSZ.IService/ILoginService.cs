using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;
using ZSZ.Model.Models.DTO.Request;

namespace ZSZ.IService
{
    public interface ILoginService :IBaseService<T_AdminUsers>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MsgResult CheckLogin(LoginRequest request);
    }
}
