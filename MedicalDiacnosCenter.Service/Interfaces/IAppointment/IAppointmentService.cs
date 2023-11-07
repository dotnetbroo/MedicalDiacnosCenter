using MedicalDiacnosCenter.Service.Configurations;
using MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;

namespace MedicalDiacnosCenter.Service.Interfaces.IAppointment;

public interface IAppointmentService
{
    Task<bool> RemoveAsync(long id);
    IEnumerable<AppointmentForResultDto> GetAll();
    Task<AppointmentForResultDto> RetrieveByIdAsync(long id);
    Task<AppointmentForResultDto> AddAsync(AppointmentForCreationDto dto);
    Task<AppointmentForResultDto> ModifyAsync(long id, AppointmentForUpdateDto dto);
    Task<IEnumerable<AppointmentForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
