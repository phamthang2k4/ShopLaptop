using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class NvPhong
{
    public string MaNhanVien { get; set; } = null!;

    public string MaPhong { get; set; } = null!;

    public DateTime? NgayBatDauLamViec { get; set; }

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
