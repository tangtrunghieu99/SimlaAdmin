using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string categoryName { get; set; }

        [JsonProperty("imgUrl")]
        public string imgage { get; set; }

        public Category(string id, string categoryName, string imgage)
        {
            this.id = id;
            this.categoryName = categoryName;
            this.imgage = imgage;
        }
    }
}