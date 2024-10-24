using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TravelClaimsAppBackend.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        [Required]
        public int ExpenseTypeId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public int ConsultantId { get; set; }
        [Precision(18, 2)]
        public decimal? Distance { get; set; }
        public string Currency { get; set; } = "PKR";
        

    }
}
