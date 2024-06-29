GO
USE master; -- Chuyển đổi sang cơ sở dữ liệu master
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Ecommerce')
BEGIN
    ALTER DATABASE Ecommerce SET SINGLE_USER WITH ROLLBACK IMMEDIATE; -- Đảm bảo không ai kết nối đến cơ sở dữ liệu
    DROP DATABASE Ecommerce; -- Xóa cơ sở dữ liệu
END
GO
create database Ecommerce
go
use Ecommerce
go
create table KhachHang
(
	TaiKhoanKH varchar(50) primary key,
	MatKhauKH varchar(50) not null,
	HoVaTen nvarchar(50) not null,
	SDT varchar(10) null,
	Email varchar(50) null,
	GioiTinh bit default('True'),
	DiaChi nvarchar(100) null,
	TrangThai int default(0),
)
go
insert into KhachHang(TaiKhoanKH, MatKhauKH, HoVaTen, SDT,Email,GioiTinh,DiaChi) 
values('NguyenMinh', 'Abc123', N'Nguyễn Nhật Minh', '0345254655', 'nem26102002@gmail.com', 0, N'TP. Hồ Chí Minh');
insert into KhachHang(TaiKhoanKH, MatKhauKH, HoVaTen, SDT,Email,GioiTinh,DiaChi) 
values('CongPhuong', 'Abc123', N'Công Phượng', '0974525152', 'congphuong@gmail.com', 0, N'TP. Hà Nội');
insert into KhachHang(TaiKhoanKH, MatKhauKH, HoVaTen, SDT,Email,GioiTinh,DiaChi) 
values('HuynhNhu', 'Abc123', N'Huỳnh Như', '0348212365', 'huynhnhu@gmail.com', 0, N'TP. Đà Nẵng');
insert into KhachHang(TaiKhoanKH, MatKhauKH, HoVaTen, SDT,Email,GioiTinh,DiaChi) 
values('HongDuy', 'Abc123', N'Nguyễn Phan Hồng Duy', '0972132542', 'hongduy@gmail.com', 0, N'TP. Vinh');
insert into KhachHang(TaiKhoanKH, MatKhauKH, HoVaTen, SDT,Email,GioiTinh,DiaChi) 
values('VanLam', 'Abc123', N'Nguyễn Văn Lâm', '0965251451', 'lamtay@gmail.com', 1, N'TP. Hồ Chí Minh');
go
create table NhanVien
(
	TaiKhoanNV varchar(50) primary key,
	MatKhauNV varchar(50) not null,
	HoVaTen nvarchar(50) not null,
	SDT varchar(10) null,
	Email varchar(50) null,
	GioiTinh bit default('True'),
	DiaChi nvarchar(100) null,
	TrangThai int default(0),
	NgaySinh date not null,
)
go
insert into NhanVien(TaiKhoanNV, MatKhauNV, HoVaTen, SDT, Email, GioiTinh, DiaChi, TrangThai, NgaySinh)
values ('Admin', 'abc123', N'Quản lý', '0971010281', 'admin@gmail.com', 1,N'TP. Hồ Chí Minh', default, '03/09/1999');
insert into NhanVien(TaiKhoanNV, MatKhauNV, HoVaTen, SDT, Email, GioiTinh, DiaChi, TrangThai, NgaySinh)
values ('Kho', 'abc123', N'Quản lý', '0345625142', 'kho@gmail.com', 1,N'TP. Hà Nội', default, '12/12/1995');
insert into NhanVien(TaiKhoanNV, MatKhauNV, HoVaTen, SDT, Email, GioiTinh, DiaChi, TrangThai, NgaySinh)
values ('huyen', 'abc123', N'Thu Ngân', '054251365', 'huyen@gmail.com', 1,N'TP. Đà Nẵng', default, '08/09/1994');
insert into NhanVien(TaiKhoanNV, MatKhauNV, HoVaTen, SDT, Email, GioiTinh, DiaChi, TrangThai, NgaySinh)
values ('thao', 'abc123', N'Kế Toán', '0971010789', 'thao@gmail.com', 1,N'TP. Huế', default, '10/09/1991');
insert into NhanVien(TaiKhoanNV, MatKhauNV, HoVaTen, SDT, Email, GioiTinh, DiaChi, TrangThai, NgaySinh)
values ('dung', 'abc123', N'Shipper', '0973652281', 'dung@gmail.com', 1,N'TP. Hạ Long', default, '06/01/1984');
go
create table LoaiSanPham
(
	MaLoaiSP int identity(1,1) primary key,
	TenLoaiSP nvarchar(50) not null,
)
go
insert into LoaiSanPham(TenLoaiSP) values (N'Điện Thoại');
insert into LoaiSanPham(TenLoaiSP) values (N'Phụ Kiện');
insert into LoaiSanPham(TenLoaiSP) values (N'LapTop');
insert into LoaiSanPham(TenLoaiSP) values (N'Máy Tính Bảng');
insert into LoaiSanPham(TenLoaiSP) values (N'Đồng Hồ Thông Minh');
insert into LoaiSanPham(TenLoaiSP) values (N'Phụ Kiện');
insert into LoaiSanPham(TenLoaiSP) values (N'Thiết Bị Mạng');
insert into LoaiSanPham(TenLoaiSP) values (N'Chăm Sóc Sức Khỏe');
insert into LoaiSanPham(TenLoaiSP) values (N'Máy Đọc Sác');
insert into LoaiSanPham(TenLoaiSP) values (N'Máy In');
insert into LoaiSanPham(TenLoaiSP) values (N'Máy Chiếu');
insert into LoaiSanPham(TenLoaiSP) values (N'Camera');
go
create table HangSanXuat
(
	MaHangSX int identity(1,1) primary key,
	TenHangSX nvarchar(50) not null,
)
go
insert into HangSanXuat(TenHangSX) values (N'SamSung');
insert into HangSanXuat(TenHangSX) values (N'Apple');
insert into HangSanXuat(TenHangSX) values (N'DELL');
insert into HangSanXuat(TenHangSX) values (N'Sony');
insert into HangSanXuat(TenHangSX) values (N'LG');
insert into HangSanXuat(TenHangSX) values (N'Xiaomi');
insert into HangSanXuat(TenHangSX) values (N'Huawei');
go
create table MauSac
(
	MaMauSac int identity(1,1) primary key,
	TenMauSac nvarchar(50) not null,
)
go
insert into MauSac(TenMauSac) values (N'Black');
insert into MauSac(TenMauSac) values (N'Silver');
insert into MauSac(TenMauSac) values (N'Gold'); -- vàng
insert into MauSac(TenMauSac) values (N'Red');
insert into MauSac(TenMauSac) values (N'Green'); -- xanh lá cây
insert into MauSac(TenMauSac) values (N'Blue'); -- xanh da trời
insert into MauSac(TenMauSac) values (N'While');
insert into MauSac(TenMauSac) values (N'Rose Gold'); -- vàng hồng
insert into MauSac(TenMauSac) values (N'Violet'); -- Tím khói/ tím nhạt
insert into MauSac(TenMauSac) values (N'Colorful'); -- nhiều màu
insert into MauSac(TenMauSac) values (N'color unknown'); -- màu không xác dịnh
go
create table DonHang
(
	MaDonHang int identity(1,1) primary key,
	TenNguoiNhan nvarchar(50) null, 
	NgayDat date default(getdate()),
	DiaChi nvarchar(100) null,
	SDT varchar(10) null,
	ThanhPho nvarchar(100) null,
	Quan nvarchar(100) null,
	Phuong nvarchar(100) null,
	NgayGiao date null,
	TongTien money default(0),
	TrangThai int default(0),
	TrangThaiThanhToan int default(0), -- 0: chưa thanh toán; 1: Đã thanh toán
	TaiKhoanKH varchar(50),
	foreign key(TaiKhoanKH) references KhachHang(TaiKhoanKH), -- đường quan hệ 
)
go
insert into DonHang(TenNguoiNhan, NgayDat, DiaChi, SDT, ThanhPho, Quan, Phuong, NgayGiao, TongTien, TrangThai, TaiKhoanKH)
values (N'Nguyễn Minh', '03/02/2000', N'120 Nguyễn Tất Thành','0974521251', N'Đà Nẵng', N'Hải Châu', N'Thanh Khê', N'05/02/2000', 120000, 0,'NguyenMinh');
insert into DonHang(TenNguoiNhan, NgayDat, DiaChi, SDT, ThanhPho, Quan, Phuong, NgayGiao, TongTien, TrangThai, TaiKhoanKH)
values (N'Nguyễn Minh', '05/02/2021', N'75 Tô Hoài','0974521251', N'Hà Nội', N'Ba Vì', N'Xã Ba Vì', N'08/02/2021', 300000, 0,'NguyenMinh');
insert into DonHang(TenNguoiNhan, NgayDat, DiaChi, SDT, ThanhPho, Quan, Phuong, NgayGiao, TongTien, TrangThai, TaiKhoanKH)
values (N'Văn Thanh', '06/02/2021', N'12/2B Điện Biên Phủ','0974521251', N'Hà Nội', N'Ba Vì', N'Cẩm Lĩnh', N'09/02/2021', 600000, 0,'NguyenMinh');
insert into DonHang(TenNguoiNhan, NgayDat, DiaChi, SDT, ThanhPho, Quan, Phuong, NgayGiao, TongTien, TrangThai, TaiKhoanKH)
values (N'Công Phượng', '07/02/2021', N'01 Lê Duẩn','0974521251', N'Đà Nẵng', N'Ba Vì', N'Ba Trại', N'12/02/2021', 700000, 0,'NguyenMinh');
insert into DonHang(TenNguoiNhan, NgayDat, DiaChi, SDT, ThanhPho, Quan, Phuong, NgayGiao, TongTien, TrangThai, TaiKhoanKH)
values (N'Văn Lâm', '08/02/2021', N'93 Phan Đăng Lưu','0974521251', N'Hà Nội', N'ba Vì', N'Cổ Đô', N'09/02/2021', 1200000, 0,'NguyenMinh');
go
create table SanPham
(
	MaSanPham int identity(1,1) primary key,
	TenSanPham nvarchar(100) not null, 
	AnhBia nvarchar(100) null,
	ManHinh nvarchar(255) null,
	CPU nvarchar(255) null,
	Camera_Truoc nvarchar(255) null,
	Camera_Sau nvarchar(255) null,
	HeDieuHanh nvarchar(200) null,
	QuayPhim nvarchar(255) null,
	Pin nvarchar(200) null,
	ThoiGianBaoHanh int null,
	ThongTinThemVeSP nvarchar(max) null,
	TrangThai int null,
	MaLoaiSP int,
	MaHangSX int,
	foreign key(MaLoaiSP) references LoaiSanPham(MaLoaiSP),
	foreign key(MaHangSX) references HangSanXuat(MaHangSX),
)
go
-- =========================== Thêm sản phẩm ================================= --
-----Thêm điện thoại thuộc hãng sx: SamSung, Loại sp là điện thoại
insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy A32', N'SamSungA32.jpeg', N'Super AMOLED, Full HD+ (1080 x 2400 Pixels), 6.4", Kính cường lực Corning Gorilla Glass 5', N'MediaTek Helio G80 8 nhân; 2 nhân 2.0 GHz & 6 nhân 1.8 GHz; Mali-G52 MC2', N'20 MP; F2.2; Quay video Full HD, HDR', N'Chính 64 MP & Phụ 8 MP, 5MP, 5MP; F1.8 , F2.2 , F2.4 , F2.4; FullHD 1080p@120fps FullHD 1080p@30fps 4K 2160p@30fps; Đèn Flash, HDR Góc rộng (Wide), Góc siêu rộng (Ultrawide), Siêu cận (Macro), Lấy nét theo pha (PDAF), Xóa phông Toàn cảnh (Panorama)', N'Android 11', N'FullHD 1080p@120fps FullHD 1080p@30fps 4K 2160p@30fps', N'5000 mAh; Li-Ion; Sạc pin nhanh', 6,N'Samsung Galaxy A32 4G là mẫu smartphone tầm trung mới vừa được trình làng. Ngoài thiết kế tượng tự phiên bản 5G, Galaxy A32 4G còn sở hữu nhiều ưu điểm vượt trội như: camera 64MP, pin trâu 5.000 mAh, màn hình sắc nét, cấu hình mạnh mẽ, giá bán hợp lý... Thiết kế Samsung Galaxy A32 4G thời thượng đa sắc màu', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy A12', N'SamSungA12.jpeg', N'TFT, LCD, HD+ (720 x 1560 Pixels), 6.5"', N'MediaTek Helio G35 8 nhân', N'8 MP; Videocall: Thông qua ứng dụng thứ 3', N'	Chính 48 MP & Phụ 5 MP, 2 MP, 2 MP; FullHD 1080p@30fps; Đèn Flash; Toàn cảnh (Panorama); Tự động lấy nét (AF); HDR; Góc rộng (Wide); Siêu cận (Macro); Xóa phông; Góc siêu rộng (Ultrawide)', N'Android 10', N'	FullHD 1080p@30fps', N'5000 mAh; Li-Po; Sạc pin nhanh', 6, N'Samsung Galaxy A12 rất được ưu ái khi sở hữu cụm camera mới, nhiều ống kính hơn và 1 viên pin dung lượng khủng. Phiên bản kế nhiệm của Galaxy A11 chắc chắn sẽ đem đến những trải nghiệm mới thú vị hơn.', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy S21+ 5G', N'SamsungGalaxy_S21.jpeg', N'Dynamic AMOLED 2X; Full HD+ (1080 x 2400 Pixels); 6.7"; Kính cường lực Corning Gorilla Glass Victus', N'Exynos 2100 8 nhân', N'	10 MP; Videocall Thông qua ứng dụng thứ 3; A.I Camera, HDR, Góc rộng (Wide), Tự động lấy nét (AF), Quay video Full HD, Làm đẹp, Nhận diện khuôn mặt, Flash màn hình, Nhãn dán (AR Stickers), Xóa phông, Quay phim 4K', N'Chính 12 MP & Phụ 64 MP, 12 MP; FullHD 1080p@240fps', N'Android 11', N'FullHD 1080p@240fps, FullHD 1080p@60fps, FullHD 1080p@30fps, 4K 2160p@30fps, 4K 2160p@60fps, HD 720p@960fps, 8K 4320p@24fps', N'	4800 mAh; Li-Ion; Sạc pin nhanh, Tiết kiệm pin, Siêu tiết kiệm pin, Sạc không dây, Sạc ngược không dây', 6, N'Galaxy S21+ 5G là smartphone cao cấp đáng sử dụng nhất hiện nay. Thiết kế đẳng cấp, cấu hình siêu mạnh, camera chụp ảnh tuyệt đẹp, màn hình thời thượng,... là nhưng gì phiên bản “Plus” thuộc dòng Galaxy S21 sẽ đem đến cho người dùng.', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy S20 FE', N'Samsung_Galaxy_S20.jpeg', N'Super AMOLED; Full HD+ (1080 x 2400 Pixels); 6.5"; 120 Hz; Mặt kính cong 2.5D', N'Snapdragon 865 8 nhân; 1 nhân 2.84 GHz, 3 nhân 2.42 GHz & 4 nhân 1.8 GHz; Adreno 650', N'	32 MP; Xóa phông; Flash màn hình; Quay video HD; Nhận diện khuôn mặt;', N'	Chính 12 MP & Phụ 12 MP, 8 MP; 4K 2160p@60fps, 4K 2160p@30fps, FullHD 1080p@30fps, FullHD 1080p@60fps; Đèn Flash', N'Android 11', N'4K 2160p@60fps, 4K 2160p@30fps, FullHD', N'	4500 mAh; Li-Ion; Sạc ngược không dây; Sạc pin nhanh; Sạc không dây; Hỗ trợ sạc tối đa 25 W', 6, N'Samsung Galaxy S20 FE ra mắt hội tụ đầy đủ các tính năng, sức mạnh của một flagship trong mức giá vô cùng hấp dẫn. Qua đó, Samfan dễ dàng trải nghiệm khả năng nhiếp ảnh chuyên nghiệp, chơi game hạng nặng với hiệu năng và camera cực kỳ chất lượng của dòng Galaxy S.', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy Z Flip3 5G', N'Samsung_Galaxy_Z_Flip3.jpeg', N'Supper AMOLES 6.7"', N'Snapdragon 888 8 nhân', N'HDR Quay video Full HD', N'HDR Quay video Full HD', N'Android 11', N'4K+', N'3300 mAh, Sạc không dâySạc pin nhanh', 6, N'Điện Thoại Bán Chạy nhất thuộc hàng cao cấp của SamSung trong tháng vừa qua', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung E1200', N'Samsung_E1200.jpeg', N'1.5", QCIF, 128 x 128 pixels', N'Snapdragon', N'Không', N'Không', N'Android', N'Không', N'1000mah', 6, N'SAMSUNG E1200T – Điện thoại giá rẻ tiện dụng - pin lên tới 30 ngày
Samsung E1200T là điện thoại nổi trội ở phân khúc điện thoại phổ thông, sản phẩm phù hợp với mọi đối tượng. Với thiết kế nhỏ gọn, tiện dụng, màu đen sang trọng, thời lượng pin tốt đây là phương tiện liên lạc hiệu quả của bạn.', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy Note20 Ultra 5G', N'Samsung_Galaxy_Note20_Ultra.jpeg', N'Dynamic AMOLED 2X, 6.9", Quad HD+ (2K+)', N'Exynos 990 8 nhân', N'10 MP', N'Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF', N'Android 10', N'8K 4320p@24fps', N'Pin chuẩn Li-Ion; 4500 mAh', 6, N'Galaxy Note 20 Ultra 5G là chiếc smartphone mạnh mẽ nhất trong bộ ba Galaxy Note 20 Series ra mắt năm nay khi ở phiên bản này, cấu hình cũng như tính năng được nâng cấp rất đặc biệt. Cùng Viettel Store đánh giá nhanh Galaxy Note 20 Ultra 5G trong bài viết dưới đây bạn nhé.', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy Note 10+ ', N'Samsung_Galaxy_Note_10.png', N'manhinh', N'CPU', N'cameratruoc', N'Camerasau', N'HeDieuHanh', N'QuayPhim', N'pin', 6, N'MoTa', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy M21', N'Samsung_Galaxy_M21.jpeg', N'Super AMOLED, 6.4", Full HD+', N'Exynos 9611 8 nhân', N'20 MP', N'Chính 48 MP & Phụ 8 MP, 5 MP', N'Android 10', N'MP4, AVI', N'6000 mAh, có sạc nhanh', 6, N'Nổi lên phân khúc tầm trung với mức giá vô cùng hợp lý và cấu hình thách thức bao đối thủ, Galaxy M21 được mệnh danh là một trong những smartphone tầm trung đáng mua nhất khi sở hữu viên pin lên tới 6000 mAh. Cùng Viettel Store ‘’mục sở thị’’ chiếc smartphone chỉ hơn 5 triệu này nhé.', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy A51', N'Samsung_Galaxy_A51.jpeg', N'6.5 inches, FHD+', N'Exynos 9611, 8, Octa-core (4x2.3 GHz Cortex-A73 & 4x1.7 GHz Cortex-A53)', N'32 MP', N'48MP, 5MP, 12MP, 5MP (4 camera)', N'Android 10', N'FullHD 1080p@30fps, Quay phim 4K 2160p@30fps', N'4000mAh', 6, N'Samsung Galaxy A51, smartphone Samsung sở hữu thiết kế 4 camera sau 48MP, camera trước 32MP, màn hình kích thước lớn 6.5 inches, Full HD+ cùng viên pin dung lượng 4000mAh chắc chắn sẽ đem tới những trải nghiệm tuyệt vời cho người dùng.', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy A52', N'Samsung_Galaxy_A52.jpeg', N'Super AMOLED, Full HD+ (1080 x 2400 Pixels), 6.5", 90 Hz, Kính cường lực', N'Snapdragon 720G 8 nhân, 2 nhân 2.3 Ghz & 6 nhân 1.8 Ghz', N'32 MP, Xóa phông, Quay video HD, Nhận diện khuôn mặt, Làm đẹp', N'	Chính 64 MP & Phụ 12 MP, 5 MP, 5 MP; FullHD 1080p@30fps, HD 720p@240fps, 4K 2160p@30fps, Đèn Flash, Ban đêm (Night Mode)', N'Android 11', N'FullHD 1080p@30fps, HD 720p@240fps, 4K 2160p@30fps', N'4500 mAh, Li-Ion, Sạc pin nhanh, Hỗ trợ sạc tối đa 25 W, Sạc kèm theo máy 15 W', 6, N'Samsung Galaxy A52 là bản nâng cấp của Galaxy A51 được cải tiến và nâng cấp khá nhiều so với phiên bản tiền nhiệm cả về thiết kế lần phần cứng được ra mắt hồi tháng 03.2021. Samsung tích hợp thêm nhiều công nghệ mang tính đột phá đem đem trải nghiệm tuyệt vời cho người dùng trong phân khúc tầm trung.', 1,1);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP,MaLoaiSP, MaHangSX) 
values (N'Samsung Galaxy S20 Ultra', N'Samsung_Galaxy_S20_Ultra.jpeg', N'Dynamic AMOLED 2X, 6.9", Quad HD+ (2K+)', N'Exynos 990 8 nhân', N'40MP', N'Chính 108 MP & phụ 48 MP, 12 MP, TOF 3D', N'Android 10', N'4k, HD+', N'5000 mAh, có sạc nhanh', 6, N'Galaxy S20 ULTRA là chiếc smartphone mạnh nhất và có mức giá cao nhất trong bộ 3 Galaxy S20 Series được Samsung ra mắt thời gian qua. Cùng Viettel Store đánh giá nhanh Galaxy S20 ULTRA để xem chiếc smartphone này có điểm gì đặc biệt bạn nhé.Thiết kế đẳng cấp Có thể nói, tổng thể Galaxy S20 ULTRA thoạt nhìn sẽ phù hợp với những bạn nam hơn là nữ. Bởi kích thước máy khá to và cụm camera sau hầm hố vô cùng mạnh mẽ.', 1,1);
-----END Thêm điện thoại thuộc hãng sx: SamSung, Loại sp là điện thoại

-----Thêm điện thoại thuộc hãng sx: Apple, Loại sp là điện thoại
insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone SE (2020)', N'iPhone_SE_(2020).jpeg', N'IPS LCD, 4.7", Retina', N'Apple A13 Bionic 6 nhân', N'7 MP', N'12 MP', N'iOS 13', N'4K', N'1821 mAh, có sạc nhanh', 6, N'Sau mỗi năm Apple sẽ có một chút thay đổi về thiết kế cho sản phẩm iPhone mới của mình. Tuy nhiên, với iPhone SE 2020 thì hoàn toàn khác. Máy có ngoại hình rất quen thuộc và nếu bạn đã từng dùng qua iPhone 8, iPhone 7 hay iPhone 6/6s sẽ cảm nhận rất rõ điều này. Theo đánh giá chi tiết iPhone SE 2020 của giới chuyên môn, thiết kế và màn hình của chiếc điện thoại này giống hệt với iPhone 8. Máy đi kèm màn LCD 4.7 inch, tùy nhiên nhờ được tích hợp công nghệ True Tone đã giúp cho màu sắc và độ sáng của iPhone SE 2020 tương tự như iPhone 11. Độ phân giải, hình ảnh sắc nét, màu sắc có độ chính xác cao, độ sáng tốt khi sử dụng ngoài trời.', 1,2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone XR', N'iPhone_XR.jpeg', N'IPS LCD 6.1 inch 1792 x 828 pixel', N'Apple A12 Bionic 6 nhân', N'7 MP', N'12 MP', N'IOS 12', N'4K, Chống rung quang học', N'2942 mah. Có sạc nhanh, 50% trong 30 phút. Sạc pin không dây', 6, N'Với mức giá bán "dễ chịu" nhất trong bộ sưu tập iPhone 2018, iPhone XR được người Việt quan tâm bởi thừa hưởng Face ID cùng màn hình tràn viền tai thỏ. Cùng Viettel Store mở hộp và đánh giá nhanh iPhone XR để xem chiếc smartphone này có điểm gì đặc biệt các bạn nhé.', 1, 2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone 11', N'iPhone_11.jpeg', N'IPS LCD, 6.1", Liquid Retina HD', N'Apple A13 Bionic 6 nhân', N'12 MP', N'Chính 12 MP & Phụ 12 MP', N'iOS 14', N'Quay phim HD 720p@30fps, Quay phim FullHD 1080p@30fps, Quay phim FullHD 1080p@60fps, Quay phim FullHD', N'3110 mAh', 6, N'Thiết kế iPhone 11 không khác nhiều so với các thông tin được rò rỉ trước đó. Và điều khiến tôi thất vọng nhất trong thiết kế là mặt trước. Apple vẫn trung thành với màn hình “tai thỏ”. Trong khi đó các dòng điện thoại cao cấp Android đã sử dụng màn hình notch, màn hình không viền vô cùng ấn tượng. Ngoài ra, một điểm trừ nữa trong thiết kế iPhone 11 là các cạnh viền vẫn còn rất dày tương tự iPhone XR.', 1, 2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone 12 Pro Max', N'iPhone_12_Pro_Max.jpeg', N'OLED; 6.7", Super Retina XDR display; 2778-by-1284-pixel resolution at 458 ppi', N'Apple A14 Bionic', N'12 MP; Xoá phông, Nhãn dán (AR Stickers)', N'3 camera 12 MP; FullHD 1080p@30fps', N'iOS 14', N'FullHD 1080p@30fps, 4K 2160p@30fps, HD 720p@30fps', N'3687 mAh; Li-Ion; Tiết kiệm pin, Sạc không dây, Sạc pin nhanh', 6, N'iPhone 12 Pro Max – một trong những lựa chọn đẳng cấp nhất dành cho khách hàng thích trải nghiệm mạnh mẽ, màn hình lớn và có mức giá cao nhất trong 4 chiếc iPhone ra mắt năm nay. Cùng Viettel Store đánh giá xem liệu sản phẩm này có điểm gì nổi bật nhé.', 1, 2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone 12 Pro', N'iPhone_12_Pro.jpeg', N'Super Retina XDR display 6.1‑inch', N'Apple A14 Bionic 6 nhân', N'12 MP; Xoá phông, Nhãn dán (AR Stickers), Retina Flash,', N'3 camera 12 MP; FullHD 1080p@30fps, 4K 2160p@30fps, HD 720p@30fps; Đèn LED kép; Ban đêm (Night Mode), Trôi nhanh thời gian (Time Lapse)', N'iOS 14', N'Quay video HD, Nhận diện khuôn mặt, Quay video Full HD, Tự động lấy nét (AF), HDR', N'2815 mAh; Li-Ion; Tiết kiệm pin, Sạc không dây, Sạc pin nhanh', 6, N'iPhone 12 Pro – một trong những lựa chọn dành cho khách hàng thích sự mạnh mẽ, cao cấp và nhỏ gọn, được rất nhiều người cân nhắc lựa chọn. Cùng Viettel Store đánh giá xem liệu sản phẩm này có điểm gì nổi bật nhé.Đánh giá chi tiết iPhone 12 Pro
Dù đã ra mắt được gần 1 năm xong iPhone 12 Pro vẫn là một trong những smartphone HOT nhất, đáng sở hữu nhất thời điểm hiện tại bởi:', 1, 2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone 12', N'iPhone 12.jpeg', N'OLED; Super Retina XDR display; 1170 x 2532 Pixels; 6.1"', N'Apple A14 Bionic 6 nhân', N'12 MP; Xoá phông, Quay phim 4K, Nhãn dán (AR Stickers)', N'2 camera 12 MP; FullHD 1080p@30fps, 4K 2160p@24fps, 4K 2160p@30fps, 4K 2160p@60fps, FullHD 1080p@120fps', N'iOS 14', N'FullHD 1080p@30fps, 4K 2160p@24fps, 4K 2160p@30fps, 4K 2160p@60fps', N'2815 mAh, Li-Ion; Sạc không dây MagSafe, Tiết kiệm pin, Sạc không dây, Sạc pin nhanh', 6, N'iPhone 12 là smartphone kế thừa những ưu điểm của iPhone 11 trước đó. Với ưu điểm về màu sắc phong phú, đa dạng thì iPhone 12 năm nay có thêm nhiều điểm rất ấn tượng. Cùng Viettel Store đánh giá nhanh iPhone 12 trong bài viết dưới đây.', 1, 2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone 5S', N'iPhone_5S.jpeg', N'4", LED-backlit IPS LCD, 640 x 1136 pixels', N'Apple A7, Dual-core 1.3 GHz', N'1.2 MP', N'8.0 MP', N'iOS 12', N'1080p@30fps', N'Li-Ion, 1560 mAh', 6, N'iPhone 5s 16gb Smartphone cao cấp của Apple iPhone 5s là một trong những siêu phẩm của Apple. Thiết kế tinh tế cùng cấu hình mạnh mẽ, tốc độ xử lý cực nhanh, máy ảnh thông minh đến bất ngờ đặc biệt  tính năng bảo mật bằng dấu vân tay đã khiến cho iPhone 5s 16gb này trở nên đắt giá trong mắt người dùng.', 1, 2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone 6s Plus', N'iPhone_6s_Plus.jpeg', N'5.5", Retina HD with 3D touch, 1920 x 1080 pixels', N'Apple A9 64-bit, Dual-core 1.84 GHz (chip đồng xử lý M9)', N'5 MP (Retina Flash)', N'12 MP (Live photos)', N'iOS 9', N'4K video recording', N'Li-Ion, 2750 mAh', 6, N'Ra mắt cùng lúc với iPhone 6s, iPhone 6s Plus được Apple ra mắt vào ngày 10/10 vừa qua là sự nâng cấp đặc biệt từ “người tiền nhiệm” iPhone 6 Plus và lược bỏ toàn bộ những điểm yếu mà tất cả iPhone đời trước mắc phải. Không chỉ là chiếc phablet mạnh mẽ về cấu hình, đa dạng về màu sắc, iPhone 6s Plus với công nghệ cảm ứng lực thông minh còn tạo nên một trải nghiệm mới mẻ trên chiếc smartphone màn hình lớn.', 1, 2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone 7 Plus', N'iPhone_7_Plus.jpeg', N'5.5". LED-backlit IPS LCD, 1920 x 1080 pixels', N'Apple A10 Fusion Intel A1784 lõi tứ 64-bit', N'7.0 MP', N'Hai Camera 12.0 MP', N'iOS 12', N'Quay phim 4K 2160p@30fps', N'Li-Ion 2900 mAh', 6, N'Thật không ngoa nếu nói iPhone 7 Plus 128gb là siêu phẩm đáng mua nhất hiện nay. Cả về thiết kế tinh tế cùng nhiều thay đổi đáng giá, camera kép lạ mắt chất lượng đến cấu hình được trang bị cao gấp 120 lần so với đời đầu.', 1, 2);

insert into SanPham(TenSanPham, AnhBia, ManHinh, CPU, Camera_Truoc, Camera_Sau, HeDieuHanh, QuayPhim, Pin, ThoiGianBaoHanh, ThongTinThemVeSP, MaLoaiSP, MaHangSX) 
values (N'iPhone 8 Plus', N'iPhone_8_Plus.jpeg', N'LED-backlit IPS LCD, Full HD (1080 x 1920 Pixels), 5.5", Kính cường lực oleophobic (ion cường lực)', N'Apple A11 Bionic 6 nhân', N'7.0 MP', N'Chính 12 MP & Phụ 12 MP', N'iOS 13', N'FullHD, Chống rung vật lý', N'2691 mAh, Pin chuẩn Li-Ion, Tiết kiệm pin, Sạc pin nhanh, Sạc pin không dây', 6, N'iPhone 8 Plus 128GB dù không có sự khác biệt nhiều về ngoại hình so với thế hệ tiền nhiệm nhưng những công nghệ ẩn chứa bên trong nó mới thực sự khiến chúng ta bất ngờ và thán phục sự sáng tạo của hãng điện thoại Mỹ - Apple', 1, 2);
-----END Thêm điện thoại thuộc hãng sx: Apple, Loại sp là điện thoại
-- =========================== END Thêm sản phẩm ================================= --
go
create table HinhAnh
(
	MaSanPham int primary key,
	HinhAnh1 nvarchar(255) null,
	HinhAnh2 nvarchar(255) null,
	HinhAnh3 nvarchar(255) null,
	HinhAnh4 nvarchar(255) null,
	foreign key(MaSanPham) references SanPham(MaSanPham),
)
go
insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (1,N'SamSungA32_1.jpeg', N'SamSungA32_2.jpeg', N'SamSungA32_3.jpeg', N'SamSungA32_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (2,N'SamSungA12_1.jpeg', N'SamSungA12_2.jpeg', N'SamSungA12_3.jpeg', N'SamSungA12_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (3,N'SamSungA12_1.jpeg', N'SamSungA12_2.jpeg', N'SamSungA12_3.jpeg', N'SamSungA12_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (4,N'Samsung_Galaxy_S20.jpeg', N'Samsung_Galaxy_S20_1.jpeg', N'Samsung_Galaxy_S20_2.jpeg', N'Samsung_Galaxy_S20_3.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (5,N'Samsung_Galaxy_Z_Flip3.jpeg', N'Samsung_Galaxy_Z_Flip3_1.jpeg', N'Samsung_Galaxy_Z_Flip3.jpeg', N'Samsung_Galaxy_Z_Flip3.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (6,N'Samsung_E1200_1.jpeg', N'Samsung_E1200_2.jpeg', N'Samsung_E1200_3.jpeg', N'Samsung_E1200_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (7,N'Samsung_Galaxy_Note20_Ultra.jpeg', N'Samsung_Galaxy_Note20_Ultra_1.jpeg', N'Samsung_Galaxy_Note20_Ultra_2.jpeg', N'Samsung_Galaxy_Note20_Ultra_3.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (8,N'Samsung_Galaxy_Note_10.png', N'Samsung_Galaxy_Note_10_1.png', N'Samsung_Galaxy_Note_10_2.png', N'Samsung_Galaxy_Note_10_3.png');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (9,N'Samsung_Galaxy_M21.jpeg', N'Samsung_Galaxy_M21_1.jpeg', N'Samsung_Galaxy_M21_2.jpeg', N'Samsung_Galaxy_M21_3.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (10,N'Samsung_Galaxy_A51.jpeg', N'Samsung_Galaxy_A51_1.jpeg', N'Samsung_Galaxy_A51_2.jpeg', N'Samsung_Galaxy_A51_3.jpeg'); 

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (11,N'Samsung_Galaxy_A52.jpeg', N'Samsung_Galaxy_A52_1.jpeg', N'Samsung_Galaxy_A52_2.jpeg', N'Samsung_Galaxy_A52_3.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (12,N'Samsung_Galaxy_S20_Ultra.jpeg', N'Samsung_Galaxy_S20_Ultra_1.jpeg', N'Samsung_Galaxy_S20_Ultra_1.jpeg', N'Samsung_Galaxy_S20_Ultra_3.jpeg');
--apple
insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (13,N'iPhone_SE_(2020)_1.jpeg', N'iPhone_SE_(2020)_2.jpeg', N'iPhone_SE_(2020)_3.jpeg', N'iPhone_SE_(2020)_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (14,N'iPhone_XR_1.jpeg', N'iPhone_XR_2.jpeg', N'iPhone_XR_3.jpeg', N'iPhone_XR_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (15,N'iPhone_11_1.jpeg', N'iPhone_11_2.jpeg', N'iPhone_11_3.jpeg', N'iPhone_11_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (16,N'iPhone_12_Pro_Max_1.jpeg', N'iPhone_12_Pro_Max_2.jpeg', N'iPhone_12_Pro_Max_3.jpeg', N'iPhone_12_Pro_Max_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (17,N'iPhone_12_Pro_1.jpeg', N'iPhone_12_Pro_2.jpeg', N'iPhone_12_Pro_3.jpeg', N'iPhone_12_Pro_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (18,N'iPhone_12_1.jpeg', N'iPhone_12_2.jpeg', N'iPhone_12_3.jpeg', N'iPhone_12_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (19,N'iPhone_5S_1.jpeg', N'iPhone_5S_2.jpeg', N'iPhone_5S_3.jpeg', N'iPhone_5S_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (20,N'iPhone_6s_Plus_1.jpeg', N'iPhone_6s_Plus_2.jpeg', N'iPhone_6s_Plus_3.jpeg', N'iPhone_6s_Plus_4.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (21,N'iPhone_7_Plus.jpeg', N'iPhone_7_Plus_1.jpeg', N'iPhone_7_Plus_2.jpeg', N'iPhone_7_Plus_1.jpeg');

insert into HinhAnh(MaSanPham, HinhAnh1, HinhAnh2, HinhAnh3, HinhAnh4) 
values (22,N'iPhone_8_Plus.jpeg', N'iPhone_8_Plus_1.jpeg', N'iPhone_8_Plus_2.jpeg', N'iPhone_8_Plus_1.jpeg');
--go
create table BinhLuan
(
	TaiKhoanKH varchar(50),
	MaSanPham int,
	primary key(TaiKhoanKH,MaSanPham),
	NoiDungBinhLuan nvarchar(255) null,
	NgayBinhLuan date default(getdate()),
	foreign key(TaiKhoanKH) references KhachHang(TaiKhoanKH),
	foreign key(MaSanPham) references SanPham(MaSanPham),
)
go
insert into BinhLuan(TaiKhoanKH, MaSanPham, NoiDungBinhLuan, NgayBinhLuan)
values('NguyenMinh', 1, 'Điện Thoại giá rẽ, chất lượng', default);
insert into BinhLuan(TaiKhoanKH, MaSanPham, NoiDungBinhLuan, NgayBinhLuan)
values('NguyenMinh', 2, 'Điện Thoại giá rẽ, chất lượng', default);
insert into BinhLuan(TaiKhoanKH, MaSanPham, NoiDungBinhLuan, NgayBinhLuan)
values('NguyenMinh', 3, 'Điện Thoại giá rẽ, chất lượng', default);
insert into BinhLuan(TaiKhoanKH, MaSanPham, NoiDungBinhLuan, NgayBinhLuan)
values('NguyenMinh', 4, 'Điện Thoại giá rẽ, chất lượng', default);
insert into BinhLuan(TaiKhoanKH, MaSanPham, NoiDungBinhLuan, NgayBinhLuan)
values('NguyenMinh', 5, 'Điện Thoại giá rẽ, chất lượng', default);
go
create table ChiTietDonHang
(
	MaDonHang int,
	MaSanPham int,
	MaMauSac int,
	Rom int,
	Ram int,
	primary key(MaDonHang,MaSanPham, MaMauSac, Rom, Ram),
	SoLuongMua int default(0),
	ThanhTien money default(0),
	foreign key(MaDonHang) references DonHang(MaDonHang),
	foreign key(MaSanPham) references SanPham(MaSanPham),
)
go
insert into ChiTietDonHang(MaDonHang, MaSanPham, MaMauSac, Rom, Ram, SoLuongMua, ThanhTien) 
values(1, 1, 1, 6, 64, 2, 150000);
insert into ChiTietDonHang(MaDonHang, MaSanPham, MaMauSac, Rom, Ram, SoLuongMua, ThanhTien) 
values(1, 2, 1, 6, 64, 5, 1200000);
insert into ChiTietDonHang(MaDonHang, MaSanPham, MaMauSac, Rom, Ram, SoLuongMua, ThanhTien)  
values(1, 3, 2, 6, 64, 8, 7000000);
insert into ChiTietDonHang(MaDonHang, MaSanPham, MaMauSac, Rom, Ram, SoLuongMua, ThanhTien) 
values(1, 4, 6, 64, 3,12, 6000000);
insert into ChiTietDonHang(MaDonHang, MaSanPham, MaMauSac, Rom, Ram, SoLuongMua, ThanhTien) 
values(1, 5, 6, 64, 2,1, 2000000);
go
create table ChiTietSP
(
	MaSanPham int,
	MaMauSac int,
	Rom int,
	Ram int,
	primary key(MaSanPham,MaMauSac, Rom, Ram),
	GiaGoc money null,
	GiaBan money null,
	SoLuong int default(0),
	SoLuongDaBan int default(0),
	Moi int null,
	foreign key(MaSanPham) references SanPham(MaSanPham),
	foreign key(MaMauSac) references MauSac(MaMauSac),
)
go
insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(1, 1, 6, 64, 6000000, 450000, 20, 5, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(1, 1, 6, 128, 6500000, 6000000, 20, 5);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(1, 2, 6, 64, 6000000, 5000000, 10, 3);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(1, 2, 8, 256, 8000000, 9000000, 10, 3);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(1, 3, 1, 16, 5500000, 4000000, 10, 3);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(2, 6, 4, 128, 4000000, 3500000, 7, 2, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(2, 4, 4, 128, 4200000, 3800000, 7, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(2, 3, 4, 64, 4500000, 4400000, 8, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(2, 3, 4, 128, 5000000, 4500000, 7, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(2, 8, 6, 64, 3500000, 3400000, 10, 15);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(3, 9, 8, 128, 15000000, 14500000, 25, 2, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(3, 9, 6, 64, 13000000, 12500000, 25, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(3, 1, 6, 64, 13000000, 12000000, 25, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(3, 1, 4, 32, 10000000, 9000000, 6, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(3, 7, 6, 64, 14000000, 12500000, 17, 4);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(3, 7, 8, 256, 17000000, 15500000, 25, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(4, 1, 8, 128, 20000000, 19000000, 9, 2, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(4, 1, 6, 64, 18000000, 17000000, 26, 12);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(4, 2, 6, 64, 18500000, 17200000, 26, 12);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(4, 2, 8, 256, 24000000, 23000000, 6, 5);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(4, 3, 6, 64, 18000000, 14000000, 26, 12);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(5, 1, 8, 128, 30000000, 28000000, 1, 1, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(5, 1, 6, 64, 29000000, 275000000, 10, 0);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(5, 6, 6, 64, 27000000, 27000000, 10, 9);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(5, 7, 6, 64, 27000000, 27000000, 0, 6);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(6, 1, 1, 16, 1000000, 5000000, 8, 7, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(6, 7, 1, 16, 1000000, 4000000, 2, 7);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(7, 1, 12, 256, 28000000, 27000000, 8, 7, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(7, 1, 6, 64, 25000000, 23000000, 4, 4);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(7, 2, 6, 64, 25000000, 23500000, 4, 6);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(8, 1, 12, 256, 23000000, 20000000, 12, 7, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(8, 2, 12, 256, 22000000, 21000000, 7, 7);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(8, 1, 6, 64, 20000000, 19000000, 12, 7);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(8, 4, 6, 64, 20000000, 18000000, 1, 9);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(9, 1, 4, 64, 6000000, 5000000, 20, 35, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(9, 6, 4, 64, 6000000, 5500000, 20, 14 );

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(9, 6, 4, 32, 6000000, 4500000, 12, 30 );

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(10, 6, 6, 128, 9000000, 85000000, 2, 32, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(10, 6, 4, 32, 9000000, 6500000, 2, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(10, 1, 16, 256, 10000000, 9500000, 2, 12);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(10, 2, 16, 256, 10000000, 9500000, 2, 12);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(10, 2, 16, 128, 10000000, 8000000, 2, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(11, 7, 6, 128, 8500000, 8300000, 12, 32, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(11, 7, 6, 64, 8000000, 7200000, 12, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(11, 4, 6, 64, 8200000, 7300000, 12, 32);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(11, 5, 6, 128, 8500000, 8400000, 12, 32);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(12, 1, 12, 128, 14500000, 14000000, 20, 32, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(12, 1, 6, 128, 14000000, 13800000, 22, 16);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(12, 1, 6, 64, 12000000, 11800000, 21, 8);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(12, 2, 6, 64, 13000000, 12000000, 2, 8);

-- apple 
insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(13, 1, 3, 64, 9000000, 8000000, 8, 21, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(13, 1, 6, 128, 10000000, 9500000, 20, 4);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(13, 7, 3, 64, 9000000, 7000000, 20, 14);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(13, 7, 6, 128, 10000000, 9400000, 17, 6);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(13, 4, 3, 64, 9000000, 7500000, 22, 32);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(13, 4, 6, 128, 10000000, 9300000, 3, 8);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(14, 1, 3, 64, 12000000, 11000000, 8, 21, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(14, 1, 6, 128, 15000000, 14000000, 8, 21);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(14, 6, 3, 64, 12000000, 11000000, 18, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(14, 6, 6, 128, 15000000, 13000000, 18, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(14, 4, 3, 64, 12000000, 11000000, 18, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(14, 4, 6, 128, 15000000, 13000000, 18, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(14, 3, 3, 64, 12500000, 12000000, 8, 20);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(14, 3, 6, 128, 15000000, 14500000, 18, 14);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(15, 1, 4, 128, 16400000, 16000000, 20, 21, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(15, 1, 4, 64, 14400000, 14000000, 20, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(15, 7, 4, 64, 14400000, 14000000, 24, 15);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(15, 7, 4, 128, 16400000, 15400000, 8, 9);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(15, 5, 4, 64, 14400000, 13000000, 31, 15);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(15, 5, 4, 128, 16400000, 12400000, 18, 19);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(16, 8, 6, 512, 32500000, 32000000, 8, 8, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(16, 8, 6, 128, 29500000, 29000000, 12, 18);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(16, 1, 6, 128, 29500000, 29500000, 22, 4);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(16, 1, 6, 512, 32500000, 30000000, 12, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(16, 7, 6, 128, 30000000, 28000000, 6, 4);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(16, 7, 6, 512, 32500000, 30500000, 9, 11);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(17, 1, 6, 512, 28500000, 28000000, 8, 8, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(17, 1, 6, 64, 28000000, 24000000, 9, 11);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(17, 2, 6, 64, 28000000, 22000000, 19, 5);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(17, 2, 6, 128, 28000000, 23500000, 19, 11);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(17, 3, 6, 64, 21000000, 20000000, 8, 5);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(17, 3, 6, 128, 24000000, 23000000, 7, 11);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(18, 1, 6, 512, 18000000, 17000000, 6, 22, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(18, 1, 6, 64, 14000000, 14000000, 15, 9);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(18, 2, 6, 512, 18500000, 17500000, 9, 18);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(18, 2, 6, 64, 14000000, 13000000, 14, 22);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(18, 3, 6, 512, 19500000, 18500000, 9, 18);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(18, 4, 6, 64, 12500000, 12000000, 6, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(19, 2, 4, 16, 0, 0, 0, 85, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(19, 2, 6, 64, 0, 0, 0, 14);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(20, 1, 6, 64, 7000000, 6000000, 0, 47, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(20, 1, 4, 16, 5000000, 4500000, 0, 21);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(20, 3, 4, 16, 6999000, 5500000, 0, 8);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(20, 3, 8, 128, 8000000, 7000000, 0, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(21, 1, 6, 64, 7000000, 6800000, 12, 47, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(21, 1, 8, 128, 9000000, 8800000, 9, 14);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(21, 1, 4, 16, 5000000, 4000000, 5, 2);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(21, 4, 8, 128, 9000000, 8000000, 19, 3);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(21, 4, 4, 16, 5500000, 4500000, 10, 10);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(21, 3, 4, 16, 5500000, 4800000, 0, 20);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(21, 3, 8, 128, 5500000, 4900000, 5, 29);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan, Moi) 
values(22, 1, 6, 64, 9999999, 9000000, 22, 42, 1);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(22, 1, 8, 256, 11990000, 11000000, 3, 21); 

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(22, 2, 8, 256, 11990000, 10999000, 31, 9);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(22, 2, 6, 64, 9990000, 9000000, 8, 26);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(22, 3, 8, 256, 10000000, 9000000, 12, 32);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(22, 3, 6, 64, 8000000, 7500000, 19, 6);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(22, 4, 8, 256, 11990000, 9000000, 22, 29);

insert into ChiTietSP(MaSanPham, MaMauSac, Rom, Ram, GiaGoc, GiaBan, SoLuong, SoLuongDaBan) 
values(22, 4, 6, 64, 8990000, 8000000, 28, 26);
go
create table PhieuNhap
(
	MaPhieuNhap int identity(1,1) primary key,
	NgayNhapKho date default(getdate()),
	TongTien money default(0),
	TaiKhoanNV varchar(50),
	foreign key(TaiKhoanNV) references NhanVien(TaiKhoanNV),
)
go
insert into PhieuNhap(NgayNhapKho, TongTien, TaiKhoanNV) 
values('04/05/2021', 4500000,'Admin');
insert into PhieuNhap(NgayNhapKho, TongTien, TaiKhoanNV) 
values('04/01/2021', 4000000,'Admin');
insert into PhieuNhap(NgayNhapKho, TongTien, TaiKhoanNV) 
values('04/02/2021', 2500000,'Admin');
insert into PhieuNhap(NgayNhapKho, TongTien, TaiKhoanNV) 
values('04/04/2021', 30000000,'Admin');
insert into PhieuNhap(NgayNhapKho, TongTien, TaiKhoanNV) 
values(default, 4500000,'Admin');
go
create table ChiTietPhieuNhap
(
	MaSanPham int,
	MaPhieuNhap int,
	primary key (MaSanPham, MaPhieuNhap),
	SoLuongNhap int,
	foreign key(MaSanPham) references SanPham(MaSanPham),
	foreign key(MaPhieuNhap) references PhieuNhap(MaPhieuNhap),
)
go
insert into ChiTietPhieuNhap(MaSanPham, MaPhieuNhap, SoLuongNhap) 
values(1, 1, 10);
insert into ChiTietPhieuNhap(MaSanPham, MaPhieuNhap, SoLuongNhap) 
values(2, 2, 20);
insert into ChiTietPhieuNhap(MaSanPham, MaPhieuNhap, SoLuongNhap) 
values(3, 3, 40);
insert into ChiTietPhieuNhap(MaSanPham, MaPhieuNhap, SoLuongNhap) 
values(4, 4, 8);
insert into ChiTietPhieuNhap(MaSanPham, MaPhieuNhap, SoLuongNhap) 
values(5, 5, 9);

