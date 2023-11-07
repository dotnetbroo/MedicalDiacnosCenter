using AutoMapper;
using MedicalDiacnosCenter.Data.IRepositories;
using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.PatientDTOs;
using MedicalDiacnosCenter.Service.Exceptions;
using MedicalDiacnosCenter.Service.Extensions;
using MedicalDiacnosCenter.Service.Interfaces.IPatient;
using Microsoft.EntityFrameworkCore;

namespace MedicalDiacnosCenter.Service.Services.Patients;

public class PatientService : IPatientService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Patient> _patientRepository;

    public PatientService(IMapper mapper, IRepository<Patient> patientRepository)
    {
        this._mapper = mapper;
        this._patientRepository = patientRepository;
    }

    public async Task<PatientForResultDto> AddAsync(PatientForCreationDto dto)
    {
        var patient = await this._patientRepository.SelectAll()
            .Where(p => p.PhoneNumber == dto.PhoneNumber)
            .FirstOrDefaultAsync();
        if (patient is not null)
            throw new CostumException(409, "Patient is already exists");

        var mappedPatient = this._mapper.Map<Patient>(dto);
        mappedPatient.CreatedAt = DateTime.UtcNow;

        var result = await this._patientRepository.InsertAsync(mappedPatient);

        return this._mapper.Map<PatientForResultDto>(result);
    
    }

    public async Task<PatientForResultDto> ModifyAsync(long id, PatientForUpdateDto dto)
    {
        var patient = await this._patientRepository.SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (patient is null)
            throw new CostumException(404, "Patient is not found");

        var mappedPatient = this._mapper.Map(dto, patient);
        mappedPatient.UpdatedAt = DateTime.UtcNow;

        return this._mapper.Map<PatientForResultDto>(mappedPatient);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var patient = await this._patientRepository.SelectAll()
                .Where(u => u.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (patient is null)
            throw new CostumException(404, "User is not found");

        await _patientRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<PatientForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var patients = await this._patientRepository.SelectAll()
            .Include(pa => pa.Appointments)
            .Include(ma => ma.MedicalRecords)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return this._mapper.Map<IEnumerable<PatientForResultDto>>(patients);
    }

    public async Task<PatientForResultDto> RetrieveByIdAsync(long id)
    {
        var patient = await this._patientRepository.SelectAll()
            .Where(p => p.Id == id)
            .Include(a => a.Appointments)
            .Include(m => m.MedicalRecords)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (patient is null)
            throw new CostumException(404, "Patient is not found");

        return this._mapper.Map<PatientForResultDto>(patient);
    }
}
