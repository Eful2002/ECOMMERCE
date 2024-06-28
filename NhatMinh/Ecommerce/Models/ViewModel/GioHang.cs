using System.Linq;

namespace Ecommerce.Models.ViewModel
{
    public class GioHang
    {
        DBEcommerce db = new DBEcommerce();
        public int iMaSanPham { get; set; }
        public int iMaMauSac { get; set; }
        public int iRom { get; set; }
        public int iRam { get; set; }
        public string sTenSanPham { get; set; }
        public string sTenMauSac { get; set; }
        public string sAnhChinh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int masanpham, int mamausac, int rom, int ram,int soluongmua)
        {

            iMaSanPham = masanpham;
            iMaMauSac = mamausac;
            iRom = rom;
            iRam = ram;
            
            int m = iMaMauSac;
            int a = rom;
            int b = ram;
            SanPham sanpham = db.SanPham.SingleOrDefault(n => n.MaSanPham == iMaSanPham);
            ChiTietSP ctsp1 = db.ChiTietSP.FirstOrDefault(n => n.MaSanPham == iMaSanPham && n.MaMauSac == m && n.Rom == a && n.Ram == b);

            iMaMauSac = ctsp1.MaMauSac; // ngoại
            sTenSanPham = sanpham.TenSanPham;
            sTenMauSac = ctsp1.MauSac.TenMauSac; // ngoại
            sAnhChinh = sanpham.AnhBia;
            //dDonGia = double.Parse(sach.GiaBan.ToString());
            dDonGia = (double)ctsp1.GiaBan;
            iSoLuong = soluongmua;
        }
    }
}