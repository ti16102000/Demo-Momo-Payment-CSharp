using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMomo.Controllers
{
    public class MomoController : Controller
    {
        // GET: Momo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MomoWithPayment()
        {
            var link = new MomoService().CreateOrderByMomo(Guid.NewGuid(), 10000);
            return Redirect(link.ToString());
        }
        public ActionResult MomoCallBack(string amount, string extraData, string signature) //params do not important, you can delete these params
        {
            //string[] words = extraData.Split(',');

            //var user = ApiService.GetIdLogin(words[2]);

            //if (ApiService.AcceptOrder(new OrderVipDTO()
            //{
            //    PVipID = Int32.Parse(words[0]),
            //    PaymentID = Int32.Parse(words[1]),
            //    UserID = user.ID,
            //    OrdPrice = Int32.Parse(amount)
            //}
            return RedirectToAction("Success", new { code = signature });
        }
        public ActionResult Success(string code)
        {
            return View();
        }
    }
}