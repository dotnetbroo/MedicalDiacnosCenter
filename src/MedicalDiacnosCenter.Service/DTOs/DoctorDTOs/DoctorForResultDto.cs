using MedicalDiacnosCenter.Domain.Entities;

namespace MedicalDiacnosCenter.Service.DTOs.DoctorDTOs;

public class DoctorForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }


    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<MedicalRecord> MedicalRecords { get; set; }
}
