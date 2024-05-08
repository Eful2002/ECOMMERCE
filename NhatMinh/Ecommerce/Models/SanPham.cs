namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuan = new HashSet<BinhLuan>();
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            ChiTietPhieuNhap = new HashSet<ChiTietPhieuNhap>();
            ChiTietSP = new HashSet<ChiTietSP>();
        }

        [Key]
        [Display(Name = "Mã Sản Phẩm")]
        public int MaSanPham { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên Sản Phẩm")]
        public string TenSanPham { get; set; }

        [StringLength(100)]
        [Display(Name = "Ảnh Bìa")]
        public string AnhBia { get; set; }

        [StringLength(255)]
        [Display(Name = "Màn Hình")]
        public string ManHinh { get; set; }

        [StringLength(255)]
        [Display(Name = "CPU")]
        public string CPU { get; set; }

        [StringLength(255)]
        [Display(Name = "Camera Trước")]
        public string Camera_Truoc { get; set; }

        [StringLength(255)]
        [Display(Name = "Camera Sau")]
        public string Camera_Sau { get; set; }

        [StringLength(200)]
        [Display(Name = "Hệ Điều Hành")]
        public string HeDieuHanh { get; set; }

        [StringLength(255)]
        [Display(Name = "Quay Phim")]
        public string QuayPhim { get; set; }

        [StringLength(200)]
        [Display(Name = "Pin")]
        public string Pin { get; set; }

        [Display(Name = "Thời Gian Bảo Hành")]
        public int? ThoiGianBaoHanh { get; set; }

        [Display(Name = "Thông Tin Sản Phẩm")]
        public string ThongTinThemVeSP { get; set; }

        [Display(Name = "Trạng Thái")]
        public int? TrangThai { get; set; }

        [Display(Name = "Mã Loại Sản Phẩm")]
        public int? MaLoaiSP { get; set; }

        [Display(Name = "Mã Hãng Sản Xuất")]
        public int? MaHangSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSP> ChiTietSP { get; set; }

        [Display(Name = "Hãng Sản Xuất")]
        public virtual HangSanXuat HangSanXuat { get; set; }

        [Display(Name = "Hình Ảnh")]
        public virtual HinhAnh HinhAnh { get; set; }

        [Display(Name = "Loại Sản Phẩm")]
        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
