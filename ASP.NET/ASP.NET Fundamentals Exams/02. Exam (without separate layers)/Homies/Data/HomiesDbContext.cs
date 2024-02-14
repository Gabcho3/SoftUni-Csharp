using Homies.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Homies.Data.Models.Type;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<Type> Types { get; set; } = null!;

        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>()
                .HasKey(x => new { x.HelperId, x.EventId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(x => x.Helper)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}