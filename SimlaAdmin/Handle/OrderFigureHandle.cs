using FireSharp.Response;
using Newtonsoft.Json;
using SimlaAdmin.Common;
using SimlaAdmin.Firebase;
using SimlaAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Handle
{
    public class OrderFigureHandle
    {
        FirebaseInit fb = new FirebaseInit();
        public List<Order> GetListOrder()
        {
            fb.Init();

            List<Order> temp = new List<Order>();

            FirebaseResponse res = CommonConstants.client.Get(@"OrderInfo");
            // string a = "{"21614268331423101":{"date":"22:52:11 25 - 02 - 2021","id":"0","idCus":"2","listfoodid":"11","listprice":"25000","listquan":"1","status":"0"},"21614920686884296":{"date":"23:04:46 04 - 03 - 2021","id":"1","idCus":"2","listfoodid":"13,11,19","listprice":"25000,25000,25000","listquan":"9,1,1","status":"2"}}";
            Dictionary<string, Dictionary<string, Order>> data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Order>>>(res.Body.ToString());
            foreach (var item in data)
            {
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Order o = new Order(item.Value.ElementAt(i).Value.Id, item.Value.ElementAt(i).Value.IdCustomer,
                        item.Value.ElementAt(i).Value.Listfoodid, item.Value.ElementAt(i).Value.Listquan,
                        item.Value.ElementAt(i).Value.Listprice, item.Value.ElementAt(i).Value.Status,
                        item.Value.ElementAt(i).Value.Date, item.Value.ElementAt(i).Value.Code, item.Value.ElementAt(i).Value.Discount, item.Value.ElementAt(i).Value.Total
                       );
                    temp.Add(o);
                }
            }

            return temp;

        }
        public List<KeyFire> GetListKeyFire()
        {
            fb.Init();

            List<KeyFire> temp = new List<KeyFire>();
            FirebaseResponse res = CommonConstants.client.Get(@"OrderInfo");
            // string a = "{"21614268331423101":{"date":"22:52:11 25 - 02 - 2021","id":"0","idCus":"2","listfoodid":"11","listprice":"25000","listquan":"1","status":"0"},"21614920686884296":{"date":"23:04:46 04 - 03 - 2021","id":"1","idCus":"2","listfoodid":"13,11,19","listprice":"25000,25000,25000","listquan":"9,1,1","status":"2"}}";
            Dictionary<string, Dictionary<string, Order>> data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Order>>>(res.Body.ToString());

            foreach (var item in data)
            {

                for (int i = 0; i < item.Value.Count; i++)
                {
                    KeyFire k = new KeyFire(item.Value.ElementAt(i).Key, item.Value.ElementAt(i).Value.Code);
                    temp.Add(k);

                }

            }

            return temp;
        }

        public int GetIndex(List<Order> lstO, string code)
        {
            int vitri = -1;
            for (int i = 0; i < lstO.Count; i++)
            {
                if (lstO[i].Code == code)
                {
                    vitri = i;
                }
            }
            return vitri;

        }

        public bool SetTypeOrder(Account a, Order o, int status, string key)
        {
            new FirebaseInit().Init();
            o.Status = status.ToString();
            FirebaseResponse response = CommonConstants.client.Set("OrderInfo/" + a.id + "/" + key, o);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }

    }
}