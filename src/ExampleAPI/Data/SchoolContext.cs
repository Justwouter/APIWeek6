using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class SchoolContext : IdentityDbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options) : base(options){}

        public DbSet<Vak> Vak { get; set; } = default!;
    }
