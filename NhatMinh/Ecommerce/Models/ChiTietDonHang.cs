namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [Display(Name = "Mã Đơn Hàng")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Mã Sản Phẩm")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPham { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Mã Màu Sắc")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMauSac { get; set; }

        [Key]
        [Column(Order = 3)]
        [Display(Name = "Rom")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rom { get; set; }

        [Key]
        [Column(Order = 4)]
        [Display(Name = "Ram")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ram { get; set; }

        [Display(Name = "Số Lượng Mua")]
        public int? SoLuongMua { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Thành Tiền")]
        public decimal? ThanhTien { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
