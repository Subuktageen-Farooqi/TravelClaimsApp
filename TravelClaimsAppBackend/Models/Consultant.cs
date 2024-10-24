using Microsoft.EntityFrameworkCore;

namespace TravelClaimsAppBackend.Models
{
    public class Consultant
    {
        public int ConsultantId { get; set; }
        public string Name { get; set; }
        public string Designation {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Precision(18, 2)]
        public decimal PerDiemNational { get; set; }
        [Precision(18, 2)]
        public decimal PerDiemInternational { get; set; }
        [Precision(18, 2)]
        public decimal PerDayNational { get; set; }
        [Precision(18, 2)]
        public decimal PerDayInternational { get; set; }

    }
}
