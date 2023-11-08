using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Service.DTOs.DoctorDTOs;
using MedicalDiacnosCenter.Service.DTOs.PatientDTOs;

namespace MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;

public class AppointmentForResultDto
{
    public long Id { get; set; }
    public string ReasonFromAppointment { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public DoctorForAppoinmentResultDto Doctor {  get; set; }
    public PatientForAppointmentResultDto Patient { get; set; }
}
