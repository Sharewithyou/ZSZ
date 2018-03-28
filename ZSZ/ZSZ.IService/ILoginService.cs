﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model;
using ZSZ.Model.Entity;
using ZSZ.Model.Model;
using ZSZ.Model.Model.Request;

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
