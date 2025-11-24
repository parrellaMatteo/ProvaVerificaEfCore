using System;
using CognomeNomeMusicManager.Model;
using Microsoft.EntityFrameworkCore;

namespace CognomeNomeMusicManager.Data;

public class MusicContext:DbContext
{
    public DbSet<Festival> Festival { get; set;}
    public DbSet<Cantante> Cantante { get; set;}
    public DbSet<Esibizione> Esibizione { get; set;}
    public DbSet<Etichetta> Etichetta { get; set;}
    public string DbPath { get;  }=null!;
    public MusicContext()
    {
         var cartellaApp = AppContext.BaseDirectory;
        DbPath = Path.Combine(cartellaApp, "../../../MusicContext.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cantante>()
        .HasMany(s=> s.Festivals)
        .WithMany(s => s.Cantanti)
        .UsingEntity<Esibizione>();
    }
}
