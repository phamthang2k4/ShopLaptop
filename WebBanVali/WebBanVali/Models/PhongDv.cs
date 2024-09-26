using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class PhongDv
{
    public string MaPhong { get; set; } = null!;

    public string MaDichVu { get; set; } = null!;

    public DateTime? ThoiGian { get; set; }

    public int? SoLuong { get; set; }

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
