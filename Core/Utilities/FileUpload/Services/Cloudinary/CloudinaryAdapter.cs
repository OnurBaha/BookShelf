using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.FileUpload;
public class CloudinaryAdapter : IFileUploadAdapter
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryAdapter(IConfiguration configuration)
    {
        Account account = configuration.GetSection("CloudinaryAccount").Get<Account>();
        _cloudinary = new Cloudinary(account);
    }

    public async Task<string> Upload(IFormFile file)
    {
        var fileUploadResponse = new ImageUploadResult();

        using (var stream = file.OpenReadStream())
        {
            var parameters = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream)
            };
            fileUploadResponse = await _cloudinary.UploadAsync(parameters);
        }
        return fileUploadResponse.Url.ToString();
    }
    public async Task Delete(string imageUrl)
    {
        DeletionParams deletionParams = new(GetPublicId(imageUrl));
        await _cloudinary.DestroyAsync(deletionParams);
    }

    public async Task<string> Update(IFormFile formFile, string imageUrl)
    {
        await Delete(imageUrl);
        return await Upload(formFile);
    }
    private string GetPublicId(string imageUrl)
    {
        int startIndex = imageUrl.LastIndexOf('/') + 1;
        int endIndex = imageUrl.LastIndexOf('.');
        int length = endIndex - startIndex;
        return imageUrl.Substring(startIndex, length);
    }

}