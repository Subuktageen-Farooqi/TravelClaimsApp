using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelClaimsAppBackend.Data;
using TravelClaimsAppBackend.Models;

namespace TravelClaimsAppBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseTypeController : ControllerBase
    {
        private readonly TravelClaimsDbContext _context;
        public ExpenseTypeController(TravelClaimsDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Consultant")]
        [HttpGet]
        [Route("GetExpenseTypes")]
        public async Task<ActionResult<List<ExpenseType>>> GetExpenseTypes()
        {
            return await _context.ExpenseTypes.ToListAsync();
        }

        [Authorize(Roles = "Consultant")]
        [HttpPost]
        [Route("AddExpenseType")]
        public async Task<ActionResult<ExpenseType>> AddExpenseType(ExpenseType newExpenseType)
        {
            _context.ExpenseTypes.Add(newExpenseType);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetExpenseTypes", newExpenseType);
        }

        [Authorize(Roles = "Lead")]
        [HttpPut]
        [Route("UpdateExpenseType")]
        public async Task<IActionResult> UpdateExpenseType(int id, ExpenseType expenseType)
        {
            if (id != expenseType.ExpenseTypeId)
            {
                return BadRequest();
            }
            _context.Entry(expenseType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "Lead")]
        [HttpDelete]
        [Route("DeleteExpenseType")]
        public async Task<IActionResult> DeleteExpenseType(int id)
        {
            var expenseType = await _context.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return NotFound();
            }
            _context.ExpenseTypes.Remove(expenseType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
