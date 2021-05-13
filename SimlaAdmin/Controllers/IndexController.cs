using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimlaAdmin.Controllers
{
    public class IndexController : BaseController
    {
        // GET: Admin/Test
        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}