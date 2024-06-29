using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using Microsoft.Ajax.Utilities;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        private DBEcommerce db = new DBEcommerce();

        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            return View(db.KhachHang.ToList());
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaiKhoanKH,MatKhauKH,HoVaTen,SDT,Email,GioiTinh,DiaChi,TrangThai")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: Admin/KhachHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaiKhoanKH,MatKhauKH,HoVaTen,SDT,Email,GioiTinh,DiaChi,TrangThai")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                KhachHang khachHang = db.KhachHang.Find(id);
                db.KhachHang.Remove(khachHang);
                db.SaveChanges();

                #region Kiểm tra đăng nhập khách hàng và xóa session tương ứng
                //Kiểm tra người dùng đã đăng nhập chưa?
                if (Session["TaiKhoan"] != null)
                {
                    KhachHang kh = (KhachHang)Session["TaiKhoan"];
                    if (kh != null && kh.TaiKhoanKH == khachHang.TaiKhoanKH)
                    {
                        Session["TaiKhoan"] = null;
                    }
                }

                #endregion

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorKey", "Error");
            }

        }
        // Khóa Tài Khoản
        public ActionResult KhoaTaiKhoan(string sMakhachHang)
        {
            KhachHang kh = db.KhachHang.SingleOrDefault(n => n.TaiKhoanKH == sMakhachHang);
            kh.TrangThai = 1;
            db.SaveChanges();
            #region Kiểm tra đăng nhập khách hàng và xóa session tương ứng
            //Kiểm tra người dùng đã đăng nhập chưa?
            if (Session["TaiKhoan"] != null)
            {
                KhachHang khSesion = (KhachHang)Session["TaiKhoan"];
                if (kh != null && kh.TaiKhoanKH == khSesion.TaiKhoanKH)
                {
                    Session["TaiKhoan"] = null;
                }
            }
            #endregion
            return RedirectToAction("Index", "KhachHang");
        }
        // Mở Tài Khoản
        public ActionResult MoTaiKhoan(string sMakhachHang)
        {
            KhachHang kh = db.KhachHang.SingleOrDefault(n => n.TaiKhoanKH == sMakhachHang);
            kh.TrangThai = 0;
            db.SaveChanges();
            return RedirectToAction("Index", "KhachHang");
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
