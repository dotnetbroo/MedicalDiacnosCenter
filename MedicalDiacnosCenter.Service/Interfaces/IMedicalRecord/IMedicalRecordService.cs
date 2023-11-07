using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;

namespace MedicalDiacnosCenter.Service.Interfaces.IMedicalRecord;

public interface IMedicalRecordService
{
    Task<bool> RemoveAsync(long id);
    Task<MedicalRecordForResultDto> RetrieveByIdAsync(long id);
    Task<MedicalRecordForResultDto> AddAsync(MedicalRecordForCreationDto dto);
    Task<MedicalRecordForResultDto> ModifyAsync(long id, MedicalRecordForUpdateDto dto);
    Task<IEnumerable<MedicalRecordForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
