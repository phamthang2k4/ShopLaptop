using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class PhongPhuThu
{
    public string MaPhong { get; set; } = null!;

    public string MaPhuThu { get; set; } = null!;

    public int? SoLuong { get; set; }

    public virtual Phong MaPhongNavigation { get; set; } = null!;

    public virtual PhuThu MaPhuThuNavigation { get; set; } = null!;
}
