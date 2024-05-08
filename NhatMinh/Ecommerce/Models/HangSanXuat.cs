namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangSanXuat")]
    public partial class HangSanXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangSanXuat()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [Display(Name = "Mã Hãng S?n Xu?t")]
        public int MaHangSX { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Hãng S?n Xu?t")]
        public string TenHangSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
