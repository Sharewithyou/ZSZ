using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;

namespace AdminWeb.Model
{
    public class BtnRoleHelper
    {
        //public static IBtnPermissionService BtnPermissionService { get; set; }
        ////public BtnRoleHelper(IBtnPermissionService btnPermissionService)
        ////{
        ////   BtnPermissionService = btnPermissionService;
        ////}

        IBtnPermissionService BtnPermissionService = DependencyResolver.Current.GetService<IBtnPermissionService>();

        public  bool IsValid(string controller, string action)
        {
            return BtnPermissionService.IsValid(36, controller, action);
        }
    }
}