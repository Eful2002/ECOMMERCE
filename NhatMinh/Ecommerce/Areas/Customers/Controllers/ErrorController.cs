using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Customers.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult KhongDuSoLuong()
        {
            return View();
        }
        public ActionResult GioHangTrong()
        {
            return View();
        }
        public ActionResult DatHangThanhCong()
        {
            return View();
        }
        public ActionResult DatHangThatBai()
        {
            return View();
        }
        public ActionResult DangKiThanhCong()
        {
            return View();
        }
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult CapNhatThanhCong()
        {
            return View();
        }
    }
}