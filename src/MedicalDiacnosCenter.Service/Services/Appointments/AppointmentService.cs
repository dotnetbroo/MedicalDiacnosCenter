using AutoMapper;
using MedicalDiacnosCenter.Data.IRepositories;
using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;
using MedicalDiacnosCenter.Service.Exceptions;
using MedicalDiacnosCenter.Service.Extensions;
using MedicalDiacnosCenter.Service.Interfaces.IAppointment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDiacnosCenter.Service.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Appointment> _appointmentRepository;

        public AppointmentService(
            IMapper mapper,
            IRepository<Appointment> appointmentRepository,
            IRepository<Patient> patientRepository,
            IRepository<Doctor> doctorRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentForResultDto> AddAsync(AppointmentForCreationDto dto)
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

            var mappedAppointment = _mapper.Map<Appointment>(dto);
            mappedAppointment.CreatedAt = DateTime.UtcNow;

            var result = await _appointmentRepository.InsertAsync(mappedAppointment);

            return _mapper.Map<AppointmentForResultDto>(result);
        }

        public async Task<AppointmentForResultDto> ModifyAsync(long id, AppointmentForUpdateDto dto)
        {
            var appointment = await _appointmentRepository.SelectAll()
                .Where(a => a.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (appointment is null)
                throw new CostumException(404, "Appointment is not found");

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


            var mappedAppointment = _mapper.Map(dto, appointment);
            mappedAppointment.UpdatedAt = DateTime.UtcNow;

            return _mapper.Map<AppointmentForResultDto>(mappedAppointment);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var appointment = await _appointmentRepository.SelectAll()
                .Where(a => a.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (appointment is null)
                throw new CostumException(404, "Appointment is not found");

            await _appointmentRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<AppointmentForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var appointments = await _appointmentRepository.SelectAll()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AppointmentForResultDto>>(appointments);
        }

        public async Task<AppointmentForResultDto> RetrieveByIdAsync(long id)
        {
            var appointment = await _appointmentRepository.SelectAll()
                .Where(a => a.Id == id)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync();
            if (appointment is null)
                throw new CostumException(404, "Appointment is not found");

            return _mapper.Map<AppointmentForResultDto>(appointment);
        }
    }
}
