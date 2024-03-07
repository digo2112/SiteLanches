namespace SiteLanches.Models
{
    public class FileManagerModel
    {
        public FileInfo[] Files { get; set; }
        public IFormFile IFormFile { get; set; }

        public string PathImagesProduto { get; set; }
        public List<IFormFile> FilesProduto { get; set; }


    }
}
