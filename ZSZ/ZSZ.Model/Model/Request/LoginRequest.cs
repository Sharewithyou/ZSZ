using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Model.Request
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string VerifyCode { get; set; }
        public bool IsKeepLogin { get; set; }
    }
}
