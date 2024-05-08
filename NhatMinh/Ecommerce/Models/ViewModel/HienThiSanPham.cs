using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.ViewModel
{
    public class HienThiSanPham
    {
        public int iMaSanPham { get; set; }
        public int iRom { get; set; }
        public int iRam { get; set; }
        public string sTenSanPham { get; set; }
        public string sTenMauSac { get; set; }

        public string sAnhBia { get; set; }

        [Column(TypeName = "money")]
        public decimal? dGiaGoc { get; set; }

        [Column(TypeName = "money")]
        public decimal? dGiaBan { get; set; }

        public string sMoTa { get; set; }

        public int? iSoLuong { get; set; }
        public int? iDaBan { get; set; }
        public int? iMaLoaiSP { get; set; }

        public int? iMaHangSX { get; set; }

        public int? iMoi { get; set; }
    }
}