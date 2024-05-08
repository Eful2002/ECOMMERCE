namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            BinhLuan = new HashSet<BinhLuan>();
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoanKH { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhauKH { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Họ Và Tên")]
        public string HoVaTen { get; set; }

        [StringLength(10)]
        [Display(Name = "Điện Thoại")]
        public string SDT { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Giới Tính")]
        public bool? GioiTinh { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Trạng Thái")]
        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
