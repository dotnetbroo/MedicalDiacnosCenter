using MedicalDiacnosCenter.Domain.Entities;

namespace MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;

public class AppointmentForUpdateDto
{
    public long DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public long PatientId { get; set; }
    public Patient Patient { get; set; }
    public DateTime AppointmentDateTime { get; set; }
}
