using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Models.DTO
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public string PwdHush { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
