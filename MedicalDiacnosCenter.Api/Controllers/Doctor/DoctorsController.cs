using MedicalDiacnosCenter.Api.Controllers.Commons;
using MedicalDiacnosCenter.Api.Models;
using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.DoctorDTOs;
using MedicalDiacnosCenter.Service.DTOs.PatientDTOs;
using MedicalDiacnosCenter.Service.Interfaces.IDoctor;
using MedicalDiacnosCenter.Service.Interfaces.IPatient;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDiacnosCenter.Api.Controllers.Doctor
{
    public class DoctorsController : BaseController
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        ///<summary>
        ///Create patient
        ///</summary>
        ///<param name="doctorForCreationDto"></param>
        ///<returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(DoctorForCreationDto doctorForCreationDto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _doctorService.AddAsync(doctorForCreationDto)
            });

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _doctorService.RetrieveAllAsync(@params)
        });

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _doctorService.RetrieveByIdAsync(id)
            });

        /// <summary>
        /// Update patient info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] DoctorForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _doctorService.ModifyAsync(id, dto)
            });

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _doctorService.RemoveAsync(id)
            });
    }
}
