using System;
using System.Collections.Generic;

namespace ZSZ.Model.Models
{
    public partial class T_SysMenus
    {
        public T_SysMenus()
        {
            this.T_MenuPermissions = new List<T_MenuPermissions>();
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int ParentId { get; set; }
        public int SortNum { get; set; }
        public string IconFont { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual ICollection<T_MenuPermissions> T_MenuPermissions { get; set; }
    }
}
