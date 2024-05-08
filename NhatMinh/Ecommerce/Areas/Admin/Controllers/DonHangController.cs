using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        DBViettelStore db = new DBViettelStore();

        #region List Đơn Hàng
        public ActionResult DonHangAll()
        {
            var lstdonhang = db.DonHang.ToList();
            return View(lstdonhang);
        }
        public ActionResult DonHangXacNhan()
        {
            var lstdonhangxacnhan = db.DonHang.Where(n => n.TrangThai == 0).ToList();
            return View(lstdonhangxacnhan);
        }
        public ActionResult DonHangDangGiao()
        {
            var lstdonhangdanggiao = db.DonHang.Where(n => n.TrangThai == 1).ToList();
            return View(lstdonhangdanggiao);
        }
        public ActionResult DonHangDaGiao()
        {
            var lstdonhangdagiao = db.DonHang.Where(n => n.TrangThai == 2).ToList();
            return View(lstdonhangdagiao);
        }
        public ActionResult DonHangDaHuy()
        {
            var lstdonhangdahuy = db.DonHang.Where(n => n.TrangThai == 3).ToList();
            return View(lstdonhangdahuy);
        }
        #endregion

        #region Cập Nhật Trạng Thái Đơn Hàng / Hay Duyệt Đơn
        public ActionResult DangGiao(int iMaDonHang)
        {
            DonHang dh = db.DonHang.SingleOrDefault(n => n.MaDonHang == iMaDonHang);
            dh.TrangThai = 1;
            db.SaveChanges();
            return RedirectToAction("DonHangXacNhan","DonHang");
        }
        public ActionResult DaGiao(int iMaDonHang)
        {
            DonHang dh = db.DonHang.SingleOrDefault(n => n.MaDonHang == iMaDonHang);
            dh.TrangThai = 2;
            db.SaveChanges();
            return RedirectToAction("DonHangDangGiao", "DonHang");
        }
        public ActionResult DaHuy(int iMaDonHang)
        {
            DonHang dh = db.DonHang.SingleOrDefault(n => n.MaDonHang == iMaDonHang);
            dh.TrangThai = 3;
            db.SaveChanges();
            #region Cộng Lại Số Lượng
            var ctdh = db.ChiTietDonHang.Where(n => n.MaDonHang == iMaDonHang).ToList();
            foreach (var item in ctdh)
            {
                ChiTietSP ctsp = db.ChiTietSP.SingleOrDefault(n => n.MaSanPham == item.MaSanPham & n.MaMauSac == item.MaMauSac & n.Rom == item.Rom & n.Ram == item.Ram);
                ctsp.SoLuong += item.SoLuongMua;
                ctsp.SoLuongDaBan -= item.SoLuongMua;
                db.SaveChanges();
            }
            #endregion
            return RedirectToAction("DonHangDaHuy", "DonHang");
        }
        #endregion

        #region Xem Chi Tiet
        [HttpGet]
        public ActionResult XemChiTietDonHang(int? iMaDonHang)
        {
            // Kiểm tra MaDonHang có hợp lệ không
            if (iMaDonHang == null)
            {
                return RedirectToAction ("Error404", "Error");
            }
            DonHang model = db.DonHang.SingleOrDefault(n => n.MaDonHang == iMaDonHang);
            //Kiểm tra đơn hàng có tồn tại không
            if (model == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            //Lấy danh sách chi tiết đơn hàng để hiển thị cho người dùng thấy
            var lstChiTietDH = db.ChiTietDonHang.Where(n => n.MaDonHang == iMaDonHang);
            ViewBag.listchitietdonhang = lstChiTietDH;

            return View(model);
        }
        #endregion
    }
}