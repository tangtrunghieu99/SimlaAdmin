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
    public class AccountHandle
    {
        public int CheckLogin(string user, string pass,List<Account> lstAcc)
        {
            Account a = new Account();
            for (int i = 0; i < lstAcc.Count; i++)
            {
                if (lstAcc[i].username == user)
                {
                    a = lstAcc[i];
                    break;
                }
            }
            if (a.username != null)
            {
                if (a.type == "1" || a.type == "2")
                {
                    if (a.username == user && a.password == pass)
                    {
                        return 1;
                    }
                    return -1;
                }

            }
            return 0;
        }

        public List<Account> GetListAccount()
        {
            new FirebaseInit().Init();
            List<Account> temp = new List<Account>();
            FirebaseResponse res = CommonConstants.client.Get(@"Account");
            Dictionary<string, Account> data = JsonConvert.DeserializeObject<Dictionary<string, Account>>(res.Body.ToString());
            foreach (var item in data)
            {
                Account a = new Account(item.Value.id, item.Value.username, item.Value.password, 
                    item.Value.gender, item.Value.email, item.Value.phone, item.Value.name,
                    item.Value.address, item.Value.type, item.Value.img);
                temp.Add(a);
            }

            return temp;
        }
        public Account GetAccount(string id ,List<Account> lstA)
        {
            for (int i = 0; i < lstA.Count; i++)
            {
                if(lstA[i].id == id)
                {
                    return lstA[i];
                }
            }
            return null;
        }
        public Account GetAccountByUsername(string username, List<Account> lstA)
        {
            for (int i = 0; i < lstA.Count; i++)
            {
                if (lstA[i].username == username)
                {
                    return lstA[i];
                }
            }
            return null;
        }



        public bool AddAccount(Account f, string username)
        {
            new FirebaseInit().Init();
            FirebaseResponse response = CommonConstants.client.Set("Account/" + username, f);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
        public bool UpdateAccount(Account f, string username)
        {
            new FirebaseInit().Init();
            FirebaseResponse response = CommonConstants.client.Update("Account/" + username, f);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
        public bool DeleteAccount(string username)
        {
            new FirebaseInit().Init();
            FirebaseResponse response = CommonConstants.client.Delete("Account/" + username);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}