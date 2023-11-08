using MedicalDiacnosCenter.Data.IRepositories;
using MedicalDiacnosCenter.Domain.Entities;
using MedicalDiacnosCenter.Service.Exceptions;
using MedicalDiacnosCenter.Service.Helpers;
using MedicalDiacnosCenter.Service.Interfaces.IAssets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace UserApplication.Service.Services.Assets;

public class AssetService : IAssetService
{
    private readonly IRepository<Asset> _assetRepository;

    public AssetService(IRepository<Asset> assetRepository)
    {
        this._assetRepository = assetRepository;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var asset = await this._assetRepository.SelectAll()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new CostumException(404, "Attachment not found");

        string rootPath = EnvironmentHelper.WebRootPath;
        string imagePath = Path.Combine(rootPath, "Files", asset?.Path);
        if (File.Exists(imagePath))
            File.Delete(imagePath);
        var result = await this._assetRepository.DeleteAsync(id);

        return result;
    }

    public async Task<Asset> UploadAsync(IFormFile file)
    {
        string rootPath = Path.Combine(EnvironmentHelper.WebRootPath, "Files");
        string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        string path = Path.Combine(rootPath, "assets", fileName);

        using (var fileStream = File.OpenWrite(path))
        {
            await file.CopyToAsync(fileStream);
        }

        var asset = new Asset()
        {
            CreatedAt = DateTime.UtcNow,
            Path = Path.Combine("assets", fileName)
        };
        var result = await this._assetRepository.InsertAsync(asset);

        return result;
    }
}
