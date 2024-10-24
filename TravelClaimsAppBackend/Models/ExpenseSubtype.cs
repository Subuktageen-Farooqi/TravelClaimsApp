using System.ComponentModel.DataAnnotations;

namespace TravelClaimsAppBackend.Models
{
    public class ExpenseSubtype
    {
        [Key]
        public int ExpenseSubtypeId { get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
