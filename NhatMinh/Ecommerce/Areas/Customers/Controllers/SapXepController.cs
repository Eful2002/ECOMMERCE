using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using Ecommerce.Models.ViewModel;

namespace Ecommerce.Areas.Customers.Controllers
{
    public class SapXepController : Controller
    {
        DBViettelStore db = new DBViettelStore();

        #region Hiển thị điện thoại theo giá tiền
        // điện thoại dưới 1 triệu
        public ActionResult DienThoaiDuoi1Trieu(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.dGiaBan <= 1000000 & n.iMoi == 1).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Điện thoại từ 1tr đến 3tr
        public ActionResult DienThoaiTu1Den3Trieu(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.dGiaBan <= 3000000 & n.dGiaBan >= 1000000 & n.iMoi == 1).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Điện thoại từ 3tr đến 7tr
        public ActionResult DienThoaiTu3Den7Trieu(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.dGiaBan <= 7000000 & n.dGiaBan >= 3000000 & n.iMoi == 1).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Điện thoại từ 7tr đến 10tr
        public ActionResult DienThoaiTu7Den10Trieu(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.dGiaBan <= 10000000 & n.dGiaBan >= 7000000 & n.iMoi == 1).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Điện thoại từ 10tr đến 15tr
        public ActionResult DienThoaiTu10Den15Trieu(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.dGiaBan <= 15000000 & n.dGiaBan >= 10000000 & n.iMoi == 1).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Điện thoại từ 15tr đến 20tr
        public ActionResult DienThoaiTu15Den20Trieu(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.dGiaBan <= 20000000 & n.dGiaBan >= 15000000 & n.iMoi == 1).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Điện thoại trên 20 tr
        public ActionResult DienThoaiTren20Trieu(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.dGiaBan >= 20000000 & n.iMoi == 1).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Sắp xếp giá cao đến thấp
        public ActionResult CaoDenThap(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.iMoi == 1).ToList().OrderByDescending(n => n.dGiaBan);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ThapDenCao(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).Where(n => n.iMoi == 1).ToList().OrderBy(n => n.dGiaBan);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult BanChay(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                    iDaBan = ChiTietSP.SoLuongDaBan,
                                                }).Where(n => n.iMoi == 1).ToList().OrderByDescending(n => n.iDaBan);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Sắp xếp điện thoại Samsung (có mã hsx là 1)
        // Sắp xếp giá cao đến thấp
        public ActionResult SSCaoDenThap(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                    iMaHangSX = SanPham.MaHangSX,
                                                }).Where(n => n.iMoi == 1 & n.iMaHangSX == 1).ToList().OrderByDescending(n => n.dGiaBan);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Giá thấp đến cao
        public ActionResult SSThapDenCao(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                    iMaHangSX = SanPham.MaHangSX,
                                                }).Where(n => n.iMoi == 1 & n.iMaHangSX == 1).ToList().OrderBy(n => n.dGiaBan);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        // Samsung bán chạy
        public ActionResult SSBanChay(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    iRom = ChiTietSP.Rom,
                                                    iRam = ChiTietSP.Ram,
                                                    sTenMauSac = ChiTietSP.MauSac.TenMauSac,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                    iDaBan = ChiTietSP.SoLuongDaBan,
                                                    iMaHangSX = SanPham.MaHangSX,
                                                }).Where(n => n.iMoi == 1 & n.iMaHangSX == 1).ToList().OrderByDescending(n => n.iDaBan);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(lst.ToPagedList(pageNumber, pageSize));
        }
        #endregion
    }
}