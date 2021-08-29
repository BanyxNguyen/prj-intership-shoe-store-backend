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
    public class DeleteModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public DeleteModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoaiSP LoaiSP { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoaiSP = await _context.LoaiSPs
                .Include(l => l.Parent)
                .Include(l => l.ThuongHieu).FirstOrDefaultAsync(m => m.Id == id);

            if (LoaiSP == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<bool> ValidateAsync(Guid? id)
        {
            if (await _context.LoaiSPs.AnyAsync(x => x.IdParent == id))
            {
                ModelState.AddModelError(string.Empty, "delete is failure. please remove the child components before doing the delete!");
                return false;
            }

            if (await _context.SanPhams.AnyAsync(x => x.IdLoaiSP == id))
            {
                ModelState.AddModelError(string.Empty, "delete is failure. please delete its products before doing the delete!");
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

            LoaiSP = await _context.LoaiSPs.FindAsync(id);

            if (LoaiSP != null)
            {
                _context.LoaiSPs.Remove(LoaiSP);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
