namespace PandaHR.Api.Services.Exporter.Models
{
    public class CustomFile
    {
        public byte[] FileContents { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
