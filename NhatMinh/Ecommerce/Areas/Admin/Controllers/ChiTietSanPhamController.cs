using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        private DBEcommerce db = new DBEcommerce();

        public ActionResult Create(int maSanPham)
        {
            ViewBag.MaMauSac = new SelectList(db.MauSac, "MaMauSac", "TenMauSac");
            ViewBag.MaSanPham = maSanPham;
            ViewBag.TenSanPham = db.SanPham.FirstOrDefault(n => n.MaSanPham == maSanPham).TenSanPham;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaSanPham,MaMauSac,Rom,Ram,GiaGoc,GiaBan,SoLuong")] ChiTietSP chiTietSP)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Kiểm tra sản phẩm có đại diện hiển thị lên không?
                    var chiTietSPCheck = db.ChiTietSP.FirstOrDefault(n => n.MaSanPham == chiTietSP.MaSanPham && n.Moi == 1);
                    if (chiTietSPCheck == null)
                    {
                        chiTietSP.Moi = 1;
                    }
                    chiTietSP.SoLuongDaBan = 0;

                    db.ChiTietSP.Add(chiTietSP);
                    await db.SaveChangesAsync();
                }

                ViewBag.MaMauSac = new SelectList(db.MauSac, "MaMauSac", "TenMauSac", chiTietSP.MaMauSac);
                ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "TenSanPham", chiTietSP.MaSanPham);

                return RedirectToAction("Edit", "SanPhams", new { id = chiTietSP.MaSanPham });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Edit", "SanPhams", new { id = chiTietSP.MaSanPham });
            }
        }

        public async Task<ActionResult> Edit(int MaSanPham, int MaMauSac, int Rom, int Ram)
        {

            ChiTietSP chiTietSP = await db.ChiTietSP.FirstOrDefaultAsync(n => n.MaSanPham == MaSanPham &&
                                                                         n.MaMauSac == MaMauSac &&
                                                                         n.Rom == Rom &&
                                                                         n.Ram == Ram);

            if (chiTietSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMauSac = new SelectList(db.MauSac, "MaMauSac", "TenMauSac", chiTietSP.MaMauSac);
            ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "TenSanPham", chiTietSP.MaSanPham);
            return View(chiTietSP);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaSanPham,MaMauSac,Rom,Ram,GiaGoc,GiaBan,SoLuong")] ChiTietSP chiTietSP)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(chiTietSP).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.MaMauSac = new SelectList(db.MauSac, "MaMauSac", "TenMauSac", chiTietSP.MaMauSac);
                ViewBag.MaSanPham = new SelectList(db.SanPham, "MaSanPham", "TenSanPham", chiTietSP.MaSanPham);
                return RedirectToAction("Edit", "SanPhams", new { id = chiTietSP.MaSanPham });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Edit", "SanPhams", new { id = chiTietSP.MaSanPham });
            }

        }

        public async Task<ActionResult> DeleteConfirmed(int MaSanPham, int MaMauSac, int Rom, int Ram)
        {

            ChiTietSP chiTietSP = await db.ChiTietSP.FirstOrDefaultAsync(n => n.MaSanPham == MaSanPham &&
                                                                         n.MaMauSac == MaMauSac &&
                                                                         n.Rom == Rom &&
                                                                         n.Ram == Ram);
            try
            {
                db.ChiTietSP.Remove(chiTietSP);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "SanPhams", new { id = chiTietSP.MaSanPham });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Edit", "SanPhams", new { id = chiTietSP.MaSanPham });
            }
        }
    }
}