using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Models
{
    public class Account
    {


        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string img { get; set; }

        public Account() { }
        public Account(string id, string username, string password, string gender, string email, string phone, string name, string address, string type, string img)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.gender = gender;
            this.email = email;
            this.phone = phone;
            this.name = name;
            this.address = address;
            this.type = type;
            this.img = img;
        }
    }
}