using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class DichVu
{
    public string MaDichVu { get; set; } = null!;

    public string? TenDichVu { get; set; }

    public decimal? GiaDichVu { get; set; }

    public string? MaNhanVien { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual ICollection<PhongDv> PhongDvs { get; set; } = new List<PhongDv>();
}
