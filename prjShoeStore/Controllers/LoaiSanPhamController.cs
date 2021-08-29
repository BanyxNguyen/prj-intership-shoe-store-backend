using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;

namespace prjShoeStore.Controllers
{
    public class LoaiSanPhamController : ApiBaseController
    {
        private readonly AppDbContext _context;

        public LoaiSanPhamController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LoaiSanPham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSP>>> GetLoaiSPs()
        {
            return await _context.LoaiSPs.ToListAsync();
        }

        // GET: api/LoaiSanPham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSP>> GetLoaiSP(Guid id)
        {
            var loaiSP = await _context.LoaiSPs.FindAsync(id);

            if (loaiSP == null)
            {
                return NotFound();
            }

            return loaiSP;
        }

        // PUT: api/LoaiSanPham/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSP(Guid id, LoaiSP loaiSP)
        {
            if (id != loaiSP.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaiSP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSPExists(id))
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

        // POST: api/LoaiSanPham
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoaiSP>> PostLoaiSP(LoaiSP loaiSP)
        {
            _context.LoaiSPs.Add(loaiSP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiSP", new { id = loaiSP.Id }, loaiSP);
        }

        // DELETE: api/LoaiSanPham/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoaiSP>> DeleteLoaiSP(Guid id)
        {
            var loaiSP = await _context.LoaiSPs.FindAsync(id);
            if (loaiSP == null)
            {
                return NotFound();
            }

            _context.LoaiSPs.Remove(loaiSP);
            await _context.SaveChangesAsync();

            return loaiSP;
        }

        private bool LoaiSPExists(Guid id)
        {
            return _context.LoaiSPs.Any(e => e.Id == id);
        }
    }
}
