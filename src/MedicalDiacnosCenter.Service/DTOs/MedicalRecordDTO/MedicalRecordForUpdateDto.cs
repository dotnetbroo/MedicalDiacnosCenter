using MedicalDiacnosCenter.Domain.Entities;

namespace MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;

public class MedicalRecordForUpdateDto
{
    public long DoctorId { get; set; }
    public long PatientId { get; set; }
    public string Diagnosis { get; set; }
    public DateTime RecordDateTime { get; set; }
}
