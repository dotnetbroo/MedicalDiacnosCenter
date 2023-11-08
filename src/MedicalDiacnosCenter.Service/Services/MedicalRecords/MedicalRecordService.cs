using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Service.Exceptions;
using MedicalDiacnosCenter.Service.Extensions;
using MedicalDiacnosCenter.Data.IRepositories;
using MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;
using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.Interfaces.IMedicalRecord;
using MedicalDiacnosCenter.Service.Helpers;
using Microsoft.AspNetCore.Http;

namespace MedicalDiacnosCenter.Service.Services.MedicalRecords;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Doctor> _doctorRepository;
    private readonly IRepository<Patient> _patientRepository;
    private readonly IRepository<MedicalRecord> _medicalRecordRepository;

    public MedicalRecordService(
        IMapper mapper,
        IRepository<MedicalRecord> medicalRecordRepository,
        IRepository<Patient> patientRepository,
        IRepository<Doctor> doctorRepository)
    {
        _mapper = mapper;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _medicalRecordRepository = medicalRecordRepository;
    }
    public async Task<MedicalRecordForResultDto> AddAsync(MedicalRecordForCreationDto dto)
    {
        var patient = await _patientRepository.SelectAll()
                .Where(p => p.Id == dto.PatientId)
                .FirstOrDefaultAsync();

        if (patient is null)
            throw new CostumException(404, "Patient is not found");

        var doctor = await _doctorRepository.SelectAll()
            .Where(d => d.Id == dto.DoctorId)
            .FirstOrDefaultAsync();

        if (doctor is null)
            throw new CostumException(404, "Doctor is not found");

        var mappedMedicalRecord = _mapper.Map<MedicalRecord>(dto);
        mappedMedicalRecord.CreatedAt = DateTime.UtcNow;

        var result = await _medicalRecordRepository.InsertAsync(mappedMedicalRecord);

        return _mapper.Map<MedicalRecordForResultDto>(result);
    }

    public async Task<MedicalRecordForResultDto> ModifyAsync(long id, MedicalRecordForUpdateDto dto)
    {
        var medicalRecord = await _medicalRecordRepository.SelectAll()
                .Where(a => a.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (medicalRecord is null)
            throw new CostumException(404, "Medical record is not found");

        var patient = await _patientRepository.SelectAll()
                .Where(p => p.Id == dto.PatientId)
                .FirstOrDefaultAsync();

        if (patient is null)
            throw new CostumException(404, "Patient is not found");

        var doctor = await _doctorRepository.SelectAll()
            .Where(d => d.Id == dto.DoctorId)
            .FirstOrDefaultAsync();

        if (doctor is null)
            throw new CostumException(404, "Doctor is not found");


        var mappedMedicalRecord = _mapper.Map(dto, medicalRecord);
        mappedMedicalRecord.UpdatedAt = DateTime.UtcNow;

        return _mapper.Map<MedicalRecordForResultDto>(mappedMedicalRecord);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var medicalRecord = await _medicalRecordRepository.SelectAll()
                .Where(a => a.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (medicalRecord is null)
            throw new CostumException(404, "Medical record is not found");

        await _medicalRecordRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<MedicalRecordForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var medicalRecords = await _medicalRecordRepository.SelectAll()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToPagedList(@params)
                .ToListAsync();

        return _mapper.Map<IEnumerable<MedicalRecordForResultDto>>(medicalRecords);
    }

    public async Task<MedicalRecordForResultDto> RetrieveByIdAsync(long id)
    {
        var medicalRecord = await _medicalRecordRepository.SelectAll()
                .Where(a => a.Id == id)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync();
        if (medicalRecord is null)
            throw new CostumException(404, "Medical record is not found");

        return _mapper.Map<MedicalRecordForResultDto>(medicalRecord);
    }

    public async Task<string> UplodeImage(IFormFile imageFile)
    {
        var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files","assets");

        if (!Directory.Exists(uploadsFolderPath))
        {
            Directory.CreateDirectory(uploadsFolderPath);
        }
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
        var filePath = Path.Combine(uploadsFolderPath, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        return Path.Combine("Files","assets", fileName);
    }

}
