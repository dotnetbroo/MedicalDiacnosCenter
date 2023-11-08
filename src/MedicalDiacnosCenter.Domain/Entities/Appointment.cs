using MedicalDiacnosCenter.Domain.Commons;

namespace MedicalDiacnosCenter.Domain.Entities;

public class Appointment : Auditable
{
    public long DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public long PatientId { get; set; }
    public Patient Patient { get; set; }
    public string ReasonFromAppointment {  get; set; }
    public DateTime AppointmentDateTime { get; set; }
}
