using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZSZ.Common;
using ZSZ.IService;
using ZSZ.Service;
using ZSZ.IDAL;
using ZSZ.Model.Models.DTO;

namespace AdminUIUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           
            AdminUser user = new AdminUser();
            user.Phone = "17512039375";
            user.CreateTime =DateTime.Now;
            user.CreateUser = 1;
            user.Salt = "123456";
            user.PwdHush = EncryptHelper.GetMd5("n5187698" + user.Salt);
            user.Guid = Guid.NewGuid().ToString("N");
          
        }
    }
}
