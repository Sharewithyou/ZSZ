using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Model
{
    public class ZtreeNode
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pId")]
        public int Pid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]      
        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonIgnore]
        [JsonProperty("isParent")]     
        public bool IsParent { get; set; }
    }
}
