using System.ComponentModel.DataAnnotations;

public enum VacationType
{
    Semester,
    [Display(Name = "Vård av barn")]
    VAB,
    Tjänstledig,
    Föräldraledig,
    Övrigt
}