using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Areas.Identity.Data;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ImportVoucherPage
{
    public class EditModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public EditModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PhieuNhap PhieuNhap { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhieuNhap = await _context.PhieuNhaps
                .Include(p => p.NhanVien).FirstOrDefaultAsync(m => m.Id == id);

            if (PhieuNhap == null)
            {
                return NotFound();
            }
            ViewData["IdNhanVien"] = new SelectList(_context.Users, nameof(ApplicationUser.Id), nameof(ApplicationUser.Email));
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

            _context.Attach(PhieuNhap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuNhapExists(PhieuNhap.Id))
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

        private bool PhieuNhapExists(Guid id)
        {
            return _context.PhieuNhaps.Any(e => e.Id == id);
        }
    }
}
