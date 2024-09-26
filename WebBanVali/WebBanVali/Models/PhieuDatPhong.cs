using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class PhieuDatPhong
{
    public string MaPhieuDatPhong { get; set; } = null!;

    public decimal? TienCoc { get; set; }

    public DateTime? ThoiGianDatPhong { get; set; }

    public string? MaKhachHang { get; set; }

    public int? SoLuongKhach { get; set; }

    public DateTime? NgayDen { get; set; }

    public DateTime? NgayDi { get; set; }

    public string? MaNhanVien { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual ICollection<PhongPhieuDatPhong> PhongPhieuDatPhongs { get; set; } = new List<PhongPhieuDatPhong>();
}
