using Microsoft.EntityFrameworkCore;

public class CVDbContext : DbContext {

    public CVDbContext()
    {

    }

    public CVDbContext(DbContextOptions<CVDbContext> options) : base (options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DB_CVWebApi;User Id=sa;Password=MyPass@word;Trusted_Connection=False; ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating(modelBuilder);
    }

}