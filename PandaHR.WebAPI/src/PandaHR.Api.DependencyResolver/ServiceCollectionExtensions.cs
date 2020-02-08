using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PandaHR.Api.Common;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.EF;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using PandaHR.Api.DAL.Repositories.Implementation;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Implementation;
using PandaHR.Api.Services.ScoreAlghorythm;

namespace PandaHR.Api.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration["ConnectionString"];

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));

            //services.AddDefaultIdentity<User>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IDataInitializer, EFDataInitializer>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepositoryAsync<>));

            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ICVRepository, CVRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IVacancyCityRepository, VacancyCityRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserCompanyRepository, UserCompanyRepository>();
            services.AddScoped<ICompanyCityRepository, CompanyCityRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<ISkillRequirementRepository, SkillRequirementRepository>();
            services.AddScoped<ISkillTypeRepository, SkillTypeRepository>();
            services.AddScoped<IJobExperienceRepository, JobExperienceRepository>();
            services.AddScoped<IDegreeRepository, DegreeRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<IKnowledgeLevelRepository, KnowledgeLevelRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICVService, CVService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISkillRequirementService, SkillRequirementService>();
            services.AddScoped<IQualificationService, QualificationService>();
            services.AddScoped<IJobExperienceService, JobExperienceService>();
            services.AddScoped<IDegreeService, DegreeService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<ISpecialityService, SpecialityService>();
            services.AddScoped<IKnowledgeLevelService, KnowledgeLevelService>();
            services.AddScoped<ISkillTypeService, SkillTypeService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<ITechnologyService, TechnologyService>();

            services.AddScoped<IScoreCounter, ScoreCounter>();
            services.AddScoped<IScoreAlghorythm, ScoreAlghorythm>();

            services.AddSingleton<PandaHR.Api.Common.Contracts.IMapper, PandaHRAutoMapper>();
        }
    }
}
