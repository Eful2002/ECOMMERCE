using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ViettelStore.Areas.Admin.Controllers
{
    public class ChiTietSPController : Controller
    {
        private DBEcommerce db = new DBEcommerce();

        // GET: Admin/ChiTietSP
        public ActionResult Create()
        {
            ViewBag.MaMauSac = new SelectList(db.MauSac, "MaMauSac", "TenMauSac");
            ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "TenSanPham");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaSanPham,MaMauSac,Rom,Ram,GiaGoc,GiaBan,SoLuong,SoLuongDaBan,Moi")] ChiTietSP chiTietSP)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietSP.Add(chiTietSP);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaMauSac = new SelectList(db.MauSac, "MaMauSac", "TenMauSac", chiTietSP.MaMauSac);
            ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "TenSanPham", chiTietSP.MaSanPham);
            return View(chiTietSP);
        }

    }
}