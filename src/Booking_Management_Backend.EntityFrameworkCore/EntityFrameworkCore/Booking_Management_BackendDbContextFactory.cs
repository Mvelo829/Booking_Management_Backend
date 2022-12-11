using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Booking_Management_Backend.Configuration;
using Booking_Management_Backend.Web;

namespace Booking_Management_Backend.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Booking_Management_BackendDbContextFactory : IDesignTimeDbContextFactory<Booking_Management_BackendDbContext>
    {
        public Booking_Management_BackendDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Booking_Management_BackendDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Booking_Management_BackendDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Booking_Management_BackendConsts.ConnectionStringName));

            return new Booking_Management_BackendDbContext(builder.Options);
        }
    }
}
