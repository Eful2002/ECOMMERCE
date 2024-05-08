namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            ChiTietPhieuNhap = new HashSet<ChiTietPhieuNhap>();
        }

        [Key]
        [Display(Name = "Mã Phiếu Nhập")]
        public int MaPhieuNhap { get; set; }

        [Display(Name = "Ngày Nhập Kho")]
        [Column(TypeName = "date")]
        public DateTime? NgayNhapKho { get; set; }

        [Display(Name = "Tổng Tiền")]
        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài Khoản Nhân Viên")]
        public string TaiKhoanNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
