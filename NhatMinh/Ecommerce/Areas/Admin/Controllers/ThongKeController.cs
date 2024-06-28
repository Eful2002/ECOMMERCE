using System;
using System.Linq;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        DBEcommerce db = new DBEcommerce();
        public ActionResult Thongke()
        {
            //ViewBag.DoanhThuNgayHomNay = DoanhThuNgayHomNay();
            ViewBag.DoanhThuTong = DoanhThuTong();
            ViewBag.DoanhThuXacNhan = DoanhThuXacNhan();
            ViewBag.DoanhThuDangGiao = DoanhThuDangGiao();
            ViewBag.DoanhThuDaGiao = DoanhThuDaGiao();
            ViewBag.DoanhThuDaHuy = DoanhThuDaHuy();
            ViewBag.CountDonHang = CountDonHang();
            ViewBag.CountDonHangXacNhan = CountDonHangXacNhan();
            ViewBag.CountDonHangDangGiao = CountDonHangDangGiao();
            ViewBag.CountDonHangDaGiao = CountDonHangDaGiao();
            ViewBag.CountDonHangDaHuy = CountDonHangDaHuy();
            ViewBag.CountNhanVien = CountNhanVien();
            ViewBag.CountKhachHang = CountKhachHang();
            return View();
        }
        #region Tính Toán

        // Doanh thu tổng (Tổng thành tiền trong Bảng CTSP)
        public decimal DoanhThuTong()
        {
            decimal doanhthutong = db.ChiTietDonHang.Sum(n => n.ThanhTien).Value;
            return doanhthutong;
        }
        public decimal DoanhThuXacNhan()
        {
            try
            {
                decimal doanhthuxacnhan = (decimal)(from ctdh in db.ChiTietDonHang
                                                    join dh in db.DonHang
                                                    on ctdh.MaDonHang equals dh.MaDonHang
                                                    where dh.TrangThai == 0
                                                    group ctdh by dh.TrangThai into g
                                                    select g.Sum(n => n.ThanhTien)).FirstOrDefault();
                return doanhthuxacnhan;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
        public decimal DoanhThuDangGiao()
        {
            try
            {
                decimal doanhthuxacnhan = (decimal)(from ctdh in db.ChiTietDonHang
                                                    join dh in db.DonHang
                                                    on ctdh.MaDonHang equals dh.MaDonHang
                                                    where dh.TrangThai == 1
                                                    group ctdh by dh.TrangThai into g
                                                    select g.Sum(n => n.ThanhTien)).FirstOrDefault();
                return doanhthuxacnhan;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
        public decimal DoanhThuDaGiao()
        {
            try
            {
                decimal doanhthuxacnhan = (decimal)(from ctdh in db.ChiTietDonHang
                                                    join dh in db.DonHang
                                                    on ctdh.MaDonHang equals dh.MaDonHang
                                                    where dh.TrangThai == 2
                                                    group ctdh by dh.TrangThai into g
                                                    select g.Sum(n => n.ThanhTien)).FirstOrDefault();
                return doanhthuxacnhan;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
        public decimal DoanhThuDaHuy()
        {
            try
            {
                decimal doanhthuxacnhan = (decimal)(from ctdh in db.ChiTietDonHang
                                                    join dh in db.DonHang
                                                    on ctdh.MaDonHang equals dh.MaDonHang
                                                    where dh.TrangThai == 3
                                                    group ctdh by dh.TrangThai into g
                                                    select g.Sum(n => n.ThanhTien)).FirstOrDefault();
                return doanhthuxacnhan;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
        public decimal DoanhThuNgayHomNay()
        {
            //try
            //{
                string dt = "2021/08/22";
                //string dt = DateTime.Now.ToString("dd/MM/yyyy");
                decimal doanhthuHomNay = (decimal)(from ctdh in db.ChiTietDonHang
                                                    join dh in db.DonHang
                                                    on ctdh.MaDonHang equals dh.MaDonHang
                                                    where dh.NgayDat == DateTime.Parse(dt)
                                                    group ctdh by dh.TrangThai into g
                                                    select g.Sum(n => n.ThanhTien)).FirstOrDefault();
                return doanhthuHomNay;
            //}
            //catch (System.Exception)
            //{
            //    return 0;
            //}
        }
        #endregion
        #region Dếm Số Lượng
        public int CountDonHang()
        {
            int countdh = db.DonHang.Count();
            return countdh;
        }
        public int CountDonHangXacNhan()
        {
            int countdh = db.DonHang.Count(n => n.TrangThai == 0);
            return countdh;
        }
        public int CountDonHangDangGiao()
        {
            int countdh = db.DonHang.Count(n => n.TrangThai == 1);
            return countdh;
        }
        public int CountDonHangDaGiao()
        {
            int countdh = db.DonHang.Count(n => n.TrangThai == 2);
            return countdh;
        }
        public int CountDonHangDaHuy()
        {
            int countdh = db.DonHang.Count(n => n.TrangThai == 3);
            return countdh;
        }
        // Số lượng nhân viên và khách hàng
        public int CountNhanVien()
        {
            int countnv = db.NhanVien.Count();
            return countnv;
        }
        public int CountKhachHang()
        {
            int countnv = db.NhanVien.Count();
            return countnv;
        }
        #endregion
        #region Thống kê hôm nay
        // Sản Phẩm bán đượcs
        public ActionResult SanPhamBanDuoc()
        {
            string dt = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime datenow = DateTime.Now.Date;
           var dh = db.DonHang.Where(n=>n.NgayDat == DateTime.Now).ToList();
            return View(dh);
        }
        // Thống kê tháng năm
        public ActionResult TKThangNam(FormCollection f)
        {
            int thang = int.Parse(f["thang"]);
            int nam = int.Parse(f["nam"]);

            var dh = db.DonHang.Where(n => n.NgayDat.Month == thang & n.NgayDat.Year == nam).ToList();
            decimal tongtien = 0;
            foreach(var item in dh)
            {
                tongtien += decimal.Parse(item.ChiTietDonHang.Sum(n => n.ThanhTien).Value.ToString());
            }
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            ViewBag.tt = tongtien;
            #region Doanh thu cũ
            ViewBag.DoanhThuTong = DoanhThuTong();
            ViewBag.DoanhThuXacNhan = DoanhThuXacNhan();
            ViewBag.DoanhThuDangGiao = DoanhThuDangGiao();
            ViewBag.DoanhThuDaGiao = DoanhThuDaGiao();
            ViewBag.DoanhThuDaHuy = DoanhThuDaHuy();
            ViewBag.CountDonHang = CountDonHang();
            ViewBag.CountDonHangXacNhan = CountDonHangXacNhan();
            ViewBag.CountDonHangDangGiao = CountDonHangDangGiao();
            ViewBag.CountDonHangDaGiao = CountDonHangDaGiao();
            ViewBag.CountDonHangDaHuy = CountDonHangDaHuy();
            ViewBag.CountNhanVien = CountNhanVien();
            ViewBag.CountKhachHang = CountKhachHang();
            #endregion
            return View();
        }
        #endregion
    }

}