using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Areas.Admin.Pages.ProductCategoryPage
{
    public class CreateModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;
        public class LoaiSPModelView
        {
            public Guid? Id { get; set; }
            public string Ten { get; set; }
        }
        public CreateModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var loaisp = _context.LoaiSPs
                .OrderBy(x=>x.IdParent)
                .ThenBy(x=>x.Ten)
                .Select(x => new LoaiSPModelView {Id=x.Id,Ten = x.Ten })
                .ToList();
                
            loaisp.Insert(0, new LoaiSPModelView
            {
                Ten = "None",
                Id = null
            });

            ViewData["IdParent"] = new SelectList(loaisp, nameof(LoaiSPModelView.Id), nameof(LoaiSPModelView.Ten));
            ViewData["IdThuongHieu"] = new SelectList(_context.ThuongHieus, "Id", nameof(ThuongHieu.Ten));
            return Page();
        }

        [BindProperty]
        public LoaiSP LoaiSP { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.LoaiSPs.Add(LoaiSP);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
