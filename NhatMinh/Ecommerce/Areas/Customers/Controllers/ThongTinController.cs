using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Customers.Controllers
{
    public class ThongTinController : Controller
    {
        // GET: Customers/ThongTin
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult ThongTin()
        {
            return View();
        }
        public ActionResult HuongDanDatHang()
        {
            return View();
        }
    }
}