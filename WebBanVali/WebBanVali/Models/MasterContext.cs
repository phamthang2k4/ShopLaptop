using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanVali.Models;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NvPhong> NvPhongs { get; set; }

    public virtual DbSet<PhieuDatPhong> PhieuDatPhongs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<PhongDv> PhongDvs { get; set; }

    public virtual DbSet<PhongPhieuDatPhong> PhongPhieuDatPhongs { get; set; }

    public virtual DbSet<PhongPhuThu> PhongPhuThus { get; set; }

    public virtual DbSet<PhuThu> PhuThus { get; set; }

    public virtual DbSet<TAnhChiTietSp> TAnhChiTietSps { get; set; }

    public virtual DbSet<TAnhSp> TAnhSps { get; set; }

    public virtual DbSet<TChatLieu> TChatLieus { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietSanPham> TChiTietSanPhams { get; set; }

    public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; }

    public virtual DbSet<THangSx> THangSxes { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TKichThuoc> TKichThuocs { get; set; }

    public virtual DbSet<TLoaiDt> TLoaiDts { get; set; }

    public virtual DbSet<TLoaiSp> TLoaiSps { get; set; }

    public virtual DbSet<TMauSac> TMauSacs { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TQuocGium> TQuocGia { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WINDOWS-11\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu);

            entity.ToTable("DichVu");

            entity.Property(e => e.MaDichVu).HasMaxLength(10);
            entity.Property(e => e.GiaDichVu).HasColumnType("money");
            entity.Property(e => e.MaNhanVien).HasMaxLength(10);
            entity.Property(e => e.TenDichVu).HasMaxLength(50);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_DichVu_NhanVien");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHoaDon).HasMaxLength(10);
            entity.Property(e => e.MaKhachHang).HasMaxLength(10);
            entity.Property(e => e.MaNhanVien).HasMaxLength(10);
            entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_HoaDon_KhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_HoaDon_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang);

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).HasMaxLength(10);
            entity.Property(e => e.Cccd)
                .HasMaxLength(15)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TenKhachHang).HasMaxLength(50);
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKhuyenMai);

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKhuyenMai).HasMaxLength(10);
            entity.Property(e => e.LoaiKhuyenMai).HasMaxLength(15);
            entity.Property(e => e.MaHoaDon).HasMaxLength(10);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.TenKhuyenMai).HasMaxLength(50);

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.KhuyenMais)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK_KhuyenMai_HoaDon");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien);

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(10);
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.GioiTinh).HasMaxLength(15);
            entity.Property(e => e.Luong).HasColumnType("money");
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TenNhanVien).HasMaxLength(50);
        });

        modelBuilder.Entity<NvPhong>(entity =>
        {
            entity.HasKey(e => new { e.MaNhanVien, e.MaPhong });

            entity.ToTable("NV_Phong");

            entity.Property(e => e.MaNhanVien).HasMaxLength(10);
            entity.Property(e => e.MaPhong).HasMaxLength(10);
            entity.Property(e => e.NgayBatDauLamViec).HasColumnType("datetime");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.NvPhongs)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NV_Phong_NhanVien");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.NvPhongs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NV_Phong_Phong");
        });

        modelBuilder.Entity<PhieuDatPhong>(entity =>
        {
            entity.HasKey(e => e.MaPhieuDatPhong);

            entity.ToTable("PhieuDatPhong");

            entity.Property(e => e.MaPhieuDatPhong).HasMaxLength(10);
            entity.Property(e => e.MaKhachHang).HasMaxLength(10);
            entity.Property(e => e.MaNhanVien).HasMaxLength(10);
            entity.Property(e => e.NgayDen).HasColumnType("datetime");
            entity.Property(e => e.NgayDi).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianDatPhong).HasColumnType("datetime");
            entity.Property(e => e.TienCoc).HasColumnType("money");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.PhieuDatPhongs)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_PhieuDatPhong_KhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.PhieuDatPhongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_PhieuDatPhong_NhanVien");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong);

            entity.ToTable("Phong");

            entity.Property(e => e.MaPhong).HasMaxLength(10);
            entity.Property(e => e.GiaPhong).HasColumnType("money");
            entity.Property(e => e.LoaiPhong).HasMaxLength(20);
            entity.Property(e => e.MaHoaDon).HasMaxLength(10);
            entity.Property(e => e.MaThongTinThuePhong).HasMaxLength(10);

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK_Phong_HoaDon");
        });

        modelBuilder.Entity<PhongDv>(entity =>
        {
            entity.HasKey(e => new { e.MaPhong, e.MaDichVu });

            entity.ToTable("Phong_DV");

            entity.Property(e => e.MaPhong).HasMaxLength(10);
            entity.Property(e => e.MaDichVu).HasMaxLength(10);
            entity.Property(e => e.ThoiGian).HasColumnType("datetime");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.PhongDvs)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_DV_DichVu");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.PhongDvs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_DV_Phong");
        });

        modelBuilder.Entity<PhongPhieuDatPhong>(entity =>
        {
            entity.HasKey(e => new { e.MaPhong, e.MaPhieuDatPhong });

            entity.ToTable("Phong_PhieuDatPhong");

            entity.Property(e => e.MaPhong).HasMaxLength(10);
            entity.Property(e => e.MaPhieuDatPhong).HasMaxLength(10);
            entity.Property(e => e.NgayNhanPhong).HasColumnType("datetime");
            entity.Property(e => e.NgayTraPhong).HasColumnType("datetime");

            entity.HasOne(d => d.MaPhieuDatPhongNavigation).WithMany(p => p.PhongPhieuDatPhongs)
                .HasForeignKey(d => d.MaPhieuDatPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_PhieuDatPhong_PhieuDatPhong");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.PhongPhieuDatPhongs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_PhieuDatPhong_Phong");
        });

        modelBuilder.Entity<PhongPhuThu>(entity =>
        {
            entity.HasKey(e => new { e.MaPhong, e.MaPhuThu });

            entity.ToTable("Phong_PhuThu");

            entity.Property(e => e.MaPhong).HasMaxLength(10);
            entity.Property(e => e.MaPhuThu).HasMaxLength(10);

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.PhongPhuThus)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_PhuThu_Phong");

            entity.HasOne(d => d.MaPhuThuNavigation).WithMany(p => p.PhongPhuThus)
                .HasForeignKey(d => d.MaPhuThu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_PhuThu_PhuThu");
        });

        modelBuilder.Entity<PhuThu>(entity =>
        {
            entity.HasKey(e => e.MaPhuThu);

            entity.ToTable("PhuThu");

            entity.Property(e => e.MaPhuThu).HasMaxLength(10);
            entity.Property(e => e.GiaPhuThu).HasColumnType("money");
            entity.Property(e => e.TenPhuThu).HasMaxLength(50);
        });

        modelBuilder.Entity<TAnhChiTietSp>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietSp, e.TenFileAnh });

            entity.ToTable("tAnhChiTietSP");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.TenFileAnh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TAnhChiTietSps)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhChiTietSP_tChiTietSanPham");
        });

        modelBuilder.Entity<TAnhSp>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.TenFileAnh });

            entity.ToTable("tAnhSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.TenFileAnh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TAnhSps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhSP_tDanhMucSP");
        });

        modelBuilder.Entity<TChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu);

            entity.ToTable("tChatLieu");

            entity.Property(e => e.MaChatLieu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChatLieu).HasMaxLength(150);
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaChiTietSp });

            entity.ToTable("tChiTietHDB");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.GhiChu).HasMaxLength(100);

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tChiTietSanPham");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tHoaDonBan");
        });

        modelBuilder.Entity<TChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSp);

            entity.ToTable("tChiTietSanPham");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaMauSac)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.Slton).HasColumnName("SLTon");
            entity.Property(e => e.Video)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK_tChiTietSanPham_tKichThuoc");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaMauSac)
                .HasConstraintName("FK_tChiTietSanPham_tMauSac");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK_tChiTietSanPham_tDanhMucSP");
        });

        modelBuilder.Entity<TDanhMucSp>(entity =>
        {
            entity.HasKey(e => e.MaSp);

            entity.ToTable("tDanhMucSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GiaLonNhat).HasColumnType("money");
            entity.Property(e => e.GiaNhoNhat).HasColumnType("money");
            entity.Property(e => e.GioiThieuSp)
                .HasMaxLength(255)
                .HasColumnName("GioiThieuSP");
            entity.Property(e => e.MaChatLieu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaDacTinh)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaDt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDT");
            entity.Property(e => e.MaHangSx)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHangSX");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNuocSx)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNuocSX");
            entity.Property(e => e.Model).HasMaxLength(55);
            entity.Property(e => e.NganLapTop).HasMaxLength(55);
            entity.Property(e => e.TenSp)
                .HasMaxLength(150)
                .HasColumnName("TenSP");
            entity.Property(e => e.Website)
                .HasMaxLength(155)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaChatLieu)
                .HasConstraintName("FK_tDanhMucSP_tChatLieu");

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaDt)
                .HasConstraintName("FK_tDanhMucSP_tLoaiDT");

            entity.HasOne(d => d.MaHangSxNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaHangSx)
                .HasConstraintName("FK_tDanhMucSP_tHangSX");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_tDanhMucSP_tLoaiSP");

            entity.HasOne(d => d.MaNuocSxNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaNuocSx)
                .HasConstraintName("FK_tDanhMucSP_tQuocGia");
        });

        modelBuilder.Entity<THangSx>(entity =>
        {
            entity.HasKey(e => e.MaHangSx);

            entity.ToTable("tHangSX");

            entity.Property(e => e.MaHangSx)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHangSX");
            entity.Property(e => e.HangSx)
                .HasMaxLength(100)
                .HasColumnName("HangSX");
            entity.Property(e => e.MaNuocThuongHieu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");
            entity.Property(e => e.ThongTinThue).HasMaxLength(250);
            entity.Property(e => e.TongTienHd)
                .HasColumnType("money")
                .HasColumnName("TongTienHD");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_tHoaDonBan_tKhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_tHoaDonBan_tNhanVien");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhanhHang);

            entity.ToTable("tKhachHang");

            entity.Property(e => e.MaKhanhHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TKhachHangs)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_tKhachHang_tUser");
        });

        modelBuilder.Entity<TKichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc);

            entity.ToTable("tKichThuoc");

            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.KichThuoc)
                .HasMaxLength(150)
                .IsFixedLength();
        });

        modelBuilder.Entity<TLoaiDt>(entity =>
        {
            entity.HasKey(e => e.MaDt);

            entity.ToTable("tLoaiDT");

            entity.Property(e => e.MaDt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDT");
            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<TLoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("tLoaiSP");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Loai).HasMaxLength(100);
        });

        modelBuilder.Entity<TMauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac);

            entity.ToTable("tMauSac");

            entity.Property(e => e.MaMauSac)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenMauSac).HasMaxLength(100);
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien);

            entity.ToTable("tNhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SoDienThoai2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNhanVien).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TNhanViens)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_tNhanVien_tUser");
        });

        modelBuilder.Entity<TQuocGium>(entity =>
        {
            entity.HasKey(e => e.MaNuoc);

            entity.ToTable("tQuocGia");

            entity.Property(e => e.MaNuoc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNuoc).HasMaxLength(100);
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("tUser");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
