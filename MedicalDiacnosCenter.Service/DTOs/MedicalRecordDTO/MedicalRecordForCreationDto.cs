using MedicalDiacnosCenter.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;

public class MedicalRecordForCreationDto
{
    [Required(ErrorMessage = "Please, enter doctor's id ...")]
    public long DoctorId { get; set; }
    [Required(ErrorMessage = "Please, enter patient's id  ...")]
    public long PatientId { get; set; }
    [Required(ErrorMessage = "Please, enter diagnosis ...")]
    public string Diagnosis { get; set; }
    [Required(ErrorMessage = "Please, choose and enter date ...")]
    public DateTime RecordDateTime { get; set; }
    public string? ImagePath { get; set; }

    public IFormFile formFile { get; set; }
}
