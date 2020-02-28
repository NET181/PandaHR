using PandaHR.Api.Services.Exporter.Models.ExportModels;

namespace PandaHR.Api.Services.Exporter.Models.ExportTypes
{
    public abstract class CustomFile
    {
        protected byte[] _filecontents;

        protected CustomFile(string fileName, string contentType)
        {
            FileName = fileName;
            ContentType = contentType;
        }

        public byte[] FileContents => _filecontents;
        public string ContentType { get; }
        public string FileName { get; }

        public abstract CustomFile ProceedCV(string templatePath, CVExportModel cvModel);
    }
}
