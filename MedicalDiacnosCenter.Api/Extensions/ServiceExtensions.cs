using MedicalDiacnosCenter.Data.IRepositories;
using MedicalDiacnosCenter.Data.Repositories;
using MedicalDiacnosCenter.Service.Interfaces.IDoctor;
using MedicalDiacnosCenter.Service.Interfaces.IPatient;
using MedicalDiacnosCenter.Service.Services.Doctors;
using MedicalDiacnosCenter.Service.Services.Patients;

namespace MedicalDiacnosCenter.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }


    }
}
