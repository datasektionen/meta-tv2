namespace Meta_TV2_BusinessLayer
{
    public interface ICustomFormFile
    {
        bool IsEmpty { get; }
        string FileName { get; }
        string ContentType { get; }
        long Length { get; }
        
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default);
    }
}