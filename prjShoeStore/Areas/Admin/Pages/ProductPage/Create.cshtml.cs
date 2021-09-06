using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using prjShoeStore.Common;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public CreateModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IdLoaiSP"] = new SelectList(_context.LoaiSPs.Include(x => x.ThuongHieu).Select(x => new
            {
                Id = x.Id,
                Ten = x.Ten + " - " + x.ThuongHieu.Ten
            }), nameof(LoaiSP.Id), nameof(LoaiSP.Ten));
            return Page();
        }

        [BindProperty]
        public SanPham SanPham { get; set; }
        [BindProperty]
        [Required]
        public IList<IFormFile> Images { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var files = Images.SaveProductImage();
                SanPham.HinhAnh = JsonConvert.SerializeObject(files.ToArray());
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Upload image fail!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            SanPham.NgayTao = DateTime.Now;
            _context.SanPhams.Add(SanPham);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
