using CloudinaryDotNet.Actions;

namespace OPIGESHOP.Interfaces
{
    public interface IphotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
