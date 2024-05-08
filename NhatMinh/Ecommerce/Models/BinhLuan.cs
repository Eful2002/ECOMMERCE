namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TaiKhoanKH { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Mã Sản Phẩm")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPham { get; set; }

        [Display(Name = "Nội Dung Bình Luận")]
        [StringLength(255)]
        public string NoiDungBinhLuan { get; set; }

        [Display(Name = "Ngày Bình Luận")]
        [Column(TypeName = "date")]
        public DateTime? NgayBinhLuan { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
