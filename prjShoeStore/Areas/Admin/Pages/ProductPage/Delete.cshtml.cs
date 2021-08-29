using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ProductPage
{
    public class DeleteModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public DeleteModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SanPham SanPham { get; set; }

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
            return Page();
        }
        //public async Task<bool> ValidateAsync(Guid? id)
        //{
        //    if (await _context.LoaiSPs.AnyAsync(x => x.IdParent == id))
        //    {
        //        ModelState.AddModelError(string.Empty, "delete is failure. please remove the child components before doing the delete!");
        //        return false;
        //    }

        //    if (await _context.SanPhams.AnyAsync(x => x.IdLoaiSP == id))
        //    {
        //        ModelState.AddModelError(string.Empty, "delete is failure. please delete its products before doing the delete!");
        //        return false;
        //    }

        //    return true;
        //}
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SanPham = await _context.SanPhams.FindAsync(id);

            if (SanPham != null)
            {
                _context.SanPhams.Remove(SanPham);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
