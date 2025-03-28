using Microsoft.EntityFrameworkCore;
using MusicPlayer.Core.Models;

namespace MusicPlayer.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Song>()
            .Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Song>()
            .Property(s => s.Artist)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Song>()
            .Property(s => s.Album)
            .HasMaxLength(200);

        modelBuilder.Entity<Song>()
            .Property(s => s.FilePath)
            .IsRequired();

        modelBuilder.Entity<Song>()
            .Property(s => s.DurationMs)
            .IsRequired();

        modelBuilder.Entity<Song>()
            .Property(s => s.Genre)
            .HasMaxLength(100);
    }
}