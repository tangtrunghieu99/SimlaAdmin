using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Models
{
    public class Food
    {
        [JsonProperty("id")]
        public string id{ get; set;}

        [JsonProperty("idCategory")]
        public string idCategory { get; set;}

        [JsonProperty("name")]
        public string name { get; set;}

        [JsonProperty("price")]
        public string price { get; set;}

        [JsonProperty("imgUrl")]
        public string imgUrl { get; set;}

        [JsonProperty("view")]
        public int view { get; set;}

        [JsonProperty("heart")]
        public int heart { get; set;}

        [JsonProperty("star")]
        public  string star{ get; set;}

        [JsonProperty("like")]
        public int like{ get; set;}

        /// moi them vao 14-1-2021
        /// 
        [JsonProperty("detail")]
        public  string detail{ get; set;}

        [JsonProperty("calo")]
        public string calo{ get; set;}

        [JsonProperty("info")]
        public string info{ get; set;}

        [JsonProperty("ingredient")]
        public string ingredient{ get; set;}

        public Food() { }
        public Food(string id, string idCategory, string name, string price, string imgUrl, int view, int heart, string star, int like, string detail, string calo, string info, string ingredient)
        {
            this.id = id;
            this.idCategory = idCategory;
            this.name = name;
            this.price = price;
            this.imgUrl = imgUrl;
            this.view = view;
            this.heart = heart;
            this.star = star;
            this.like = like;
            this.detail = detail;
            this.calo = calo;
            this.info = info;
            this.ingredient = ingredient;
        }
    }
}