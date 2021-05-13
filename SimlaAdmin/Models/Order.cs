using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public string Id { get;  set; }
        [JsonProperty("idCus")]
        public string IdCustomer { get;  set; }
        [JsonProperty("listfoodid")]
        public string Listfoodid { get;  set; }
        [JsonProperty("listquan")]
        public string Listquan { get;  set; }
        [JsonProperty("listprice")]
        public string Listprice { get;  set; }
        [JsonProperty("status")]
        public string Status { get;  set; }

        [JsonProperty("date")]
        public string Date { get;  set; }

        [JsonProperty("code")]
        public string Code { get;  set; }

        [JsonProperty("discount")]
        public string Discount { get;  set; }

        [JsonProperty("totalPrice")]
        public string Total { get;  set; }


        public Order(string id, string idCustomer, string listfoodid, string listquan, string listprice, string status, string date, string code, string dis, string total)
        {
            this.Id = id;
            this.IdCustomer = idCustomer;
            this.Listfoodid = listfoodid;
            this.Listquan = listquan;
            this.Listprice = listprice;
            this.Status = status;
            this.Date = date;
            this.Code = code;
            this.Discount = dis;
            this.Total = total;
        }
        public Order() { }
    }
   
}