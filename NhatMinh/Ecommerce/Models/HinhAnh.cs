namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnh")]
    public partial class HinhAnh
    {
        [Key]
        [Display(Name = "Mã Sản Phẩm")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPham { get; set; }

        [Display(Name = "Hình Ảnh 1")]
        [StringLength(255)]
        public string HinhAnh1 { get; set; }

        [Display(Name = "Hình Ảnh 2")]
        [StringLength(255)]
        public string HinhAnh2 { get; set; }

        [Display(Name = "Hình Ảnh 3")]
        [StringLength(255)]
        public string HinhAnh3 { get; set; }

        [Display(Name = "Hình Ảnh 4")]
        [StringLength(255)]
        public string HinhAnh4 { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
