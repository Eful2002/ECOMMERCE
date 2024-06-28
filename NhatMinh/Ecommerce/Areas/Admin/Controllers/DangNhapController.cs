using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        DBEcommerce db = new DBEcommerce();
        #region controll Đăng kí và đăng nhập
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
                NhanVien nv = db.NhanVien.FirstOrDefault(n => n.TaiKhoanNV == ssTaiKhoan & n.MatKhauNV == ssMatKhau);
                if (nv == null)
                {
                    ModelState.AddModelError("", "Tài khoản không hợp lệ !");
                    return View();
                }
                else if (nv.TrangThai == 1)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa !");
                }
                else
                {
                    Session["TaiKhoanNV"] = nv;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoanNV"] = null;
            return RedirectToAction("DangNhap", "DangNhap");
        }
        #endregion
    }
}