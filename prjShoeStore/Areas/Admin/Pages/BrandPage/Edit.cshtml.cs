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

namespace prjShoeStore.Areas.Admin.Pages.BrandPage
{
    public class EditModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public EditModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ThuongHieu ThuongHieu { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ThuongHieu = await _context.ThuongHieus.FirstOrDefaultAsync(m => m.Id == id);

            if (ThuongHieu == null)
            {
                return NotFound();
            }
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

            _context.Attach(ThuongHieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuongHieuExists(ThuongHieu.Id))
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

        private bool ThuongHieuExists(Guid id)
        {
            return _context.ThuongHieus.Any(e => e.Id == id);
        }
    }
}
