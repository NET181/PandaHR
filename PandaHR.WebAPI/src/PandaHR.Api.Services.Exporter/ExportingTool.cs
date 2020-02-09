using System.IO;
using PandaHR.Api.Services.Exporter.Models;
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

        public static CustomFile ToDocx(string templatePath)
        {

            using (MemoryStream mem = new MemoryStream(File.ReadAllBytes(templatePath)))
            {
                using (var outputDocument = new TemplateProcessor(mem)
                    .SetRemoveContentControls(true))
                {
                    var valuesToFill = new Content(
                        new FieldContent("FullName", "Kyrylo Rudenko")
                    );
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();
                    return new CustomFile(){FileContents = mem.ToArray(), ContentType = "application/msword", FileName = "Rudenko.docx"};
                }
            }
        }
    }
}
