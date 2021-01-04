using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tsops.Models;

namespace tsops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tsopsController : ControllerBase
    {
        private readonly PIPointContext _context;

        public tsopsController(PIPointContext context)
        {
            _context = context;
        }

        // GET: api/tsops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIPoint>>> GetPIPoints()
        {
            return await _context.PIPoints.ToListAsync();
        }

        // GET: api/tsops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PIPoint>> GetPIPoint(string id)
        {
            var pIPoint = await _context.PIPoints.FindAsync(id);

            if (pIPoint == null)
            {
                return NotFound();
            }

            return pIPoint;
        }

        // PUT: api/tsops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIPoint(string id, PIPoint pIPoint)
        {
            if (id != pIPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(pIPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIPointExists(id))
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

        // POST: api/tsops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PIPoint>> PostPIPoint(PIPoint pIPoint)
        {
            _context.PIPoints.Add(pIPoint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PIPointExists(pIPoint.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPIPoint", new { id = pIPoint.Id }, pIPoint);
        }

        // DELETE: api/tsops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePIPoint(string id)
        {
            var pIPoint = await _context.PIPoints.FindAsync(id);
            if (pIPoint == null)
            {
                return NotFound();
            }

            _context.PIPoints.Remove(pIPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PIPointExists(string id)
        {
            return _context.PIPoints.Any(e => e.Id == id);
        }
    }
}
