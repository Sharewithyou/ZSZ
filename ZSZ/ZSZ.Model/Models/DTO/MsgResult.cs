using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Models.DTO
{
    public class MsgResult
    {

        /// 成功与否
        /// </summary>
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }


        /// <summary>
        /// 返回数据
        /// </summary>      
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("msgCode")]
        /// <summary>
        /// 错误代码
        /// </summary>
        public int MsgCode { get; set; }

        [JsonProperty("message")]
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }
    }
}
