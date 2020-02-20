using System.IO;
using PandaHR.Api.Services.Exporter.Models.ExportModels;
using TemplateEngine.Docx;

namespace PandaHR.Api.Services.Exporter.Models.ExportTypes
{
    public class DocxFile : CustomFile
    {
        private static readonly string CONTENT_TYPE = "application/msword";

        public DocxFile(string fileName) : base(fileName, CONTENT_TYPE)
        {
        }

        public override CustomFile ProceedCV(string templatePath, CVExportModel cvModel)
        {
            using (MemoryStream mem = new MemoryStream(File.ReadAllBytes(templatePath)))
            {
                using (var outputDocument = new TemplateProcessor(mem)
                    .SetRemoveContentControls(true))
                {
                    var valuesToFill = new Content(
                        new FieldContent("FullName", cvModel.FullName),
                        new FieldContent("Qualification", cvModel.Qualification),
                        new FieldContent("Summary", cvModel.Summary)
                    );

                    ListContent skillsList = new ListContent("Skills Nested List");
                    foreach (var technology in cvModel.Technologies)
                    {
                        ListItemContent technologyListItem = new ListItemContent("Technology", technology.Name);
                        ListContent skillItem = new ListContent("Skill");
                        foreach (var skill in technology.Skills)
                        {
                            skillItem.AddItem(
                                new FieldContent("SkillName", skill.Name),
                                new FieldContent("KnowledgeLevel", skill.KnowledgeLevel));
                        }
                        technologyListItem.AddList(skillItem);
                        skillsList.AddItem(technologyListItem);
                    }
                    valuesToFill.Lists.Add(skillsList);

                    TableContent experienceTable = new TableContent("ExperienceTable");
                    foreach (var jobExperienceModel in cvModel.JobExperiences)
                    {
                        experienceTable.AddRow(
                            new FieldContent("Company", jobExperienceModel.Company),
                            new FieldContent("Project", jobExperienceModel.Project),
                            new FieldContent("ProjectDescription", jobExperienceModel.Description),
                            new FieldContent("Period", jobExperienceModel.Period),
                            new FieldContent("Space", string.Empty));
                    }
                    valuesToFill.Tables.Add(experienceTable);

                    TableContent educationTable = new TableContent("EducationTable");
                    foreach (var educationModel in cvModel.Educations)
                    {
                        educationTable.AddRow(
                            new FieldContent("Place", educationModel.Place),
                            new FieldContent("Speciality", educationModel.Speciality),
                            new FieldContent("Degree", educationModel.Degree),
                            new FieldContent("Period", educationModel.Period),
                            new FieldContent("Space", string.Empty));
                    }
                    valuesToFill.Tables.Add(educationTable);

                    outputDocument.SetNoticeAboutErrors(false);
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();

                    _filecontents = mem.ToArray();

                    return this;
                }
            }
        }
    }
}
