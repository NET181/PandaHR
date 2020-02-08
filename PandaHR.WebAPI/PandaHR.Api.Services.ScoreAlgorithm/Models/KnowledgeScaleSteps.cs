using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlgorithm.Models
{
    public class KnowledgeScaleSteps
    {
        public KnowledgeScaleSteps(int softKnowledgeScaleStep, int hardKnowledgeScaleStep, int languageKnowledgeScaleStep, int qualificationScaleStep)
        {
            SoftKnowledgeScaleStep = softKnowledgeScaleStep;
            HardKnowledgeScaleStep = hardKnowledgeScaleStep;
            LanguageKnowledgeScaleStep = languageKnowledgeScaleStep;
            QualificationScaleStep = qualificationScaleStep;
        }

        public int SoftKnowledgeScaleStep { get; }
        public int HardKnowledgeScaleStep { get; }
        public int LanguageKnowledgeScaleStep { get; }
        public int QualificationScaleStep { get; }
    }
}
