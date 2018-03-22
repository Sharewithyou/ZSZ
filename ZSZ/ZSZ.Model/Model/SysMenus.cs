﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Model
{
    public class SysMenus
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int ParentId { get; set; }
        public int SortNum { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}