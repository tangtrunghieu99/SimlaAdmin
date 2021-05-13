using SimlaAdmin.Common;
using SimlaAdmin.Firebase;
using SimlaAdmin.Models;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Handle
{
    public class CategoryHandle
    {
        public List<Category> GetListCategory()
        {
            new FirebaseInit().Init();
            List<Category> temp = new List<Category>();
            FirebaseResponse res = CommonConstants.client.Get(@"Category");
            //  Dictionary<string, Food> data = JsonConvert.DeserializeObject<Dictionary<string, Food>>(res.Body.ToString());
            List<Category> data = JsonConvert.DeserializeObject<List<Category>>(res.Body.ToString());
            foreach (var item in data)
            {
                Category f = new Category(item.id, item.categoryName, item.imgage);
                temp.Add(f);
            }
            return temp;
        }
    }
}