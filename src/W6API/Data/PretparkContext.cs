using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class PretparkContext : IdentityDbContext
{
    public PretparkContext (DbContextOptions<PretparkContext> options): base(options){}

    public DbSet<Attractie> Attractie { get; set; } = default!;

    public DbSet<GebruikerMetWachwoord> Gebruikers {get;set;} = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); 
        //builder.Entity<GebruikerMetWachwoord>().HasData();
        builder.Entity<Attractie>()
            .HasMany(p => p.UserLikes)
            .WithMany(p => p.LikedAttractions)

            .UsingEntity<Dictionary<string, object>>(
                "Likes",
                j => j
                    .HasOne<GebruikerMetWachwoord>()
                    .WithMany()
                    .HasForeignKey("GebruikerId")
                    .HasConstraintName("FK_Likes_Gebruikers_GebruikerId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Attractie>()
                    .WithMany()
                    .HasForeignKey("AttractieId")
                    .HasConstraintName("FK_Likes_Attracties_AttractieId")
                    .OnDelete(DeleteBehavior.ClientCascade));

        builder.Entity<Role>().HasData(new Role(){Name = "Medewerker", NormalizedName = "MEDEWERKER"});
        builder.Entity<Role>().HasData(new Role(){Name = "Gast", NormalizedName = "GAST"});
    }
}
