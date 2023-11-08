using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;
using Microsoft.AspNetCore.Http;

namespace MedicalDiacnosCenter.Service.Interfaces.IMedicalRecord;

public interface IMedicalRecordService
{
    Task<bool> RemoveAsync(long id);
    public Task<string> UplodeImage(IFormFile imageFile);
    Task<MedicalRecordForResultDto> RetrieveByIdAsync(long id);
    Task<MedicalRecordForResultDto> AddAsync(MedicalRecordForCreationDto dto);
    Task<MedicalRecordForResultDto> ModifyAsync(long id, MedicalRecordForUpdateDto dto);
    Task<IEnumerable<MedicalRecordForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
