using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using Ecommerce.Models.ViewModel;

namespace Ecommerce.Areas.Customers.Controllers
{
    public class GioHangController : Controller
    {
        DBViettelStore db = new DBViettelStore();

        #region Giỏ hàng
        //Lấy giỏ hàng 
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaSanPham, string strURL, FormCollection f)
        {
            // lấy thông tin chi tiết của sản phẩm đó: Màu sắc, rom, ram
            string luachon = f["MaMau"].ToString();
            char[] c = new char[] { ',' };
            string[] tachchuoi = luachon.Split(c, StringSplitOptions.RemoveEmptyEntries);
            int iMaMauSac = int.Parse(tachchuoi[0]);
            int iRom = int.Parse(tachchuoi[1]);
            int iRam = int.Parse(tachchuoi[2]);
            int a = iRom;
            int b = iRam;
            // Lấy số lượng mua 
            int soluongmua = int.Parse(f["SoLuong"]);
            SanPham ktsanpham = db.SanPham.SingleOrDefault(n => n.MaSanPham == iMaSanPham);
            ChiTietSP ktctsp = db.ChiTietSP.FirstOrDefault(n => n.MaSanPham == iMaSanPham && n.MaMauSac == iMaMauSac && n.Rom == a && n.Ram == b);
            if (ktsanpham == null && ktctsp == null)
            //if ( ktmausac == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (ktctsp.SoLuong < soluongmua)
            {
                return RedirectToAction("KhongDuSoLuong", "Error");
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sản phẩm này đã tồn tại trong session["GioHang"] chưa? và kiểm tra sản phẩm đó với màu sắc 
            int m = iMaMauSac;
            GioHang sanpham = lstGioHang.FirstOrDefault(n => n.iMaSanPham == iMaSanPham && n.iMaMauSac == m && n.iRom == a && n.iRam == b);
            if (sanpham == null) // nếu sanpham chua ton tai
            {
                sanpham = new GioHang(iMaSanPham, iMaMauSac, a, b, soluongmua);
                //Add sản phẩm mới thêm vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong += soluongmua;
                return Redirect(strURL);
            }
        }

        //Cập nhật giỏ hàng 

        public ActionResult CapNhatGioHang(int iMaSanPham, int iMaMauSac, int iRom, int iRam, string strURL, FormCollection f)
        {
            //Kiểm tra masp thuộc màu xxx có tồn tại hay k?
            int sl = int.Parse(f["txtSoLuongMoi"].ToString());

            ////Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            ////Kiểm tra sp có tồn tại trong session["GioHang"]
            GioHang ktsanphamgiohang = lstGioHang.SingleOrDefault(n => n.iMaSanPham == iMaSanPham && n.iMaMauSac == iMaMauSac && n.iRom == iRom && n.iRam == iRam);
            ChiTietSP ktmausacgiohang = db.ChiTietSP.SingleOrDefault(n => n.MaSanPham == iMaSanPham && n.MaMauSac == iMaMauSac && n.Rom == iRom && n.Ram == iRam);
            ////Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (ktsanphamgiohang != null & ktmausacgiohang != null)
            {
                if (ktmausacgiohang.SoLuong < sl)
                {
                    return RedirectToAction("KhongDuSoLuong", "Error");
                }
                else
                {
                    ktsanphamgiohang.iSoLuong = sl;
                }
            }
            return Redirect(strURL);
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSanPham, int iMaMauSac, int iRom, int iRam, string strURL)
        {
            //Kiểm tra masp
            SanPham ktsanpham = db.SanPham.SingleOrDefault(n => n.MaSanPham == iMaSanPham);
            ChiTietSP ktctsp = db.ChiTietSP.FirstOrDefault(n => n.MaSanPham == iMaSanPham && n.MaMauSac == iMaMauSac && n.Rom == iRom && n.Ram == iRam);
            if (ktsanpham == null && ktctsp == null)
            //if ( ktmausac == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang ktsanphamgiohang = lstGioHang.SingleOrDefault(n => n.iMaSanPham == iMaSanPham & n.iMaMauSac == iMaMauSac & n.iRom == iRom & n.iRam == iRam);
            //ChiTietSP ktmausacgiohang = db.ChiTietSP.SingleOrDefault(n => n.MaMauSac == iMaMauSac);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (ktsanphamgiohang != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSanPham == iMaSanPham & n.iMaMauSac == iMaMauSac & n.iRom == iRom & n.iRam == iRam);
            }
            if (lstGioHang.Count == 0)
            {
                Session["GioHang"] = null;
                return RedirectToAction("GioHangTrong", "Error");
            }
            return Redirect(strURL);
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("GioHangTrong", "Error");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult MiniCart()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0 && TongSoLuong() == 0)
            {
                return RedirectToAction("GioHangTrong", "Error");
            }

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView(lstGioHang);
        }
        #endregion

        #region Đặt hàng
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            string tennguoinhan = f["txtTenNguoiNhan"].ToString();
            string diachi = f["txtDiaChi"].ToString();
            string sdt = f["txtSDT"].ToString();
            string thanhpho = f["province"].ToString();
            string quan = f["district"].ToString();
            string phuong = f["ward"].ToString();
            //Kiểm tra đăng đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            DonHang dh = new DonHang();
            //KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            dh.TaiKhoanKH = kh.TaiKhoanKH;
            dh.TenNguoiNhan = tennguoinhan;
            dh.NgayDat = DateTime.Now;
            dh.DiaChi = diachi;
            dh.SDT = sdt;
            dh.ThanhPho = thanhpho;
            dh.Quan = quan;
            dh.Phuong = phuong;
            dh.NgayGiao = null;
            dh.TongTien = (decimal)TongTien();
            dh.TrangThai = 0;
            db.DonHang.Add(dh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = dh.MaDonHang;
                ctDH.MaSanPham = item.iMaSanPham;
                ctDH.MaMauSac = item.iMaMauSac;
                ctDH.Rom = item.iRom;
                ctDH.Ram = item.iRam;
                ctDH.SoLuongMua = item.iSoLuong;
                ctDH.ThanhTien = (Decimal)item.dDonGia;
                #region Trừ số lượng mua
                ChiTietSP sp = db.ChiTietSP.SingleOrDefault(n => n.MaSanPham == item.iMaSanPham && n.MaMauSac == item.iMaMauSac && n.Rom == item.iRom && n.Ram == item.iRam);
                sp.SoLuong -= ctDH.SoLuongMua;
                sp.SoLuongDaBan += ctDH.SoLuongMua;
                #endregion

                db.ChiTietDonHang.Add(ctDH);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("DatHangThanhCong", "Error");
        }
        #endregion

        #region Xem Giỏ Hàng sau khi mua

        [HttpGet]
        public ActionResult TongDonPartialView()
        {
            //Kiểm tra người dùng đã đăng nhập chưa?
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang kh = (KhachHang)Session["TaiKhoan"];

            var XemDonHang = db.DonHang.Where(n => n.TaiKhoanKH == kh.TaiKhoanKH).ToList().OrderByDescending(n => n.MaDonHang);
            if (XemDonHang == null)
            {
                return RedirectToAction("GioHangTrong", "Error");
            }
            return PartialView(XemDonHang);
        }

        //Xác nhận đơn
        [HttpGet]
        public ActionResult XacNhanPartialView()
        {
            //Kiểm tra người dùng đã đăng nhập chưa?
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang kh = (KhachHang)Session["TaiKhoan"];

            var XemDonHang = db.DonHang.Where(n => n.TaiKhoanKH == kh.TaiKhoanKH & n.TrangThai == 0).ToList().OrderByDescending(n => n.MaDonHang);
            if (XemDonHang == null)
            {
                return RedirectToAction("GioHangTrong", "Error");
            }
            return PartialView(XemDonHang);
        }
        // Đang giao
        [HttpGet]
        public ActionResult DangGiaoPartialView()
        {
            //Kiểm tra người dùng đã đăng nhập chưa?
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang kh = (KhachHang)Session["TaiKhoan"];

            var XemDonHang = db.DonHang.Where(n => n.TaiKhoanKH == kh.TaiKhoanKH & n.TrangThai == 1).ToList().OrderByDescending(n => n.MaDonHang);
            if (XemDonHang == null)
            {
                return RedirectToAction("GioHangTrong", "Error");
            }
            return PartialView(XemDonHang);
        }
        [HttpGet]
        public ActionResult DaGiaoPartialView()
        {
            //Kiểm tra người dùng đã đăng nhập chưa?
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang kh = (KhachHang)Session["TaiKhoan"];

            var XemDonHang = db.DonHang.Where(n => n.TaiKhoanKH == kh.TaiKhoanKH & n.TrangThai == 2).ToList().OrderByDescending(n => n.MaDonHang);
            if (XemDonHang == null)
            {
                return RedirectToAction("GioHangTrong", "Error");
            }
            return PartialView(XemDonHang);
        }
        [HttpGet]
        public ActionResult DaHuyPartialView()
        {
            //Kiểm tra người dùng đã đăng nhập chưa?
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang kh = (KhachHang)Session["TaiKhoan"];

            var XemDonHang = db.DonHang.Where(n => n.TaiKhoanKH == kh.TaiKhoanKH & n.TrangThai == 3).ToList().OrderByDescending(n => n.MaDonHang);
            if (XemDonHang == null)
            {
                return RedirectToAction("GioHangTrong", "Error");
            }
            return PartialView(XemDonHang);
        }
        public ActionResult XemChiTietDonHangDaMua(int? iMaDonHang)
        {
            //kiểm tra id có hợp lệ không
            if (iMaDonHang == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            DonHang model = db.DonHang.FirstOrDefault(n => n.MaDonHang == iMaDonHang);
            //kiểm tra đơn hàng có tồn tại không
            if (model == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            //lấy danh sách chi tiết đơn hàng để hiển thị cho người dùng thấy
            var lstchitietdh = db.ChiTietDonHang.Where(n => n.MaDonHang == iMaDonHang);
            ViewBag.listchitietdonhang = lstchitietdh;
            return View(model);
        }
        #endregion
    }

}