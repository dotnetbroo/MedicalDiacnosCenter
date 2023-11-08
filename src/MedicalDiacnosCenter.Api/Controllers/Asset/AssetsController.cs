using MedicalDiacnosCenter.Api.Controllers.Commons;
using MedicalDiacnosCenter.Api.Models;
using MedicalDiacnosCenter.Service.Interfaces.IAssets;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalDiacnosCenter.Api.Controllers.Asset
{
    public class AssetsController : BaseController
    {
        private readonly IAssetService assetService;

        public AssetsController(IAssetService assetService)
        {
            this.assetService = assetService;
        }

        /// <summary>
        /// Delete drugs list image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-additional-drug-list-image{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await assetService.RemoveAsync(id));


        /// <summary>
        /// Upload additional drugs list image
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("list-of-additional-drugs")]
        public async Task<IActionResult> PostAsync(
            [Required(ErrorMessage = "Please, select file ...")]
            [DataType(DataType.Upload)] IFormFile file)
            => Ok(await this.assetService.UploadAsync(file));
    }
}
