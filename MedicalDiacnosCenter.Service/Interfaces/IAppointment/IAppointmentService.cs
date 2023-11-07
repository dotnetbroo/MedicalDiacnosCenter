using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;

namespace MedicalDiacnosCenter.Service.Interfaces.IAppointment;

public interface IAppointmentService
{
    Task<bool> RemoveAsync(long id);
    Task<AppointmentForResultDto> RetrieveByIdAsync(long id);
    Task<AppointmentForResultDto> AddAsync(AppointmentForCreationDto dto);
    Task<AppointmentForResultDto> ModifyAsync(long id, AppointmentForUpdateDto dto);
    Task<IEnumerable<AppointmentForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
