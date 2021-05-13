
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimlaAdmin.Common;
using SimlaAdmin.Handle;
using SimlaAdmin.Models;
namespace WebSiteCoffeeShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        List<Account> lstAcc = new List<Account>();
        public ActionResult LoginAcc()
        {
            return View();
        }
        public ActionResult Login(LoginModel loginModel)
        {
            int kq = 0;
            lstAcc = new AccountHandle().GetListAccount();

            if (ModelState.IsValid)
            {
                kq = new AccountHandle().CheckLogin(loginModel.userName, loginModel.passWord, lstAcc);
                if (kq == 1)
                {
                    Account user = new AccountHandle().GetAccountByUsername(loginModel.userName, lstAcc);
                    var accSession = new AccLogin();
                    accSession.UserName = user.username;
                    accSession.AccID = Int32.Parse(user.id);
                    CommonConstants.typeAcc = int.Parse(user.type);
                    CommonConstants.nameBr = user.name;

                    Session.Add(CommonConstants.Admin_Session, accSession);

                    return RedirectToAction("AdminIndex", "Index");
                }
                else if (kq == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            return View("LoginAcc");
        }
    }
        
    }
