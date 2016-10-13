using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Staff>().Property(p => p.StaffFullName).HasComputedColumnSql("[StaffFirstName] + ' ' + [StaffLastName]");
            builder.Entity<CustomerGuest>().Property(p => p.CustomerFullName).HasComputedColumnSql("[CustomerFirstName] + ' ' + [CustomerLastName]");
            builder.Entity<Booking>().Property(p => p.BookingRange).HasComputedColumnSql("'Arrives:' + CONVERT(VARCHAR(10), [ArrivalDate], 103) + '- Departs:' + CONVERT(VARCHAR(10), [DepartureDate], 103) ");


        }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Agency> Agency { get; set; }
        public DbSet<Alarm> Alarm { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<BedType> BedType { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Carpark> Carpark { get; set; }
        public DbSet<ChargeBack> ChargeBack { get; set; }
        public DbSet<CreditCardDetails> CreditCardDetails { get; set; }
        public DbSet<CustomerGuest> CustomerGuest { get; set; }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<JobPosition> JobPosition { get; set; }
        public DbSet<MessageAlert> MessageAlert { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<CheckInStatus> CheckInStatus { get; set; }
        public DbSet<CalendarToRoom> CalendarToRoom { get; set; }
    }
}
