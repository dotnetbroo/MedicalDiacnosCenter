using MedicalDiacnosCenter.Service.Configurations;
using MedicalDiacnosCenter.Service.DTOs.DoctorDTOs;

namespace MedicalDiacnosCenter.Service.Interfaces.IDoctor;

public interface IDoctorService
{
    Task<bool> RemoveAsync(long id);
    IEnumerable<DoctorForResultDto> GetAll();
    Task<DoctorForResultDto> RetrieveByIdAsync(long id);
    Task<DoctorForResultDto> AddAsync(DoctorForCreationDto dto);
    Task<DoctorForResultDto> ModifyAsync(long id, DoctorForUpdateDto dto);
    Task<IEnumerable<DoctorForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
