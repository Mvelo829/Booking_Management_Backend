using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Booking_Management_Backend.Authorization;

namespace Booking_Management_Backend
{
    [DependsOn(
        typeof(Booking_Management_BackendCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Booking_Management_BackendApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Booking_Management_BackendAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Booking_Management_BackendApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
