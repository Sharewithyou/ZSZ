using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Model
{
    public class MsgResult
    {
        /// 成功与否
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public int MsgCode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }
    }
}
