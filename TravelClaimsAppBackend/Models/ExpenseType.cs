using System.ComponentModel.DataAnnotations;

namespace TravelClaimsAppBackend.Models
{
    public class ExpenseType
    {
        [Key]
        public int ExpenseTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<ExpenseSubtype>? Subtypes { get; set; }
    }
}
