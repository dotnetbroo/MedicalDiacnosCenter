using MedicalDiacnosCenter.Domain.Entities;
using System.Text.Json.Serialization;

namespace MedicalDiacnosCenter.Service.DTOs.PatientDTOs;

public class PatientForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    [JsonIgnore]
    public ICollection<Appointment> Appointments { get; set; }
    [JsonIgnore]
    public ICollection<MedicalRecord> MedicalRecords { get; set; }
}
