using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Booking_Management_Backend.EntityFrameworkCore
{
    public static class Booking_Management_BackendDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Booking_Management_BackendDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Booking_Management_BackendDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
