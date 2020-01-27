using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PandaHR.Api.Common;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.EF;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Repositories.Contracts;
using PandaHR.Api.DAL.Repositories.Implementation;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Implementation;

namespace PandaHR.Api.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration["ConnectionString"];

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));

            services.AddScoped<IDataInitializer, EFDataInitializer>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepositoryAsync<>));

            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ICVRepository, CVRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobExperienceRepository, JobExperienceRepository>();

            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICVService, CVService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJobExperienceService, JobExperienceService>();
          
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IMapper, PandaHRAutoMapper>();
        }
    }
}
