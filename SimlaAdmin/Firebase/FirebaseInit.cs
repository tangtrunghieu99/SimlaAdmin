using SimlaAdmin.Models;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimlaAdmin.Common;
namespace SimlaAdmin.Firebase
{
    public class FirebaseInit
    {
        static IFirebaseConfig icf = new FirebaseConfig
        {
            AuthSecret = "5ss9ONxYQgxuyjadk1y3YnroKDszDlgWBEH7jZm8",
            BasePath = "https://figureappflutter-d42d1-default-rtdb.firebaseio.com/"
        };

        
        public void Init()
        {
            CommonConstants.client = new FirebaseClient(icf);

        }

       
    }
}