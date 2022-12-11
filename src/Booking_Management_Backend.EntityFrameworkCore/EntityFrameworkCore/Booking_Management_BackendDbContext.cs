using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Booking_Management_Backend.Authorization.Roles;
using Booking_Management_Backend.Authorization.Users;
using Booking_Management_Backend.MultiTenancy;
using Booking_Management_Backend.Domain;

namespace Booking_Management_Backend.EntityFrameworkCore
{
    public class Booking_Management_BackendDbContext : AbpZeroDbContext<Tenant, Role, User, Booking_Management_BackendDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Booking>Bookings { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<StoredFile> StoredFiles { get; set; }
        public Booking_Management_BackendDbContext(DbContextOptions<Booking_Management_BackendDbContext> options)
            : base(options)
        {
        }
    }
}
