using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data.Entities;
using prjShoeStore.ModelViews;

namespace prjShoeStore.Areas.Admin.Pages.OrderReportPage
{
    public class IndexModel : PageModel
    {
        private readonly prjShoeStore.Data.AppDbContext _context;

        public IndexModel(prjShoeStore.Data.AppDbContext context)
        {
            _context = context;
        }
        public IList<OrderModelView> DonDatHang { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; } = DateTime.Now;
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime End { get; set; } = DateTime.Now;


        public async Task OnGetAsync(DateTime? start, DateTime? end)
        {

            if (!start.HasValue)
            {
                start = DateTime.Now;
            }

            if (!end.HasValue)
            {
                end = DateTime.Now;
            }

            DonDatHang = await _context.DonDatHangs
                .Include(d => d.KhachHang)
                .Include(d => d.NVGiaoHang)
                .Where(x => x.NgayLap.Date >= start.Value.Date && x.NgayLap.Date <= end.Value.Date)
                .Select(x => new OrderModelView
                {
                    Id = x.Id,
                    DiaChiNguoiNhan = x.DiaChiNguoiNhan,
                    NgayLap = x.NgayLap,
                    PaymentId = x.PaymentId,
                    PaymentType = x.PaymentType,
                    SoDienThoai = x.SoDienThoai,
                    TenNguoiNhan = x.TenNguoiNhan,
                    TongTien = x.CTDDHs.Sum(x => x.SoLuong * x.Gia)
                })
                .ToListAsync();
        }
        public IActionResult OnPostAsync()
        {
            return RedirectToPage("Index", new { Start, End });
        }
    }
}
