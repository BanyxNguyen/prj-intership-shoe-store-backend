using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using prjShoeStore.Areas.Identity.Data;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ImportVoucherPage
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
            ViewData["IdNhanVien"] = new SelectList(_context.Users, nameof(ApplicationUser.Id), nameof(ApplicationUser.Email));
            return Page();
        }

        [BindProperty]
        public PhieuNhap PhieuNhap { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PhieuNhaps.Add(PhieuNhap);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
