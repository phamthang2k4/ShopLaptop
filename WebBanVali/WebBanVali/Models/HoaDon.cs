using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class HoaDon
{
    public string MaHoaDon { get; set; } = null!;

    public DateTime? NgayThanhToan { get; set; }

    public string? MaKhachHang { get; set; }

    public string? MaNhanVien { get; set; }

    public virtual ICollection<KhuyenMai> KhuyenMais { get; set; } = new List<KhuyenMai>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
