using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model.Model;

namespace ZSZ.IService
{
    public interface IInitDataService
    {
        /// <summary>
        /// 初始化所有权限
        /// </summary>
        void InitOperationData();
    }
}
