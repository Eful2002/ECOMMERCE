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
    public class TimKiemController : Controller
    {
        DBViettelStore db = new DBViettelStore();
        public ActionResult TimKiem(String sTuKhoa, int? page, FormCollection f)
        {
            int luachon = int.Parse(f["loai"]);
            ViewBag.tukhoa = sTuKhoa;
            // Điện thoại
            if (luachon == 1)
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
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMoi = ChiTietSP.Moi,
                                            iMaHangSX = SanPham.MaHangSX,
                                        }).Where(n => n.sTenSanPham.Contains(sTuKhoa) & n.iMoi == 1).OrderBy(n => n.sTenSanPham);
                int pageSize = 16;
                int pageNumber = (page ?? 1);
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            // Phụ kiện
            // Giá bán
            if (luachon == 3)
            {
                try
                {
                    decimal? giaban = decimal.Parse(sTuKhoa);
                    if (giaban != null)
                    {
                        if (page != null)
                        {
                            page = 1;
                        }
                        var lst = db.SanPham.Join(db.ChiTietSP,
                                                SanPham => SanPham.MaSanPham,
                                                ChiTietSP => ChiTietSP.MaSanPham,
                                                (SanPham, ChiTietSP) => new HienThiSanPham
                                                {
                                                    iMaSanPham = SanPham.MaSanPham,
                                                    sTenSanPham = SanPham.TenSanPham,
                                                    sAnhBia = SanPham.AnhBia,
                                                    dGiaBan = ChiTietSP.GiaBan,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                    iMaHangSX = SanPham.MaHangSX,
                                                }).Where(n => n.dGiaBan == giaban & n.iMoi == 1).OrderBy(n => n.sTenSanPham);
                        int pageSize = 16;
                        int pageNumber = (page ?? 1);
                        return View(lst.ToPagedList(pageNumber, pageSize));
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Error404", "Error");
                }
            }
            // Dưới 1 triệu
            if (luachon == 4)
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
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMoi = ChiTietSP.Moi,
                                            iMaHangSX = SanPham.MaHangSX,
                                        }).Where(n => n.sTenSanPham.Contains(sTuKhoa) & n.iMoi == 1 & n.dGiaBan <= 1000000).OrderBy(n => n.sTenSanPham);
                int pageSize = 16;
                int pageNumber = (page ?? 1);
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            // Từ 1 đến 3 tr
            if (luachon == 5)
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
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMoi = ChiTietSP.Moi,
                                            iMaHangSX = SanPham.MaHangSX,
                                        }).Where(n => n.sTenSanPham.Contains(sTuKhoa) & n.iMoi == 1 & n.dGiaBan <= 3000000 & n.dGiaBan >= 1000000).OrderBy(n => n.sTenSanPham);
                int pageSize = 16;
                int pageNumber = (page ?? 1);
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            // Từ 3 đến 7 tr
            if (luachon == 6)
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
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMoi = ChiTietSP.Moi,
                                            iMaHangSX = SanPham.MaHangSX,
                                        }).Where(n => n.sTenSanPham.Contains(sTuKhoa) & n.iMoi == 1 & n.dGiaBan <= 7000000 & n.dGiaBan >= 3000000).OrderBy(n => n.sTenSanPham);
                int pageSize = 16;
                int pageNumber = (page ?? 1);
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            // Từ 7 đến 10 tr
            if (luachon == 7)
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
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMoi = ChiTietSP.Moi,
                                            iMaHangSX = SanPham.MaHangSX,
                                        }).Where(n => n.sTenSanPham.Contains(sTuKhoa) & n.iMoi == 1 & n.dGiaBan <= 10000000 & n.dGiaBan >= 7000000).OrderBy(n => n.sTenSanPham);
                int pageSize = 16;
                int pageNumber = (page ?? 1);
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            // Từ 10 đến 15 tr
            if (luachon == 8)
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
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMoi = ChiTietSP.Moi,
                                            iMaHangSX = SanPham.MaHangSX,
                                        }).Where(n => n.sTenSanPham.Contains(sTuKhoa) & n.iMoi == 1 & n.dGiaBan <= 15000000 & n.dGiaBan >= 10000000).OrderBy(n => n.sTenSanPham);
                int pageSize = 16;
                int pageNumber = (page ?? 1);
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            // Từ 15 đến 20 tr
            if (luachon == 9)
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
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMoi = ChiTietSP.Moi,
                                            iMaHangSX = SanPham.MaHangSX,
                                        }).Where(n => n.sTenSanPham.Contains(sTuKhoa) & n.iMoi == 1 & n.dGiaBan <= 20000000 & n.dGiaBan >= 15000000).OrderBy(n => n.sTenSanPham);
                int pageSize = 16;
                int pageNumber = (page ?? 1);
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            // Trên 20 triệu
            if (luachon == 10)
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
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMoi = ChiTietSP.Moi,
                                            iMaHangSX = SanPham.MaHangSX,
                                        }).Where(n => n.sTenSanPham.Contains(sTuKhoa) & n.iMoi == 1 & n.dGiaBan >= 20000000).OrderBy(n => n.sTenSanPham);
                int pageSize = 16;
                int pageNumber = (page ?? 1);
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            return RedirectToAction("Error404", "Error");
        }
    }
}