using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.EF.Configurations
{
    public class VacancyCityConfiguration : IEntityTypeConfiguration<VacancyCity>
    {
        public void Configure(EntityTypeBuilder<VacancyCity> builder)
        {
            builder.HasKey(cc => new { cc.VacancyId, cc.CityId });

            builder.HasOne(cc => cc.City)
                .WithMany(c => c.VacancyCities)
                .HasForeignKey(cc => cc.CityId);

            builder.HasOne(cc => cc.Vacancy)
                .WithMany(c => c.VacancyCities)
                .HasForeignKey(cc => cc.VacancyId);
        }
    }
}
