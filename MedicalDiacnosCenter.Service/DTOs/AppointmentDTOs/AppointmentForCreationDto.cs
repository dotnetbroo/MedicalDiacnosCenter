using MedicalDiacnosCenter.Domain.Entities;

namespace MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;

public class AppointmentForCreationDto
{
    public long DoctorId { get; set; }
    public long PatientId { get; set; }
    public string ReasonFromAppointment { get; set; }
    public DateTime AppointmentDateTime { get; set; }
}
