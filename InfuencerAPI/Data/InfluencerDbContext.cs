using InfuencerAPI.Models.Influencers;
using InfuencerAPI.Models.Orders;
using InfuencerAPI.Models.Master;
using InfuencerAPI.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace InfuencerAPI.Data
{
    public class InfluencerDbContext: DbContext
    {
        public InfluencerDbContext(DbContextOptions dbContextOption) : base(dbContextOption)
        {
            
        }

        public DbSet<Settings> Settings { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<Login> UsersLogin { get; set; }

        public DbSet<Influencer> Influencer { get; set; }
        public DbSet<RestDay> InfluencerRestDay { get; set; }
        public DbSet<Service> InfluencerServices { get; set; }
        public DbSet<Social> InfluencerSocials { get; set; }
        public DbSet<Time> InfluencerTime { get; set; }

        public DbSet<Orders> Order { get; set; }
        public DbSet<Detail> OrderDetails { get; set; }
        public DbSet<Calendar> OrderCalendars { get; set; }
        public DbSet<Target> OrderTargets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //INFLUENCERS
            // Influencer Default Value
            modelBuilder.Entity<Influencer>()
                .Property(b => b.IsActive)
                .HasDefaultValue(true);
            modelBuilder.Entity<Influencer>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // RestDay Default Value
            modelBuilder.Entity<RestDay>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // Service Default Value
            modelBuilder.Entity<Service>()
                .Property(b => b.Amount)
                .HasDefaultValue(0);
            modelBuilder.Entity<Service>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // Social Default Value
            modelBuilder.Entity<Social>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // Time Default Value
            modelBuilder.Entity<Time>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // MASTER
            // Settings Default Value
            modelBuilder.Entity<Settings>()
                .Property(b => b.IsActive)
                .HasDefaultValue(true);
            modelBuilder.Entity<Settings>()
                .Property(b => b.IsManageable)
                .HasDefaultValue(true);
            modelBuilder.Entity<Settings>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // ORDERS
            // Calendar Default Value
            modelBuilder.Entity<Calendar>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // Detail Default Value
            modelBuilder.Entity<Detail>()
                .Property(b => b.Amount)
                .HasDefaultValue(0);
            modelBuilder.Entity<Detail>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // Orders Default Value
            modelBuilder.Entity<Orders>()
                .Property(b => b.IsActive)
                .HasDefaultValue(true);
            modelBuilder.Entity<Orders>()
                .Property(b => b.IsApproved)
                .HasDefaultValue(false);
            modelBuilder.Entity<Orders>()
                .Property(b => b.Status)
                .HasDefaultValue("Order Received");
            modelBuilder.Entity<Orders>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // Target Default Value
            modelBuilder.Entity<Target>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // USERS
            // Login Default Value
            modelBuilder.Entity<Login>()
                .Property(b => b.EmailVerified)
                .HasDefaultValue(false);
            modelBuilder.Entity<Login>()
                .Property(b => b.PasswordVerified)
                .HasDefaultValue(true);
            modelBuilder.Entity<Login>()
                .Property(b => b.IsActive)
                .HasDefaultValue(false);
            modelBuilder.Entity<Login>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            // User Default Value
            modelBuilder.Entity<Users>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");
        }

    }
}
