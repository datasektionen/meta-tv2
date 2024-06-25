namespace Meta_TV2_BusinessLayer
{
    public interface ICustomFormFile
    {
        string FileName { get; }
        string ContentType { get; }
        long Length { get; }
        // Add other properties or methods you need from IFormFile

        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default);
    }
}