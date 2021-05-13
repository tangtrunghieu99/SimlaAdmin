using SimlaAdmin.Handle;
using SimlaAdmin.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BFoodAdmin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var ca = new CategoryHandle();
            List<Category> lstCate = ca.GetListCategory();
            IEnumerable<Category> model = lstCate.OrderBy(x => x.id).ToPagedList(page, pagesize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}