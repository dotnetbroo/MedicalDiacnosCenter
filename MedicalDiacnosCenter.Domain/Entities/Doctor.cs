using MedicalDiacnosCenter.Domain.Commons;

namespace MedicalDiacnosCenter.Domain.Entities;

public class Doctor : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }
    public string Email {  get; set; }
    public string Password { get; set; }
}
