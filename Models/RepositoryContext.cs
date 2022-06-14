using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Musician> Musician { get; set; }
        public DbSet<Musician> Track { get; set; }
        public DbSet<Musician> Musician_Track { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>(e =>
            {
                e.ToTable("Musician");
                e.HasKey(e => e.IdMusician);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.HasData(
                    new Models.Musician
                    {
                        IdMusician = 1,
                        FirstName = "Czesław",
                        LastName = "Kowalski",
                        Nickname = "Young Czechu"
                    }
                );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.ToTable("Track");
                e.HasKey(e => e.IdTrack);

                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();

                e.HasData(
                    new Models.Track
                    {
                        IdTrack = 1,
                        TrackName = "Skoncze na ulicy",
                        Duration = 3.5f
                    },
                    new Models.Track
                    {
                        IdTrack = 2,
                        TrackName = "Oda do ITNa",
                        Duration = 3
                    }
                );
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.ToTable("Musician_Track");
                e.HasKey(e => new { e.IdMusician, e.IdTrack });

                e.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.ClientCascade);
                e.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician).OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(
                    new Models.Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 1
                    },
                    new Models.Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 2
                    }
                );
            });
        }
    }
}
