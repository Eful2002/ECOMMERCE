using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private DBEcommerce db = new DBEcommerce();

        // GET: Admin/SanPhams
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.HangSanXuat).Include(s => s.HinhAnh).Include(s => s.LoaiSanPham);
            return View(sanPham.ToList());
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaHangSX = new SelectList(db.HangSanXuat, "MaHangSX", "TenHangSX");
            ViewBag.MaSanPham = new SelectList(db.HinhAnh, "MaSanPham", "HinhAnh1");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham, "MaLoaiSP", "TenLoaiSP");
            ViewBag.MauSac = db.MauSac.ToList();

            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,AnhBia,ManHinh,CPU,Camera_Truoc,Camera_Sau,HeDieuHanh,QuayPhim,Pin,ThoiGianBaoHanh,ThongTinThemVeSP,TrangThai,MaLoaiSP,MaHangSX")] SanPham sanPham, HttpPostedFileBase AnhBiaFile)
        {
            if (ModelState.IsValid)
            {
                if (AnhBiaFile != null && AnhBiaFile.ContentLength > 0)
                {
                    // Lấy tên tệp và đường dẫn lưu trữ
                    var fileName = Path.GetFileName(AnhBiaFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Assets/Customers/img/HinhAnhSanPham/"), fileName);

                    // Lưu tệp vào đường dẫn
                    AnhBiaFile.SaveAs(path);

                    // Cập nhật thuộc tính AnhBia với đường dẫn tệp
                    sanPham.AnhBia = fileName;
                }

                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.MaHangSX = new SelectList(db.HangSanXuat, "MaHangSX", "TenHangSX", sanPham.MaHangSX);
            ViewBag.MaSanPham = new SelectList(db.HinhAnh, "MaSanPham", "HinhAnh1", sanPham.MaSanPham);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHangSX = new SelectList(db.HangSanXuat, "MaHangSX", "TenHangSX", sanPham.MaHangSX);
            ViewBag.MaSanPham = new SelectList(db.HinhAnh, "MaSanPham", "HinhAnh1", sanPham.MaSanPham);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,AnhBia,ManHinh,CPU,Camera_Truoc,Camera_Sau,HeDieuHanh,QuayPhim,Pin,ThoiGianBaoHanh,ThongTinThemVeSP,TrangThai,MaLoaiSP,MaHangSX")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHangSX = new SelectList(db.HangSanXuat, "MaHangSX", "TenHangSX", sanPham.MaHangSX);
            ViewBag.MaSanPham = new SelectList(db.HinhAnh, "MaSanPham", "HinhAnh1", sanPham.MaSanPham);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
