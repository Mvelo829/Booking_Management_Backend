using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Booking_Management_Backend.Configuration;

namespace Booking_Management_Backend.Web.Host.Startup
{
    [DependsOn(
       typeof(Booking_Management_BackendWebCoreModule))]
    public class Booking_Management_BackendWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Booking_Management_BackendWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Booking_Management_BackendWebHostModule).GetAssembly());
        }
    }
}
