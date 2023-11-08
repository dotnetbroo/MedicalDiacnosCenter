using AutoMapper;
using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;
using MedicalDiacnosCenter.Service.DTOs.DoctorDTOs;
using MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;
using MedicalDiacnosCenter.Service.DTOs.PatientDTOs;

namespace MedicalDiacnosCenter.Service.Meppers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // Patient
        CreateMap<Patient, PatientForResultDto>().ReverseMap();
        CreateMap<Patient, PatientForUpdateDto>().ReverseMap();
        CreateMap<Patient, PatientForCreationDto>().ReverseMap();
        CreateMap<Patient, PatientForAppointmentResultDto>().ReverseMap();

        // Doctor
        CreateMap<Doctor,DoctorForUpdateDto>().ReverseMap();
        CreateMap<Doctor, DoctorForResultDto>().ReverseMap();
        CreateMap<Doctor, DoctorForCreationDto>().ReverseMap();
        CreateMap<Doctor, DoctorForAppoinmentResultDto>().ReverseMap();

        // Appointment
        CreateMap<Appointment, AppointmentForResultDto>().ReverseMap();
        CreateMap<Appointment, AppointmentForUpdateDto>().ReverseMap();
        CreateMap<Appointment, AppointmentForCreationDto>().ReverseMap();

        // MedicalRecord

        CreateMap<MedicalRecord, MedicalRecordForResultDto>().ReverseMap();
        CreateMap<MedicalRecord, MedicalRecordForUpdateDto>().ReverseMap();
        CreateMap<MedicalRecord, MedicalRecordForCreationDto>().ReverseMap();
    }
}
