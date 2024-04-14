using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1.Models
{
    public class Vacation
    {
        [Key]
        public int VacationId { get; set; }
        [DisplayName("Frånvarotyp")]
        public VacationType VacationType { get; set; }
        [DisplayName("Startdatum")]
        public DateTime StartDate { get; set; }
        [DisplayName("Slutdatum")]
        public DateTime EndDate { get; set; }
        [DisplayName("Ansökningsdatum")]
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        [ForeignKey("Employee")]
        [DisplayName("Anställd")]
        public int FK_EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
