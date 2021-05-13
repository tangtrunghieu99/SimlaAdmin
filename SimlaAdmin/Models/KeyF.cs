using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Models
{
    public class KeyFire
    {
        public string Key { get; internal set; }
        public string code { get; internal set; }
        public KeyFire() { }
        public KeyFire(string key, string code)
        {
            Key = key;
            this.code = code;
        }
    }
}