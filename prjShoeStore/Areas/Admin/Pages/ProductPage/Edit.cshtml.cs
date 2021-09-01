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
    public class EditModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public EditModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SanPham SanPham { get; set; }
        [BindProperty]
        [Required]
        public IList<IFormFile> Images { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SanPham = await _context.SanPhams
                .Include(s => s.LoaiSP).FirstOrDefaultAsync(m => m.Id == id);

            if (SanPham == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiSP"] = new SelectList(_context.LoaiSPs.Include(x => x.ThuongHieu).Select(x => new
            {
                Id = x.Id,
                Ten = x.Ten + " - " + x.ThuongHieu.Ten
            }), nameof(LoaiSP.Id), nameof(LoaiSP.Ten));
            return Page();
        }

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
                var originalFile = JsonConvert.DeserializeObject<IList<string>>(string.IsNullOrWhiteSpace(SanPham.HinhAnh) ? "[]" : SanPham.HinhAnh);
                SanPham.HinhAnh = JsonConvert.SerializeObject(originalFile.Concat(files.ToArray()));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Upload image fail!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SanPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(SanPham.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SanPhamExists(Guid id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
