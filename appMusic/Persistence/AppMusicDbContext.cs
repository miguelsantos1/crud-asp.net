using appMusic.Entities;
using Microsoft.EntityFrameworkCore;

namespace appMusic.Persistence
{
    public class AppMusicDbContext : DbContext
    {
        public AppMusicDbContext(DbContextOptions<AppMusicDbContext> options) : base(options)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Music> Musics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {



            builder.Entity<Artist>(a =>
            {
                a.HasKey(artist => artist.Id);
                a.HasMany(artist => artist.Musics)
                    .WithOne()
                    .HasForeignKey(music => music.ArtistId)
                ;
            });

            builder.Entity<Music>(m =>
            {
                m.HasKey(music => music.Id);
            });




        }
    }
}
