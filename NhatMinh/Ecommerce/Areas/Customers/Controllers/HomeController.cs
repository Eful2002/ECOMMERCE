using PagedList;
using System.Linq;
using System.Web.Mvc;
using Ecommerce.Models;
using Ecommerce.Models.ViewModel;

namespace Ecommerce.Areas.Customers.Controllers
{
    public class HomeController : Controller
    {
        DBViettelStore db = new DBViettelStore();
        // Trang sản phẩm
        public ActionResult Index()
        {
            ViewBag.CountDienThoai = CountMobile();
            return View();
        }
        #region Thuộc Phần Danh Mục
        public ActionResult DanhMucDienThoaiPartial() // Method
        {
            var listdienthoai = db.SanPham.Join(db.HangSanXuat,
                                    SP => SP.MaHangSX,
                                    CTSP => CTSP.MaHangSX,

                                    (SP, CTSP) => new HienThiDanhMucHSX
                                    {
                                        iMaHangSX = CTSP.MaHangSX,
                                        sTenHangSX = CTSP.TenHangSX,
                                        iMaLoaiSP = SP.MaLoaiSP,
                                    }).Where(n => n.iMaLoaiSP == 1).Distinct().ToList(); // loại sản phẩm = là samsung
            return View(listdienthoai);
        }
        public ActionResult DanhMucDienThoaiMenuPartial()
        {
            var listdienthoai = db.SanPham.Join(db.HangSanXuat,
                                    SP => SP.MaHangSX,
                                    CTSP => CTSP.MaHangSX,

                                    (SP, CTSP) => new HienThiDanhMucHSX
                                    {
                                        iMaHangSX = CTSP.MaHangSX,
                                        sTenHangSX = CTSP.TenHangSX,
                                        iMaLoaiSP = SP.MaLoaiSP,
                                    }).Where(n => n.iMaLoaiSP == 1).Distinct().ToList();
            return View(listdienthoai);
        }
        public ActionResult DienThoaiAll(int? page)
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
                                                    sMoTa = SanPham.ThongTinThemVeSP,
                                                    iMoi = ChiTietSP.Moi,
                                                }).ToList();
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return PartialView(Listdienthoaiall.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DienThoaiTheoDanhMuc(int? mahangsx, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            ViewBag.MaHangSX = mahangsx;
            var ListDanhMucDT = db.SanPham.Join(db.ChiTietSP,
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
                                    }).Where(n => n.iMoi == 1 && n.iMaHangSX == mahangsx).ToList();
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return PartialView(ListDanhMucDT.ToPagedList(pageNumber, pageSize));
        }
        #endregion


        #region Lấy dữ liệu sản phẩm rồi in ra màn hình

        //Sản Phẩm
        public ActionResult SanPhamPartialView(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var ListSanPham = db.SanPham.Join(db.ChiTietSP,
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
                                                }).Where(n => n.iMoi == 1).ToList();
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView(ListSanPham.ToPagedList(pageNumber, pageSize));
        }

        // Sản phẩm theo điện thoại
        public ActionResult DienThoaiPartialView()
        {
            //var ListSanPham = db.SanPham.Where(n => n.MaLoaiSP == 1).ToList();
            var ListSanPhamDT = db.SanPham.Join(db.ChiTietSP,
                                               SanPham => SanPham.MaSanPham,
                                               ChiTietSP => ChiTietSP.MaSanPham,
                                               (SanPham, ChiTietSP) => new HienThiSanPham
                                               {
                                                   iMaSanPham = SanPham.MaSanPham,
                                                   sTenSanPham = SanPham.TenSanPham,
                                                   sAnhBia = SanPham.AnhBia,
                                                   dGiaBan = ChiTietSP.GiaBan,
                                                   sMoTa = SanPham.ThongTinThemVeSP,
                                                   iMaLoaiSP = SanPham.MaLoaiSP,
                                                   iMoi = ChiTietSP.Moi
                                               }).Where(n => n.iMaLoaiSP == 1 & n.iMoi == 1).OrderByDescending(n => n.iMaSanPham).Take(10).ToList();
            return PartialView(ListSanPhamDT);
        }

        //Sản phẩm theo máy tính bảng
        public ActionResult MayTinhBangPartialView()
        {
            var ListSanPhamMTB = db.SanPham.Join(db.ChiTietSP,
                                        SanPham => SanPham.MaSanPham,
                                        ChiTietSP => ChiTietSP.MaSanPham,
                                        (SanPham, ChiTietSP) => new HienThiSanPham
                                        {
                                            iMaSanPham = SanPham.MaSanPham,
                                            sTenSanPham = SanPham.TenSanPham,
                                            sAnhBia = SanPham.AnhBia,
                                            dGiaBan = ChiTietSP.GiaBan,
                                            sMoTa = SanPham.ThongTinThemVeSP,
                                            iMaLoaiSP = SanPham.MaLoaiSP,
                                        }).Where(n => n.iMaLoaiSP == 2).ToList();
            return PartialView(ListSanPhamMTB);
        }

        //Sản phẩm theo máy laptop
        public ActionResult LapTopPartialView()
        {
            var ListSanPhamLP = db.SanPham.Join(db.ChiTietSP,
                                      SanPham => SanPham.MaSanPham,
                                      ChiTietSP => ChiTietSP.MaSanPham,
                                      (SanPham, ChiTietSP) => new HienThiSanPham
                                      {
                                          iMaSanPham = SanPham.MaSanPham,
                                          sTenSanPham = SanPham.TenSanPham,
                                          sAnhBia = SanPham.AnhBia,
                                          dGiaBan = ChiTietSP.GiaBan,
                                          sMoTa = SanPham.ThongTinThemVeSP,
                                          iMaLoaiSP = SanPham.MaLoaiSP,
                                      }).Where(n => n.iMaLoaiSP == 3).ToList();
            return PartialView(ListSanPhamLP);
        }

        //Sản phẩm theo phụ kiện
        public ActionResult PhuKienPartialView()
        {
            var ListSanPhamPK = db.SanPham.Join(db.ChiTietSP,
                                      SanPham => SanPham.MaSanPham,
                                      ChiTietSP => ChiTietSP.MaSanPham,
                                      (SanPham, ChiTietSP) => new HienThiSanPham
                                      {
                                          iMaSanPham = SanPham.MaSanPham,
                                          sTenSanPham = SanPham.TenSanPham,
                                          sAnhBia = SanPham.AnhBia,
                                          dGiaBan = ChiTietSP.GiaBan,
                                          sMoTa = SanPham.ThongTinThemVeSP,
                                          iMaLoaiSP = SanPham.MaLoaiSP,
                                      }).Where(n => n.iMaLoaiSP == 4).ToList();
            return PartialView(ListSanPhamPK);
        }
        #endregion

        // Xem chi tiết
        public ActionResult XemChiTiet(int masanpham)
        {
            var chitiet = db.SanPham.SingleOrDefault(n => n.MaSanPham == masanpham);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MauSac = db.ChiTietSP.Where(n => n.MaSanPham == masanpham);

            return View(chitiet);
        }
        // Đếm số sản phẩm
        public int CountMobile()
        {
            var count = db.SanPham.Where(n => n.MaLoaiSP == 1).Count();
            return count;
        }
    }
}