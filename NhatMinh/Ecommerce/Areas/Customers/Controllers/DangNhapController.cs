using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Areas.Customers.Controllers
{
    public class DangNhapController : Controller
    {
        DBEcommerce db = new DBEcommerce();
        [HttpGet]
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(FormCollection f)
        {

            try
            {
                KhachHang kh = new KhachHang();
                int a = int.Parse(f["txtgioiTinh"].ToString());
                kh.HoVaTen = f["txtHoVaTen"].ToString();
                kh.TaiKhoanKH = f["txtTenDangNhap"].ToString();
                kh.MatKhauKH = f["txtMatKhau"].ToString();
                if (a == 0)
                    kh.GioiTinh = true;
                else
                    kh.GioiTinh = false;

                //kh.GioiTinh = bool.Parse(f["txtGioiTinh"].ToString());
                kh.Email = f["txtEmail"].ToString();
                kh.DiaChi = f["txtDiaChi"].ToString();
                kh.SDT = f["txtSDT"].ToString();
                kh.TrangThai = 0;
                db.KhachHang.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DangKiThanhCong", "Error");
            }
            catch (Exception)
            {
                return RedirectToAction("Error404", "Error");
            }
        }
        // GET: Customers/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(FormCollection f)
        {

            // Kiểm tra tên đăng nhập và mật khẩu
            string ssTaiKhoan = f["txtTaiKhoan"].ToString();
            string ssMatKhau = f["txtMatKhau"].ToString();
            if (ssTaiKhoan == "" & ssMatKhau == "")
            {
                ModelState.AddModelError("", "Vui loàng nhập tên đăng nhập và mật khẩu của bạn !");
            }
            else if (ssTaiKhoan == "")
            {
                ModelState.AddModelError("", "Bạn không được bỏ trống tên đăng nhập !");
            }
            else if (ssMatKhau == "")
            {
                ModelState.AddModelError("", "Bạn không được bỏ trống mật khẩu !");
            }
            else
            {
                KhachHang kh = db.KhachHang.FirstOrDefault(n => n.TaiKhoanKH == ssTaiKhoan & n.MatKhauKH == ssMatKhau);
                if (kh == null)
                {
                    ModelState.AddModelError("", "Tài khoản không hợp lệ !");
                    return View();
                }
                else if (kh.TrangThai == 1)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa !");
                }
                else
                {
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult TaiKhoanCaNhan(string TkKhachHang)
        {
            if (TkKhachHang == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            KhachHang khachHang = db.KhachHang.Find(TkKhachHang);
            if (khachHang == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaiKhoanCaNhan([Bind(Include = "TaiKhoanKH,MatKhauKH,HoVaTen,SDT,Email,GioiTinh,DiaChi,TrangThai")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                Session["TaiKhoan"] = khachHang;
                return RedirectToAction("Index","Home");
            }
            return View(khachHang);
        }


    }
}