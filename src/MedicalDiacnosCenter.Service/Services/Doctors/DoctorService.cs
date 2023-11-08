using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Data.IRepositories;
using MedicalDiacnosCenter.Service.Exceptions;
using MedicalDiacnosCenter.Service.Extensions;
using MedicalDiacnosCenter.Service.DTOs.DoctorDTOs;
using MedicalDiacnosCenter.Service.Interfaces.IDoctor;
using MedicalDiacnosCenter.Service.Configurations.Filters;

namespace MedicalDiacnosCenter.Service.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Doctor> _doctorRepository;

    public DoctorService(IMapper mapper, IRepository<Doctor> doctorRepository)
    {
        this._mapper = mapper;
        this._doctorRepository = doctorRepository;
    }

    public async Task<DoctorForResultDto> AddAsync(DoctorForCreationDto dto)
    {
        var doctor = await this._doctorRepository.SelectAll()
            .Where(p => p.Email.ToLower() == dto.Email.ToLower())
            .FirstOrDefaultAsync();
        if (doctor is not null)
            throw new CostumException(409, "Doctor is already exists");

        var mappedDoctor = this._mapper.Map<Doctor>(dto);
        mappedDoctor.CreatedAt = DateTime.UtcNow;

        var result = await this._doctorRepository.InsertAsync(mappedDoctor);

        return this._mapper.Map<DoctorForResultDto>(result);
    }

    public async Task<DoctorForResultDto> ModifyAsync(long id, DoctorForUpdateDto dto)
    {
        var doctor = await this._doctorRepository.SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (doctor is null)
            throw new CostumException(404, "Doctor is not found");

        var mappedDoctor = this._mapper.Map(dto, doctor);
        mappedDoctor.UpdatedAt = DateTime.UtcNow;

        return this._mapper.Map<DoctorForResultDto>(mappedDoctor);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var doctor = await this._doctorRepository.SelectAll()
                .Where(u => u.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (doctor is null)
            throw new CostumException(404, "Doctor is not found");

        await _doctorRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<DoctorForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var doctors = await this._doctorRepository.SelectAll()
            .Include(pa => pa.Appointments)
            .Include(ma => ma.MedicalRecords)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return this._mapper.Map<IEnumerable<DoctorForResultDto>>(doctors);
    }

    public async Task<DoctorForResultDto> RetrieveByIdAsync(long id)
    {
        var doctor = await this._doctorRepository.SelectAll()
            .Where(p => p.Id == id)
            .Include(a => a.Appointments)
            .Include(m => m.MedicalRecords)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (doctor is null)
            throw new CostumException(404, "Patient is not found");

        return this._mapper.Map<DoctorForResultDto>(doctor);
    }
}
