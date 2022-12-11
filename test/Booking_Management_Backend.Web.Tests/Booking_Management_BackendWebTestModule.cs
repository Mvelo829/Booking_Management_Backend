using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Booking_Management_Backend.EntityFrameworkCore;
using Booking_Management_Backend.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Booking_Management_Backend.Web.Tests
{
    [DependsOn(
        typeof(Booking_Management_BackendWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class Booking_Management_BackendWebTestModule : AbpModule
    {
        public Booking_Management_BackendWebTestModule(Booking_Management_BackendEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Booking_Management_BackendWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(Booking_Management_BackendWebMvcModule).Assembly);
        }
    }
}