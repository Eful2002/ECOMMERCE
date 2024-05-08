using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        private DBViettelStore db = new DBViettelStore();

        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            return View(db.NhanVien.ToList());
        }

        // GET: Admin/NhanVien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaiKhoanNV,MatKhauNV,HoVaTen,SDT,Email,GioiTinh,DiaChi,TrangThai,NgaySinh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanVien.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaiKhoanNV,MatKhauNV,HoVaTen,SDT,Email,GioiTinh,DiaChi,TrangThai,NgaySinh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                NhanVien nhanVien = db.NhanVien.Find(id);
                db.NhanVien.Remove(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorKey", "Error");
            }
           
        }

        // Khóa Tài Khoản
        public ActionResult KhoaTaiKhoan(string sMaNhanVien)
        {
            NhanVien kh = db.NhanVien.SingleOrDefault(n => n.TaiKhoanNV == sMaNhanVien);
            kh.TrangThai = 1;
            db.SaveChanges();
            return RedirectToAction("Index", "NhanVien");
        }
        // Mở Tài Khoản
        public ActionResult MoTaiKhoan(string sMaNhanVien)
        {
            NhanVien kh = db.NhanVien.SingleOrDefault(n => n.TaiKhoanNV == sMaNhanVien);
            kh.TrangThai = 0;
            db.SaveChanges();
            return RedirectToAction("Index", "NhanVien");
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
