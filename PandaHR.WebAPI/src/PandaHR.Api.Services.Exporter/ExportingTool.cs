using System;
using PandaHR.Api.Services.Exporter.Models.Enums;
using PandaHR.Api.Services.Exporter.Models.ExportModels;
using PandaHR.Api.Services.Exporter.Models.ExportTypes;


namespace PandaHR.Api.Services.Exporter
{
    public class ExportingTool
    {
        private readonly CustomFile _file;

        public ExportingTool(string fileName, ExportType exportType)
        {
            _file = GetFileForExport(fileName, exportType);
        }

        public CustomFile ExportCV(string templatePath, CVExportModel cvModel)
        {
            return _file.ProceedCV(templatePath, cvModel);
        }

        private CustomFile GetFileForExport(string fileName, ExportType exportType = ExportType.Docx)
        {
            CustomFile file;
            switch (exportType)
            {
                case ExportType.Docx:
                    {
                        file = new DocxFile(fileName);
                        break;
                    }
                default:
                    {
                        throw new ArgumentNullException();
                    }
            }

            return file;
        }
    }
}
