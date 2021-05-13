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
    public class OrderFigureController : BaseController
    {
        List<Order> lstO = new List<Order>();
        // GET: OrderFigure
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            List<Account> lsta = new List<Account>(); // = new AccountHandle().GetListAccount();
            List<int> listId = new List<int>();//= new BranchHandle().GetListIDOrderInBranch(CommonConstants.nameBr.Split('-').ElementAt(1),lsta);

            lstO = new OrderFigureHandle().GetListOrder();


            IEnumerable<Order> model = lstO.OrderByDescending(x => x.Id).ToPagedList(page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(string Code)
        {
            Order o = new Order();
            lstO = new OrderFigureHandle().GetListOrder();
            int vitri = new OrderFigureHandle().GetIndex(lstO, Code);
            if (vitri != -1)
            {

                 o = lstO[vitri];
            }
            return View(o);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Order order)
        {
            List<Account> lsta = new List<Account>(); // = new AccountHandle().GetListAccount();
            List<int> listId = new List<int>();//= new BranchHandle().GetListIDOrderInBranch(CommonConstants.nameBr.Split('-').ElementAt(1),lsta);
            List<KeyFire> lstKey = new List<KeyFire>();
            lsta = new AccountHandle().GetListAccount();

                lstO = new OrderFigureHandle().GetListOrder();
                lstKey = new OrderFigureHandle().GetListKeyFire();
            

            int vitri = new OrderFigureHandle().GetIndex(lstO, order.Code);
            if (vitri != -1)
            {

                Order o = lstO[vitri];
                string key = lstKey[vitri].Key;
                if (o != null)
                {
                    var user = new AccountHandle().GetAccount(o.IdCustomer.ToString(), lsta);
                    bool result = new OrderFigureHandle().SetTypeOrder(user, o, Int32.Parse(order.Status), key);
                    if (result)
                    {
                        SetAlert("Cập nhật trạng thái đơn hàng thành công", "success");
                        return Redirect("/OrderFigure/Index");
                    }
                    else { ModelState.AddModelError("", "Cập nhật trạng thái đơn hàn thất bại"); }
                    return Redirect("/OrderFigure/Index");
                }
            }
            return Redirect("/OrderFigure/Index");
        }
    }
}