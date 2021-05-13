using PagedList;
using SimlaAdmin.Handle;
using SimlaAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimlaAdmin.Controllers
{
    public class FigleController : BaseController
    {
        // GET: Admin/Food
        List<Food> lsF = new List<Food>();
        public ActionResult DSFood(int page = 1, int pagesize = 10)
        {
            lsF = new FoodHandle().GetListFood();
            IEnumerable<Food> model = lsF.OrderByDescending(x => x.id).ToPagedList(page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Food()
        {
            SetViewBag();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Food(Food model)
        {
            lsF = new FoodHandle().GetListFood();
            Server.HtmlEncode(model.detail);
            if (ModelState.IsValid)
            {
                string id = (Int32.Parse(lsF[lsF.Count - 1].id) + 1).ToString();
                SetViewBag(Int32.Parse(model.idCategory));
                model.id = id;
                var kq = new FoodHandle().AddFood(model, id);
                if (kq)
                {
                    SetAlert("Thêm món thành công", "success");
                    return Redirect("/Food/DSFood");
                }
            }
            SetViewBag();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new FoodHandle();
            lsF = new FoodHandle().GetListFood();
            var food = dao.GetFood(id, lsF);
            SetViewBag(Int32.Parse(food.idCategory));
            return View(food);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Food model)
        {
            if (ModelState.IsValid)
            {
                SetViewBag(Int32.Parse(model.idCategory));
                var kq = new FoodHandle().UpdateFood(model, model.id);
                if (kq)
                {
                    SetAlert("Sửa món thành công", "success");
                    return Redirect("/Food/DSFood");
                }
            }
            SetViewBag();
            return View(model);
        }
        public void SetViewBag(int? selectedId = null)
        {
            //var dao = new CategoryDAO();
            List<Category> lstCate = new CategoryHandle().GetListCategory(); ;
            ViewBag.IDCategory = new SelectList(lstCate, "id", "categoryName", selectedId);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            bool result = new FoodHandle().DeleteFood(id.ToString());
            if (result)
            {
                SetAlert("Xóa món thành công", "success");
                return Redirect("/Food/DSFood"); ;
            }
            else { ModelState.AddModelError("", "Xóa món thất bại"); }
            return Redirect("/Food/DSFood"); ;
        }


    }
}