using MedicalDiacnosCenter.Data.IRepositories;
using MedicalDiacnosCenter.Data.Repositories;
using MedicalDiacnosCenter.Service.Interfaces.IAppointment;
using MedicalDiacnosCenter.Service.Interfaces.IAssets;
using MedicalDiacnosCenter.Service.Interfaces.IDoctor;
using MedicalDiacnosCenter.Service.Interfaces.IMedicalRecord;
using MedicalDiacnosCenter.Service.Interfaces.IPatient;
using MedicalDiacnosCenter.Service.Services.Appointments;
using MedicalDiacnosCenter.Service.Services.Doctors;
using MedicalDiacnosCenter.Service.Services.MedicalRecords;
using MedicalDiacnosCenter.Service.Services.Patients;
using UserApplication.Service.Services.Assets;

namespace MedicalDiacnosCenter.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
        }


    }
}
