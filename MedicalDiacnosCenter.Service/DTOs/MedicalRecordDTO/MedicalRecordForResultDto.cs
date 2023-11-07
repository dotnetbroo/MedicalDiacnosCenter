﻿using MedicalDiacnosCenter.Domain.Entities;

namespace MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;

public class MedicalRecordForResultDto
{
    public long DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public long PatientId { get; set; }
    public Patient Patient { get; set; }
    public string Diagnosis { get; set; }
    public DateTime RecordDateTime { get; set; }
}