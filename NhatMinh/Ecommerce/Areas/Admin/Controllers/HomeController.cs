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
        DBViettelStore db = new DBViettelStore();
        // GET: Admin/Home
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var Listdienthoaiall = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    iSoLuong = ChiTietSP.SoLuong,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(Listdienthoaiall.ToPagedList(pageNumber, pageSize));
        }
    }
}