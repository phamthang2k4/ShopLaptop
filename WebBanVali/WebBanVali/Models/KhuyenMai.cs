using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class KhuyenMai
{
    public string MaKhuyenMai { get; set; } = null!;

    public string? TenKhuyenMai { get; set; }

    public string? LoaiKhuyenMai { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? MaHoaDon { get; set; }

    public virtual HoaDon? MaHoaDonNavigation { get; set; }
}
