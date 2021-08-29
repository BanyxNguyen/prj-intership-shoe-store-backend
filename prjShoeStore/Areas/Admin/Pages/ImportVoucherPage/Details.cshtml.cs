using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;
using prjShoeStore.DTO;

namespace prjShoeStore.Areas.Admin.Pages.ImportVoucherPage
{
    public class ValiateError
    {
        public int Index { get; set; }
        public IList<string> message { get; set; }
    }
    public class DetailsModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public DetailsModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public PhieuNhap PhieuNhap { get; set; }
        [BindProperty]
        public IList<CTPNDTO> CTPNs { get; set; }
        public IList<SanPhamSelect> SanPhams { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhieuNhap = await _context.PhieuNhaps
                .Include(p => p.NhanVien)
                .Include(x => x.CTPNs)
                .ThenInclude(x => x.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);

            SanPhams = await _context.SanPhams.Select(x => new SanPhamSelect
            {
                Id = x.Id,
                TenSanPham = x.Ten
            }).ToListAsync();

            if (PhieuNhap == null)
            {
                return NotFound();
            }


            if (PhieuNhap.CTPNs != null && (CTPNs?.Count ?? 0) < 1)
            {
                CTPNs = PhieuNhap.CTPNs.Select(x => new CTPNDTO
                {
                    IdSanPham = x.IdSanPham,
                    Gia = x.Gia,
                    KichThuoc = x.KichThuoc,
                    SoLuong = x.SoLuong,
                    TenSanPham = x.SanPham.Ten
                }).ToList();
            }
            else if (CTPNs == null)
            {
                CTPNs = new List<CTPNDTO>();
            }

            return Page();
        }
        public IEnumerable<ValiateError> Validate()
        {
            int index = 0;
            var error = new ValiateError
            {
                message = new List<string>()
            };
            var isError = false;
            foreach (var item in CTPNs)
            {
                isError = item.SoLuong < 1;
                if (isError)
                {
                    error.Index = index;
                    error.message.Add("So Luong phải lớn hơn 1!");
                }

                isError = item.Gia < 1;
                if (isError)
                {
                    error.Index = index;
                    error.message.Add("Gia phải lớn hơn 1!");
                }

                index++;

                if (isError)
                {
                    yield return error;
                    error = new ValiateError();
                }
            }
        }

        IEnumerable<CTPN> FilterAdd(IEnumerable<CTPN> cTPNs, Guid idpn)
        {
            return (from ct in CTPNs
                    join ct2 in cTPNs
                    on new { ct.IdSanPham, ct.KichThuoc } equals new { ct2.IdSanPham, ct2.KichThuoc }
                    into details
                    from tmp in details.DefaultIfEmpty()
                    where tmp == null
                    select new CTPN
                    {
                        Gia = ct.Gia,
                        IdPhieuNhap = idpn,
                        IdSanPham = ct.IdSanPham,
                        SoLuong = ct.SoLuong,
                        KichThuoc = ct.KichThuoc,
                    });
        }
        IEnumerable<CTPN> FilterDelete(IEnumerable<CTPN> cTPNs)
        {
            return (from ct in cTPNs
                    join ct2 in CTPNs
                    on new { ct.IdSanPham, ct.KichThuoc } equals new { ct2.IdSanPham, ct2.KichThuoc }
                    into details
                    from tmp in details.DefaultIfEmpty()
                    where tmp == null
                    select ct);
        }
        IEnumerable<CTPN> FilterUpdate(IEnumerable<CTPN> cTPNs)
        {
            var tmp = (from ct in cTPNs
                       join ct2 in CTPNs
                       on new { ct.IdSanPham, ct.KichThuoc } equals new { ct2.IdSanPham, ct2.KichThuoc }
                       select new { ct, ct2 }
                   );
            return tmp.Select(x =>
            {
                x.ct.Gia = x.ct2.Gia;
                x.ct.SoLuong = x.ct2.SoLuong;
                return x.ct;
            });
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var error = Validate().ToList();

            if (error.Count > 0)
            {
                ViewData["error"] = error;
                return await OnGetAsync(id);
            }

            var ctpn = _context.CTPNs.Where(x => x.IdPhieuNhap == id);

            await _context.CTPNs.AddRangeAsync(FilterAdd(ctpn, id.Value));
            _context.CTPNs.UpdateRange(FilterUpdate(ctpn));
            _context.CTPNs.RemoveRange(FilterDelete(ctpn));

            await _context.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
