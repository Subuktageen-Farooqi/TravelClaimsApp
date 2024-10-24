using System.ComponentModel.DataAnnotations;

namespace TravelClaimsAppBackend.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<Consultant>? Consultants { get; set; }
        public List<Expense>? Expenses { get; set; }
    }
}
