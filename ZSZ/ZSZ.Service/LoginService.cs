using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Common;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;
using ZSZ.Model.Models.DTO.Request;

namespace ZSZ.Service
{
    public class LoginService : BaseService<T_AdminUsers>, ILoginService
    {
        public ILoginDal LoginDal { get; set; }
        public LoginService(ILoginDal currentDal) : base(currentDal)
        {
            this.LoginDal = currentDal;
        }

        /// <summary>
        /// 校验账户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public MsgResult CheckLogin(LoginRequest request)
        {
            MsgResult result = new MsgResult();
            try
            {
                var model = LoginDal.GetModels(x => x.Phone == request.UserName).FirstOrDefault();
                if (model != null)
                {
                    string pwd = EncryptHelper.GetMd5(request.PassWord + model.Salt);
                    if (model.PwdHush == pwd)
                    {
                        result.IsSuccess = true;
                        result.Message = "登录成功";
                        result.Data = model.Id.ToString();
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "账户或者密码有误";
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "账户或者密码有误";
                }
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "登陆失败：" + ex.Message;
            }
            return result;
        
        }
    }
}
