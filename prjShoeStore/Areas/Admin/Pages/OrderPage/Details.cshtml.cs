using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.OrderPage
{
    public class DetailsModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public DetailsModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public DonDatHang DonDatHang { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DonDatHang = await _context.DonDatHangs
                .Include(p => p.KhachHang)
                .Include(x => x.CTDDHs)
                .ThenInclude(x => x.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            foreach (var item in DonDatHang.CTDDHs)
            {
                if (!string.IsNullOrWhiteSpace(item.SanPham.HinhAnh))
                {
                    var imgs = JsonConvert.DeserializeObject<IList<string>>(item.SanPham.HinhAnh);
                    if (imgs.Count > 0)
                    {
                        item.SanPham.HinhAnh = imgs.First();
                    }
                }
            }
            return Page();
        }
    }
}
