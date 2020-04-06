using AutoMapper;
using Eintech.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Eintech.Middleware
{
    public static class AutoMapperServiceCollectionExtension
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
