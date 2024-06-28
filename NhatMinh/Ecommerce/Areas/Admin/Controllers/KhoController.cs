using Ecommerce.Models;
using Ecommerce.Models.ViewModel;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class KhoController : Controller
    {
        private DBViettelStore db = new DBViettelStore();

        // GET: Admin/Kho
        public ActionResult SanPhamBanChay(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var Listdienthoaiall = db.SanPham.Join(db.ChiTietSP,
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
                                                    iSoLuong = ChiTietSP.SoLuong,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                    iDaBan = ChiTietSP.SoLuongDaBan
                                                }).OrderByDescending(n=>n.iDaBan).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(Listdienthoaiall.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult SanPhamBanHet(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var Listdienthoaiall = db.SanPham.Join(db.ChiTietSP,
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
                                                    iSoLuong = ChiTietSP.SoLuong,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                    iDaBan = ChiTietSP.SoLuongDaBan
                                                }).Where(n => n.iSoLuong == 0).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(Listdienthoaiall.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult SanPhamTonKho(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var Listdienthoaiall = db.SanPham.Join(db.ChiTietSP,
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
                                                    iSoLuong = ChiTietSP.SoLuong,
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                    iDaBan = ChiTietSP.SoLuongDaBan
                                                }).OrderByDescending(n => n.iSoLuong).ToList().Take(5);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(Listdienthoaiall.ToPagedList(pageNumber, pageSize));
        }

    }
}