using MedicalDiacnosCenter.Api.Controllers.Commons;
using MedicalDiacnosCenter.Api.Models;
using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;
using MedicalDiacnosCenter.Service.DTOs.MedicalRecordDTO;
using MedicalDiacnosCenter.Service.Interfaces.IAppointment;
using MedicalDiacnosCenter.Service.Interfaces.IMedicalRecord;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalDiacnosCenter.Api.Controllers.MedicalRecord
{
    public class MedicalRecordsController : BaseController
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordsController(IMedicalRecordService medicalRecordService)
        {
            this._medicalRecordService = medicalRecordService;
        }

        ///<summary>
        ///Create medical record
        ///</summary>
        ///<param name="medicalRecordForCreation"></param>
        ///<returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] MedicalRecordForCreationDto dto)
        {
            var imagePath = await _medicalRecordService.UplodeImage(dto.formFile);
            dto.ImagePath = imagePath;

            return Ok(await _medicalRecordService.AddAsync(dto));
        }


        /// <summary>
        /// Get all medical records
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _medicalRecordService.RetrieveAllAsync(@params));

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _medicalRecordService.RetrieveByIdAsync(id));

        /// <summary>
        /// Update patient info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] MedicalRecordForUpdateDto dto)
            => Ok(await _medicalRecordService.ModifyAsync(id, dto));

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _medicalRecordService.RemoveAsync(id));


    }
}
