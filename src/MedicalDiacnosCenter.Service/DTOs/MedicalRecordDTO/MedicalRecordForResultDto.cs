using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Service.DTOs.DoctorDTOs;
using MedicalDiacnosCenter.Service.DTOs.PatientDTOs;

namespace MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;

public class MedicalRecordForResultDto
{
    public long Id { get; set; }
    public string Diagnosis { get; set; }
    public DoctorForAppoinmentResultDto Doctor { get; set; }
    public PatientForAppointmentResultDto Patient { get; set; }
    public string ImagePath { get; set; }
}
