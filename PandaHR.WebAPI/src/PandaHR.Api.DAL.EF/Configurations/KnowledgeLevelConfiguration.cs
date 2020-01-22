using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class KnowledgeLevelConfiguration : IEntityTypeConfiguration<KnowledgeLevel>
    {
        public void Configure(EntityTypeBuilder<KnowledgeLevel> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
