namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MauSac")]
    public partial class MauSac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MauSac()
        {
            ChiTietSP = new HashSet<ChiTietSP>();
        }

        [Key]
        [Display(Name = "Mã Màu Sắc")]
        public int MaMauSac { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Màu Sắc")]
        public string TenMauSac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSP> ChiTietSP { get; set; }
    }
}
