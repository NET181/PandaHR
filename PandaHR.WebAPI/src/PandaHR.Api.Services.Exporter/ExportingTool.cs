using System;
using System.IO;
using PandaHR.Api.Services.Exporter.Models;
using PandaHR.Api.Services.Exporter.Models.Enums;
using PandaHR.Api.Services.Exporter.Models.ExportModels;
using PandaHR.Api.Services.Exporter.Models.ExportTypes;
using TemplateEngine.Docx;


namespace PandaHR.Api.Services.Exporter
{
    public class ExportingTool
    {
        //private readonly string _templatePath;

        //public Exporter(string templatePath)
        //{
        //    _templatePath = templatePath;
        //}

        public static CustomFile ExportCV(string templatePath, CVExportModel cvModel, ExportType exportType = ExportType.Docx)
        {
            CustomFile file;
            switch (exportType)
            {
                case ExportType.Docx:
                {
                    file = new DocxFile(cvModel.FullName);
                    break;
                }
                default:
                {
                    throw new ArgumentNullException();
                }
            }

            return file.ProceedCV(templatePath, cvModel);
        }
    }
}
