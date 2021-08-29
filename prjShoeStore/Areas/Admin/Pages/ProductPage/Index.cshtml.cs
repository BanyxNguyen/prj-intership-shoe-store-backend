using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public IndexModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<SanPham> SanPham { get;set; }

        public async Task OnGetAsync()
        {
            SanPham = await _context.SanPhams
                .Include(s => s.LoaiSP).ToListAsync();
            foreach (var item in SanPham)
            {
                if (!string.IsNullOrWhiteSpace(item.HinhAnh))
                {
                    var imgs = JsonConvert.DeserializeObject<IList<string>>(item.HinhAnh);
                    if(imgs.Count > 0)
                    {
                        item.HinhAnh = imgs.First();
                    }
                }
            }
        }
    }
}
