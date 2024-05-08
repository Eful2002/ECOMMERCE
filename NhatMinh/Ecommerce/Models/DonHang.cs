namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name = "Mã Đơn Hàng")]
        public int MaDonHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Người Nhận")]
        public string TenNguoiNhan { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Đặt")]
        public DateTime NgayDat { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(10)]
        [Display(Name = "Điện Thoại")]
        public string SDT { get; set; }

        [StringLength(100)]
        [Display(Name = "Thành Tiền")]
        public string ThanhPho { get; set; }

        [StringLength(100)]
        [Display(Name = "Quận")]
        public string Quan { get; set; }

        [StringLength(100)]
        [Display(Name = "Phường")]
        public string Phuong { get; set; }

        [Display(Name = "Ngày Giao")]
        [Column(TypeName = "date")]
        public DateTime? NgayGiao { get; set; }

        [Display(Name = "Tổng Tiền")]
        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        [Display(Name = "Trạng Thái")]
        public int? TrangThai { get; set; }

        [StringLength(50)]
        public string TaiKhoanKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
