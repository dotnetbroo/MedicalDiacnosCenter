using MedicalDiacnosCenter.Domain.Commons;

namespace MedicalDiacnosCenter.Domain.Entities;

public class Patient : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}
