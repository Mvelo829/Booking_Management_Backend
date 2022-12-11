using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Booking_Management_Backend.Configuration;
using Booking_Management_Backend.EntityFrameworkCore;
using Booking_Management_Backend.Migrator.DependencyInjection;

namespace Booking_Management_Backend.Migrator
{
    [DependsOn(typeof(Booking_Management_BackendEntityFrameworkModule))]
    public class Booking_Management_BackendMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Booking_Management_BackendMigratorModule(Booking_Management_BackendEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(Booking_Management_BackendMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                Booking_Management_BackendConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Booking_Management_BackendMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
