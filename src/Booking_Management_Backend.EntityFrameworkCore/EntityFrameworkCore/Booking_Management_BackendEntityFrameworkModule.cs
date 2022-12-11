using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Booking_Management_Backend.EntityFrameworkCore.Seed;

namespace Booking_Management_Backend.EntityFrameworkCore
{
    [DependsOn(
        typeof(Booking_Management_BackendCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class Booking_Management_BackendEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<Booking_Management_BackendDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        Booking_Management_BackendDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        Booking_Management_BackendDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Booking_Management_BackendEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
