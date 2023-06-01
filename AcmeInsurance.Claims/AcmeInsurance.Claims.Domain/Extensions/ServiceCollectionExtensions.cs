using AcmeInsurance.Claims.Domain.Adapters;
using AcmeInsurance.Claims.Domain.Mappers;
using AcmeInsurance.Claims.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeInsurance.Claims.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClaimsServices(this IServiceCollection services)
        {
            services.AddScoped<IClaimMapper, ClaimMapper>();
            services.AddScoped<ICompanyMapper, CompanyMapper>();
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddScoped<ITimeProvider, TimeProvider>();
            return services;
        }
    }
}
