using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ProductCategoryPage
{
    public class EditModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public EditModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }
        public class LoaiSPModelView
        {
            public Guid? Id { get; set; }
            public string Ten { get; set; }
        }

        [BindProperty]
        public LoaiSP LoaiSP { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisp = _context.LoaiSPs
                .OrderBy(x => x.IdParent)
                .ThenBy(x => x.Ten)
                .Select(x => new LoaiSPModelView { Id = x.Id, Ten = x.Ten })
                .Where(x=>x.Id != id)
                .ToList();

            loaisp.Insert(0, new LoaiSPModelView
            {
                Ten = "None",
                Id = null
            });

            LoaiSP = await _context.LoaiSPs
                .Include(l => l.Parent)
                .Include(l => l.ThuongHieu).FirstOrDefaultAsync(m => m.Id == id);

            if (LoaiSP == null)
            {
                return NotFound();
            }

            ViewData["IdParent"] = new SelectList(loaisp, nameof(LoaiSPModelView.Id), nameof(LoaiSPModelView.Ten));
            ViewData["IdThuongHieu"] = new SelectList(_context.ThuongHieus, "Id", nameof(ThuongHieu.Ten));
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

            _context.Attach(LoaiSP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSPExists(LoaiSP.Id))
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

        private bool LoaiSPExists(Guid id)
        {
            return _context.LoaiSPs.Any(e => e.Id == id);
        }
    }
}
