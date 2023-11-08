using Microsoft.AspNetCore.Mvc;
using MedicalDiacnosCenter.Api.Models;
using MedicalDiacnosCenter.Service.DTOs.DoctorDTOs;
using MedicalDiacnosCenter.Api.Controllers.Commons;
using MedicalDiacnosCenter.Service.Interfaces.IDoctor;
using MedicalDiacnosCenter.Service.Configurations.Filters;

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
        ///Create doctor
        ///</summary>
        ///<param name="doctorForCreationDto"></param>
        ///<returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(DoctorForCreationDto doctorForCreationDto)
                    => Ok(await _doctorService.AddAsync(doctorForCreationDto));


        /// <summary>
        /// Get all doctors
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _doctorService.RetrieveAllAsync(@params));

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _doctorService.RetrieveByIdAsync(id));

        /// <summary>
        /// Update patient info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] DoctorForUpdateDto dto)
            => Ok(await _doctorService.ModifyAsync(id, dto));

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _doctorService.RemoveAsync(id));
    }
}
