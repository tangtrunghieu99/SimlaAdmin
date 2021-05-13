using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SimlaAdmin.Common;
using SimlaAdmin.Handle;
using SimlaAdmin.Models;

namespace SimlaAdmin.Controllers
{
    public class UserController :   BaseController
    {
        // GET: Admin/User
       
        public ActionResult Index(int page=1,int pagesize=5)
        {
            List<Account> lsta = new AccountHandle().GetListAccount();
            IEnumerable<Account> model = lsta.OrderByDescending(x => x.id).ToPagedList(page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Tao()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            List<Account> lsta = new AccountHandle().GetListAccount();
            var user = new AccountHandle().GetAccount(id.ToString(), lsta);
            SetGender(user.gender);
            return View(user);
        }
        [HttpPost]
        public ActionResult Tao(Account acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountHandle();
                List<Account> lsta = new AccountHandle().GetListAccount();
                int id = Int32.Parse(lsta[lsta.Count - 1].id) + 1;
                acc.img = "null";
                acc.id = id.ToString();

                SetGender(acc.gender);
                bool kq = dao.AddAccount(acc, acc.username);
                if (kq)
                {
                    SetAlert("Thêm người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm người dùng thất bại");
                }
            }
            return View(acc);
        }
        [HttpPost]
        public ActionResult Edit(Account acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountHandle();
                List<Account> lsta = new AccountHandle().GetListAccount();
                //int id = Int32.Parse(lsta[lsta.Count - 1].id) + 1;
                acc.img = "null";
                SetGender(acc.gender);
                var result = dao.UpdateAccount(acc, acc.username);
                if (result)
                {
                    SetAlert("Chỉnh sửa người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉnh sửa người dùng thất bại");

                }
            }
            return View("Index");
        }

        public void SetGender(string sl = null)
        {

            var b = new SelectList(new List<SelectListItem>
            {
                new SelectListItem {Text = "Nam",Value="Nam"},
                new SelectListItem {Text = "Nữ",Value="Nữ"},
            }, "Value", "Text", sl);

            ViewBag.Gender = b; // tên này phải trùng với tên lúc khai báo giới tính ở sql
        }
        public ActionResult Delete(int id)
        {
            List<Account> lsta = new AccountHandle().GetListAccount();
            var user = new AccountHandle().GetAccount(id.ToString(), lsta);
            bool result = new AccountHandle().DeleteAccount(user.username.ToString());
            if (result)
            {
                SetAlert("Xóa người dùng thành công", "success");
                return Redirect("/User/Index");
            }
            else { ModelState.AddModelError("", "Xóa tài khoản khoản thất bại"); }
            return Redirect("/User/Index");
        }
    }
}