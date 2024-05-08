using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Ecommerce.Models
{
    public partial class DBViettelStore : DbContext
    {
        public DBViettelStore()
            : base("name=DBViettelStore")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public virtual DbSet<ChiTietSP> ChiTietSP { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<HangSanXuat> HangSanXuat { get; set; }
        public virtual DbSet<HinhAnh> HinhAnh { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public virtual DbSet<MauSac> MauSac { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhap { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.TaiKhoanKH)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.ThanhTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ChiTietSP>()
                .Property(e => e.GiaGoc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ChiTietSP>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TaiKhoanKH)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TaiKhoanKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhauKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.BinhLuan)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MauSac>()
                .HasMany(e => e.ChiTietSP)
                .WithRequired(e => e.MauSac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhauNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.TaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.ChiTietPhieuNhap)
                .WithRequired(e => e.PhieuNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.BinhLuan)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietPhieuNhap)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietSP)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasOptional(e => e.HinhAnh)
                .WithRequired(e => e.SanPham);
        }
    }
}
