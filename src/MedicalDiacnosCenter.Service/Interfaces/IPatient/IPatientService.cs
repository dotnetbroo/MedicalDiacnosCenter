﻿using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.PatientDTOs;

namespace MedicalDiacnosCenter.Service.Interfaces.IPatient;

public interface IPatientService
{
    Task<bool> RemoveAsync(long id);
    Task<PatientForResultDto> RetrieveByIdAsync(long id);
    Task<PatientForResultDto> AddAsync(PatientForCreationDto dto);
    Task<PatientForResultDto> ModifyAsync(long id, PatientForUpdateDto dto);
    Task<IEnumerable<PatientForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
