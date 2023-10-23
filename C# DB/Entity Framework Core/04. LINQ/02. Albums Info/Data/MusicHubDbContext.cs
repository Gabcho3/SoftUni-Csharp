using MusicHub.Data.Models;

namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums{ get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<SongPerformer> SongPerformers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>().HasKey(sp => new { sp.SongId, sp.PerformerId });

            builder.Entity<Song>(entity =>
            {   
                entity.HasMany(s => s.SongPerformers)
                    .WithOne(sp => sp.Song)
                    .HasForeignKey(sp => sp.SongId);

                entity.HasOne(s => s.Album)
                    .WithMany(a => a.Songs)
                    .HasForeignKey(s => s.AlbumId);

                entity.HasOne(s => s.Writer)
                    .WithMany(w => w.Songs)
                    .HasForeignKey(s => s.WriterId);
            });

            builder.Entity<Performer>()
                .HasMany(p => p.PerformerSongs)
                .WithOne(sp => sp.Performer)
                .HasForeignKey(sp => sp.PerformerId);

            builder.Entity<Producer>()
                .HasMany(pr => pr.Albums)
                .WithOne(a => a.Producer)
                .HasForeignKey(a => a.ProducerId);
        }
    }
}
