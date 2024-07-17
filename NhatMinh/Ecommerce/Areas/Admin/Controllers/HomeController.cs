using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using Ecommerce.Models.ViewModel;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        DBEcommerce db = new DBEcommerce();
        // GET: Admin/Home
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var Listdienthoaiall = db.SanPham
             .GroupJoin(
                 db.ChiTietSP,
                 SanPham => SanPham.MaSanPham,
                 ChiTietSP => ChiTietSP.MaSanPham,
                 (SanPham, ChiTietSPs) => new { SanPham, ChiTietSPs }
             )
             .SelectMany(
                 x => x.ChiTietSPs.DefaultIfEmpty(),
                 (x, ChiTietSP) => new HienThiSanPham
                 {
                     iMaSanPham = x.SanPham.MaSanPham,
                     iRom = ChiTietSP != null ? ChiTietSP.Rom : 0,
                     iRam = ChiTietSP != null ? ChiTietSP.Ram : 0,
                     sTenMauSac = ChiTietSP != null ? ChiTietSP.MauSac.TenMauSac : null,
                     sTenSanPham = x.SanPham.TenSanPham,
                     sAnhBia = x.SanPham.AnhBia,
                     dGiaBan = ChiTietSP != null ? ChiTietSP.GiaBan : 0,
                     iSoLuong = ChiTietSP != null ? ChiTietSP.SoLuong : 0,
                     sMoTa = x.SanPham.ThongTinThemVeSP,
                     iMoi = ChiTietSP != null ? ChiTietSP.Moi : 0
                 }
             )
             .ToList()
             .OrderByDescending(n=>n.iMaSanPham);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(Listdienthoaiall.ToPagedList(pageNumber, pageSize));
        }
    }
}