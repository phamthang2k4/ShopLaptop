using WebBanVali.Models;

namespace WebBanVali.Respository
{
    public class loaiSanPhamRespository:ILoaiSanPhamRepository
    {
        private readonly MasterContext _context;
        public loaiSanPhamRespository(MasterContext context)
        {
            _context = context;
        }
public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp Delete(string maloai)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(string maloai)
        {
            throw new NotImplementedException();
        }

        public TLoaiSp Update(string maloai)
        {
            throw new NotImplementedException();
        }
    }
}
