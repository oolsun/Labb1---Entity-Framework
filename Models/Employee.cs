using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Födelsedatum")]
        public DateTime BirthDate { get; set; }

        public ICollection<Vacation> Vacations { get; set; }
    }
}
