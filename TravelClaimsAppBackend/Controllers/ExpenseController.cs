using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelClaimsAppBackend.Data;
using TravelClaimsAppBackend.Models;

namespace TravelClaimsAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly TravelClaimsDbContext _context;
        public ExpenseController(TravelClaimsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetExpenses")]
        public async Task<ActionResult<List<Expense>>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        [HttpPost]
        [Route("AddExpense")]
        public async Task<ActionResult<Expense>> AddExpense(Expense newExpense)
        {
            _context.Expenses.Add(newExpense);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetExpenses", newExpense);
        }

        [HttpPut]
        [Route("UpdateExpense")]
        public async Task<IActionResult> UpdateExpense(int id, Expense expense)
        {
            if (id != expense.ExpenseId)
            {
                return BadRequest();
            }
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteExpense")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
