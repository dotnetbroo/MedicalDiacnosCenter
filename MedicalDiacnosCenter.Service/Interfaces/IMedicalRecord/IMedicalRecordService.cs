using MedicalDiacnosCenter.Service.Configurations;
using MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;

namespace MedicalDiacnosCenter.Service.Interfaces.IMedicalRecord;

public interface IMedicalRecordService
{
    Task<bool> RemoveAsync(long id);
    IEnumerable<MedicalRecordForResultDto> GetAll();
    Task<MedicalRecordForResultDto> RetrieveByIdAsync(long id);
    Task<MedicalRecordForResultDto> AddAsync(MedicalRecordForCreationDto dto);
    Task<MedicalRecordForResultDto> ModifyAsync(long id, MedicalRecordForUpdateDto dto);
    Task<IEnumerable<MedicalRecordForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
