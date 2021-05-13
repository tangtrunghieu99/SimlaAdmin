using SimlaAdmin.Common;
using SimlaAdmin.Firebase;
using SimlaAdmin.Models;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using FireSharp;
using FireSharp.Config;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Handle
{
    public class FoodHandle
    {
        public List<Food> GetListFood()
        {
            new FirebaseInit().Init();
            List<Food> temp = new List<Food>();
            FirebaseResponse res = CommonConstants.client.Get(@"Figure");
            //  Dictionary<string, Food> data = JsonConvert.DeserializeObject<Dictionary<string, Food>>(res.Body.ToString());
            List<Food> data = JsonConvert.DeserializeObject<List<Food>>(res.Body.ToString());
            foreach (var item in data)
            {
                Food f = new Food(item.id, item.idCategory, item.name,
                    item.price, item.imgUrl, item.view, item.heart,
                    item.star, item.like, item.detail, item.calo,
                    item.info, item.ingredient);
                temp.Add(f);
            }
            return temp;
        }

        public List<Food> MostFavorite(List<Food> f)
        {
            List<Food> temp = new List<Food>();
            temp = f.OrderByDescending(e => e.heart).ToList();
            return temp.Take(5).ToList();
        }

        public Food GetFood(string id,List<Food> f)
        {
            Food t = new Food();
            for (int i = 0; i < f.Count; i++)
            {
                if (f[i].id == id)
                    t = f[i];
            }
            return t;
        }
        public bool AddFood(Food f,string id)
        {
            new FirebaseInit().Init();
            FirebaseResponse response = CommonConstants.client.Set("Figure/" + id,f);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
        public bool UpdateFood(Food f,string id)
        {
            new FirebaseInit().Init();
            FirebaseResponse response = CommonConstants.client.Update("Figure/" + id, f);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
        public bool DeleteFood(string id)
        {
            new FirebaseInit().Init();
            FirebaseResponse response = CommonConstants.client.Delete("Figure/" + id);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}