using MedicalDiacnosCenter.Api.Controllers.Commons;
using MedicalDiacnosCenter.Api.Models;
using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.PatientDTOs;
using MedicalDiacnosCenter.Service.Interfaces.IPatient;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDiacnosCenter.Api.Controllers.Patient
{
    public class PatientsController : BaseController
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            this._patientService = patientService;
        }

        ///<summary>
        ///Create patient
        ///</summary>
        ///<param name="patientForCreationDto"></param>
        ///<returns></returns>
        [HttpPost]
        public async Task<IActionResult> postAsync(PatientForCreationDto patientForCreationDto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _patientService.AddAsync(patientForCreationDto)
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
            Data = await _patientService.RetrieveAllAsync(@params)
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
                Data = await _patientService.RetrieveByIdAsync(id)
            });

        /// <summary>
        /// Update patient info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] PatientForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _patientService.ModifyAsync(id, dto)
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
                Data = await _patientService.RemoveAsync(id)
            });
    }
}
