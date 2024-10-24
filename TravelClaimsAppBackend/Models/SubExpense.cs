using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelClaimsAppBackend.Models
{
    public class SubExpense
    {
        [Key]
        public int SubExpenseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Precision(18, 2)]
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        // Composite FK ref. Expense
        public int ExpenseId { get; set; }
        
        // Navigation Property
        public Expense Expense { get; set; }
    }
}
