using prjShoeStore.Data;
using prjShoeStore.DTO;
using prjShoeStore.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Respositories
{
    public class ProductRespository : IProductRespository
    {
        private readonly AppDbContext _Context;
        public ProductRespository(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }
        public IQueryable<CartDTO> GetQueryProductCart()
        {

            var groupby = (from ctpn in _Context.CTPNs
                           join pn in _Context.PhieuNhaps
                           on ctpn.IdPhieuNhap equals pn.Id
                           group new { ctpn.IdSanPham, ctpn.KichThuoc, ctpn.IdPhieuNhap, pn.NgayLap }
                           by new { ctpn.IdSanPham, ctpn.KichThuoc, ctpn.IdPhieuNhap }
                           into gr
                           select new { gr.Key.IdPhieuNhap, gr.Key.IdSanPham, gr.Key.KichThuoc, NgayLap = gr.Max(x => x.NgayLap) });

            var AmountImport = _Context.CTPNs.GroupBy(x => new { x.KichThuoc, x.IdSanPham }).Select(x => new
            {
                x.Key.IdSanPham,
                x.Key.KichThuoc,
                Amount = x.Sum(x => x.SoLuong)
            });

            var AmountExport = _Context.CTDDHs.GroupBy(x => new { x.KichThuoc, x.IdSanPham }).Select(x => new
            {
                x.Key.IdSanPham,
                x.Key.KichThuoc,
                Amount = x.Sum(x => x.SoLuong)
            });

            var AmountQry = (from ai in AmountImport
                             join ae in AmountExport
                             on new { ai.IdSanPham, ai.KichThuoc } equals new { ae.IdSanPham, ae.KichThuoc }
                             into details
                             from d in details.DefaultIfEmpty()
                             select new
                             {
                                 ai.IdSanPham,
                                 ai.KichThuoc,
                                 Amount = ai.Amount - (d == null ? 0 : d.Amount)
                             });

            return (from ctpn in _Context.CTPNs
                    join pn in _Context.PhieuNhaps on ctpn.IdPhieuNhap equals pn.Id
                    join gr in groupby on new { ctpn.IdPhieuNhap, ctpn.IdSanPham, ctpn.KichThuoc, pn.NgayLap } equals new { gr.IdPhieuNhap, gr.IdSanPham, gr.KichThuoc, gr.NgayLap }
                    join aq in AmountQry on new { ctpn.IdSanPham, ctpn.KichThuoc } equals new { aq.IdSanPham, aq.KichThuoc }
                    select new CartDTO
                    {
                        Id = ctpn.IdSanPham,
                        Price = ctpn.Gia,
                        Size = ctpn.KichThuoc,
                        Amount = aq.Amount
                    });
        }
    }
}
