namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuNhap")]
    public partial class ChiTietPhieuNhap
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã S?n Ph?m")]
        public int MaSanPham { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã Phi?u Nh?p")]
        public int MaPhieuNhap { get; set; }

        [Display(Name = "S? L??ng Nh?p")]
        public int? SoLuongNhap { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
