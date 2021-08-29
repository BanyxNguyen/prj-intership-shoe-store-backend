using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ImportVoucherPage
{
    public class DeleteModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public DeleteModel(prjShoeStore.Data.AppDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhieuNhap = await _context.PhieuNhaps.FindAsync(id);

            if (PhieuNhap != null)
            {
                _context.PhieuNhaps.Remove(PhieuNhap);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
