using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;
using prjShoeStore.DTO;
using prjShoeStore.PageLists;

namespace prjShoeStore.Controllers
{
    public class SanPhamController : ApiBaseController
    {
        private readonly AppDbContext _context;

        public SanPhamController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SanPham
        [HttpPost]
        public async Task<ActionResult<IEnumerable<SanPhamDTO>>> GetSanPhams([FromBody] ModelFilter<SanPhamDTO> modelFilter)
        {
            var builder = modelFilter.GetBuilder();


            if(modelFilter.Page != null && modelFilter.Amount == null)
            {
                ModelState.AddModelError(string.Empty, $"Amount field is requred when the Page field is assigned");
            }

            var FieldNotExist = builder.RemoveFieldNotExist(modelFilter.PropFilters, x => x.FieldName);

            if (FieldNotExist?.Count > 0)
            {
                ModelState.AddModelError(string.Empty, $"Fields not ready exist : {string.Join(",", FieldNotExist.Select(x => x.FieldName))}");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var KTPropFilter = modelFilter.PropFilters.FirstOrDefault(x => x.FieldName == nameof(SanPhamDTO.KichThuocs));
            if (KTPropFilter != null)
            {
                modelFilter.PropFilters.Remove(KTPropFilter);
            }

            var qrySanPham = _context.SanPhams.Select(x => new SanPhamDTO
            {
                HinhAnh = x.HinhAnh,
                Id = x.Id,
                IdLoaiSP = x.IdLoaiSP,
                IdThuongHieu = x.LoaiSP.IdThuongHieu,
                LoaiSP = x.LoaiSP.Ten,
                Ten = x.Ten,
                Mau = x.Mau,
                MoTa = x.MoTa,
                ThuongHieu = x.LoaiSP.ThuongHieu.Ten,
            });

            qrySanPham = builder.OrderBy(qrySanPham);

            if(modelFilter.Page != null)
            {
                qrySanPham = qrySanPham.Skip(modelFilter.Page.Value * modelFilter.Amount.Value).Take(modelFilter.Amount.Value);
            }

            var epr = builder.BuildLinq();
            IList<SanPhamDTO> data = null;
            if (epr != null)
            {
                data = await qrySanPham.Where(epr).ToListAsync();
            }
            else
            {
                data = await qrySanPham.ToListAsync();
            }

            foreach (var item in data)
            {
                item.KichThuocs =await _context.CTPNs.Where(y => y.IdSanPham == item.Id).GroupBy(y => y.KichThuoc).Select(y => y.Key).ToListAsync();
            }

            if (KTPropFilter != null)
            {
                var kichthuoc = JsonConvert.DeserializeObject<HashSet<double>>(KTPropFilter.Value);
                data = data.Where(x => x.KichThuocs.Any(x => kichthuoc.Contains(x))).ToList();
            }

            return Ok(data);
        }

        // GET: api/SanPham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetSanPham(Guid id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);

            if (sanPham == null)
            {
                return NotFound();
            }

            return sanPham;
        }

        // PUT: api/SanPham/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPham(Guid id, SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return BadRequest();
            }

            _context.Entry(sanPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SanPham
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SanPham>> PostSanPham(SanPham sanPham)
        {
            _context.SanPhams.Add(sanPham);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSanPham", new { id = sanPham.Id }, sanPham);
        }

        // DELETE: api/SanPham/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SanPham>> DeleteSanPham(Guid id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();

            return sanPham;
        }

        private bool SanPhamExists(Guid id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
