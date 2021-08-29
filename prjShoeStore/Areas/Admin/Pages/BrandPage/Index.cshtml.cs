using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;
using prjShoeStore.DTO;

namespace prjShoeStore.Areas.Admin.Pages.BrandPage
{
    public class IndexModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public IndexModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<ThuongHieu> ThuongHieu { get;set; }
        public async Task OnGetAsync()
        {
            ThuongHieu = await _context.ThuongHieus.ToListAsync();
        }
    }
}
