using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ProductCategoryPage
{
    public class IndexModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public IndexModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<LoaiSP> LoaiSP { get;set; }

        public async Task OnGetAsync()
        {
            LoaiSP = await _context.LoaiSPs
                .Include(l => l.Parent)
                .Include(l => l.ThuongHieu).ToListAsync();
        }
    }
}
