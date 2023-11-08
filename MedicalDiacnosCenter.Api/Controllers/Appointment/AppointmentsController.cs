using MedicalDiacnosCenter.Api.Controllers.Commons;
using MedicalDiacnosCenter.Api.Models;
using MedicalDiacnosCenter.Service.Configurations.Filters;
using MedicalDiacnosCenter.Service.DTOs.AppointmentDTOs;
using MedicalDiacnosCenter.Service.Interfaces.IAppointment;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDiacnosCenter.Api.Controllers.Appointment
{
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }

        ///<summary>
        ///Create appointment
        ///</summary>
        ///<param name="appointmentForCreationDto"></param>
        ///<returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(AppointmentForCreationDto appointmentForCreationDto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _appointmentService.AddAsync(appointmentForCreationDto)
            });

        /// <summary>
        /// Get all appointments
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _appointmentService.RetrieveAllAsync(@params)
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
                Data = await _appointmentService.RetrieveByIdAsync(id)
            });

        /// <summary>
        /// Update patient info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] AppointmentForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await _appointmentService.ModifyAsync(id, dto)
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
                Data = await _appointmentService.RemoveAsync(id)
            });
    }
}
