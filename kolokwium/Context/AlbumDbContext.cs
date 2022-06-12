using Microsoft.EntityFrameworkCore;
using kolokwium.Models;

namespace kolokwium.Context
{
    public class AlbumDbContext : DbContext
    {
        // protected AlbumDbContext() {}
        public AlbumDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Musician>(p =>
            {
                p.HasData(
                    new Musician { IdMusician = 1, FirstName = "Jan", LastName = "Kowalski", Nickname = "janek" },
                    new Musician { IdMusician = 2, FirstName = "John", LastName = "Doe", Nickname = "JD" }
                );
            });

            modelbuilder.Entity<MusicianTrack>(p =>
            {
                p.HasKey(d => new { d.IdTrack, d.IdMusician });
                p.HasData(
                    new MusicianTrack { IdMusician = 1, IdTrack = 1 },
                    new MusicianTrack { IdMusician = 2, IdTrack = 2 }
                );
            });

            modelbuilder.Entity<Track>(p =>
            {
                p.HasData(
                    new Track { IdTrack = 1, TrackName = "Hit", Duration = 1, IdMusicAlbum = 1 },
                    new Track { IdTrack = 3, TrackName = "Letniaczek", Duration = 3, IdMusicAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "Rap", Duration = 5, IdMusicAlbum = 2 }
                );
            });

            modelbuilder.Entity<Album>(p =>
            {
                p.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Hity2022", PublishDate = DateTime.UtcNow, IdMusicLabel = 1 },
                    new Album { IdAlbum = 2, AlbumName = "Hity2021", PublishDate = DateTime.Now.AddYears(-1), IdMusicLabel = 2 }
                );
            });

            modelbuilder.Entity<MusicLabel>(p =>
            {
                p.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "Label1" },
                    new MusicLabel { IdMusicLabel = 2, Name = "Label2" }
                );
            });
            base.OnModelCreating(modelbuilder);
        }
    }
}