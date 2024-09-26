using System;
using System.Collections.Generic;

namespace WebBanVali.Models;

public partial class PhuThu
{
    public string MaPhuThu { get; set; } = null!;

    public string? TenPhuThu { get; set; }

    public decimal? GiaPhuThu { get; set; }

    public virtual ICollection<PhongPhuThu> PhongPhuThus { get; set; } = new List<PhongPhuThu>();
}
