using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string? TenNhanVien { get; set; }

    public decimal? Luong { get; set; }

    public int? Tuoi { get; set; }

    public string? GioiTinh { get; set; }

    public string? ChucVu { get; set; }

    public string? Email { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<NvPhong> NvPhongs { get; set; } = new List<NvPhong>();

    public virtual ICollection<PhieuDatPhong> PhieuDatPhongs { get; set; } = new List<PhieuDatPhong>();
}
