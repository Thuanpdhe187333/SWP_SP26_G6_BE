using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreHR.Models;

namespace CoreHR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentContractsController : ControllerBase
    {
        private readonly HrmSystemContext _context;

        public EmploymentContractsController(HrmSystemContext context)
        {
            _context = context;
        }

        // GET: api/EmploymentContracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentContract>>> GetEmploymentContracts()
        {
            return await _context.EmploymentContracts.ToListAsync();
        }

        // GET: api/EmploymentContracts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentContract>> GetEmploymentContract(int id)
        {
            var employmentContract = await _context.EmploymentContracts.FindAsync(id);

            if (employmentContract == null)
            {
                return NotFound();
            }

            return employmentContract;
        }

        // PUT: api/EmploymentContracts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentContract(int id, EmploymentContract employmentContract)
        {
            if (id != employmentContract.ContractId)
            {
                return BadRequest();
            }

            _context.Entry(employmentContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentContractExists(id))
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

        // POST: api/EmploymentContracts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmploymentContract>> PostEmploymentContract(EmploymentContract employmentContract)
        {
            _context.EmploymentContracts.Add(employmentContract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploymentContract", new { id = employmentContract.ContractId }, employmentContract);
        }

        // DELETE: api/EmploymentContracts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentContract(int id)
        {
            var employmentContract = await _context.EmploymentContracts.FindAsync(id);
            if (employmentContract == null)
            {
                return NotFound();
            }

            _context.EmploymentContracts.Remove(employmentContract);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploymentContractExists(int id)
        {
            return _context.EmploymentContracts.Any(e => e.ContractId == id);
        }
    }
}
