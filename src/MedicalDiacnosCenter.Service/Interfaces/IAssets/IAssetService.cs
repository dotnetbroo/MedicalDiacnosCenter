using Microsoft.AspNetCore.Http;
using MedicalDiacnosCenter.Domain.Entities;

namespace MedicalDiacnosCenter.Service.Interfaces.IAssets;

public interface IAssetService
{
    Task<Asset> UploadAsync(IFormFile file);
    Task<bool> RemoveAsync(long id);
}
