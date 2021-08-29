using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.BrandPage
{
    public class DeleteModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public DeleteModel(prjShoeStore.Data.AppDbContext context)
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

        public async Task<bool> ValidateAsync(Guid? id)
        {
            if (await _context.LoaiSPs.AnyAsync(x => x.IdThuongHieu == id))
            {
                ModelState.AddModelError(string.Empty, "delete is failure!");
                return false;
            }

            return true;
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!await ValidateAsync(id))
            {
                return await OnGetAsync(id);
            }

            ThuongHieu = await _context.ThuongHieus.FindAsync(id);

           

            if (ThuongHieu != null)
            {
                _context.ThuongHieus.Remove(ThuongHieu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
