using Meta_TV2_BusinessLayer;

namespace Meta_TV2_api
{
    public class FormFileWrapper : ICustomFormFile
    {
        private readonly IFormFile _formFile;

        public FormFileWrapper(IFormFile formFile)
        {
            _formFile = formFile;
        }

        public bool IsEmpty => _formFile == null;
        public string FileName => _formFile.FileName;
        public string ContentType => _formFile.ContentType;
        public long Length => _formFile.Length;

        public async Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            await _formFile.CopyToAsync(target, cancellationToken);
        }
    }
}