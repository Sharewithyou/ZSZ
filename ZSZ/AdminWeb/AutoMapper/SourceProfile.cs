﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZSZ.Model;
using ZSZ.Model.Model;

namespace AdminWeb.AutoMapper
{
    public class SourceProfile: Profile
    {
        public SourceProfile()
        {
            base.CreateMap<T_SysMenus, SysMenus>();         
        }
    }
}