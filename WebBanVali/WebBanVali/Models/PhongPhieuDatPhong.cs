using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class PhongPhieuDatPhong
{
    public string MaPhong { get; set; } = null!;

    public string MaPhieuDatPhong { get; set; } = null!;

    public DateTime? NgayNhanPhong { get; set; }

    public DateTime? NgayTraPhong { get; set; }

    public virtual PhieuDatPhong MaPhieuDatPhongNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
