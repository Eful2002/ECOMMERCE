namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSP")]
    public partial class ChiTietSP
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã Sản Phẩm")]
        public int MaSanPham { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Mã Màu Sắc")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMauSac { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Rom")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rom { get; set; }

        [Key]
        [Column(Order = 3)]
        [Display(Name = "Ram")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ram { get; set; }

        [Display(Name = "Giá Gốc")]
        [Column(TypeName = "money")]
        public decimal? GiaGoc { get; set; }

        [Display(Name = "Giá Bán")]
        [Column(TypeName = "money")]
        public decimal? GiaBan { get; set; }

        [Display(Name = "Số Lượng")]
        public int? SoLuong { get; set; }

        [Display(Name = "Số Lượng Đã Bán")]
        public int? SoLuongDaBan { get; set; }

        [Display(Name = "Mới")]
        public int? Moi { get; set; }

        public virtual MauSac MauSac { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
