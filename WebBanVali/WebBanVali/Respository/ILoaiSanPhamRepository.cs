using WebBanVali.Models;

namespace WebBanVali.Respository
{
    public interface ILoaiSanPhamRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(string maloai);
        TLoaiSp Delete(string maloai);
        TLoaiSp GetLoaiSp(string maloai);
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
