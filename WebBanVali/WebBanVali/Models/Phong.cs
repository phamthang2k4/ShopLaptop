using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class Phong
{
    public string MaPhong { get; set; } = null!;

    public decimal? GiaPhong { get; set; }

    public string? LoaiPhong { get; set; }

    public string? MaThongTinThuePhong { get; set; }

    public string? MaHoaDon { get; set; }

    public virtual HoaDon? MaHoaDonNavigation { get; set; }

    public virtual ICollection<NvPhong> NvPhongs { get; set; } = new List<NvPhong>();

    public virtual ICollection<PhongDv> PhongDvs { get; set; } = new List<PhongDv>();

    public virtual ICollection<PhongPhieuDatPhong> PhongPhieuDatPhongs { get; set; } = new List<PhongPhieuDatPhong>();

    public virtual ICollection<PhongPhuThu> PhongPhuThus { get; set; } = new List<PhongPhuThu>();
}
