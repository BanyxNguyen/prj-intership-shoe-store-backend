using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.OrderPage
{
    public class DeleteModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public DeleteModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DonDatHang DonDatHang { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DonDatHang = await _context.DonDatHangs
                .Include(d => d.KhachHang)
                .Include(d => d.NVGiaoHang).FirstOrDefaultAsync(m => m.Id == id);

            if (DonDatHang == null)
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

            DonDatHang = await _context.DonDatHangs.FindAsync(id);

            if (DonDatHang != null)
            {
                _context.DonDatHangs.Remove(DonDatHang);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
