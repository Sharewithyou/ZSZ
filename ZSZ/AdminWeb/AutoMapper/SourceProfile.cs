using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZSZ.Model;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;

namespace AdminWeb.AutoMapper
{
    public class SourceProfile : Profile
    {
        public SourceProfile()
        {
            base.CreateMap<T_SysMenus, SysMenus>();

            base.CreateMap<SysMenus, T_SysMenus>();

            base.CreateMap<T_AdminUsers, AdminUser>();

            base.CreateMap<AdminUser, T_AdminUsers>();
        }

        //protected override void Configure()
        //{
        //    CreateMap<T_SysMenus, SysMenus>();
        //}

    }
}