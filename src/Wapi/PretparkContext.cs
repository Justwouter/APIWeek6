namespace Wapi;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class PretparkContext : IdentityDbContext{
    public DbSet<Attractie> Attracties;

    protected override void OnModelCreating(ModelBuilder builder){
        var AttractionConfig = builder.Entity<Attractie>();
        AttractionConfig.ToTable("Attracties");
        AttractionConfig.HasKey(k => k.Id);

    }


    protected override void OnConfiguring(DbContextOptionsBuilder builder){
        builder.UseSqlite("Data Source=APIDB.db");
    }

}