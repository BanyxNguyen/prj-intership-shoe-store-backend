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
    public class ThuongHieuController : ApiBaseController
    {
        private readonly AppDbContext _context;

        public ThuongHieuController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThuongHieu>>> GetThuongHieus()
        {
            return await _context.ThuongHieus.ToListAsync();
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThuongHieu>> GetThuongHieu(Guid id)
        {
            var thuongHieu = await _context.ThuongHieus.FindAsync(id);

            if (thuongHieu == null)
            {
                return NotFound();
            }

            return thuongHieu;
        }

        // PUT: api/Brand/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuongHieu(Guid id, ThuongHieu thuongHieu)
        {
            if (id != thuongHieu.Id)
            {
                return BadRequest();
            }

            _context.Entry(thuongHieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuongHieuExists(id))
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

        // POST: api/Brand
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ThuongHieu>> PostThuongHieu(ThuongHieu thuongHieu)
        {
            _context.ThuongHieus.Add(thuongHieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThuongHieu", new { id = thuongHieu.Id }, thuongHieu);
        }

        // DELETE: api/Brand/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThuongHieu>> DeleteThuongHieu(Guid id)
        {
            var thuongHieu = await _context.ThuongHieus.FindAsync(id);
            if (thuongHieu == null)
            {
                return NotFound();
            }

            _context.ThuongHieus.Remove(thuongHieu);
            await _context.SaveChangesAsync();

            return thuongHieu;
        }

        private bool ThuongHieuExists(Guid id)
        {
            return _context.ThuongHieus.Any(e => e.Id == id);
        }
    }
}
