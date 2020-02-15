using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    public class KnowledgeScaleStepsAlgorithmModel
    {
        public int SoftKnowledgeScaleStep { get; set; }
        public int HardKnowledgeScaleStep { get; set; }
        public int LanguageKnowledgeScaleStep { get; set; }
        public int QualificationScaleStep { get; set; }
    }
}
