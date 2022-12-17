using CVWebApi.Models;
using Microsoft.EntityFrameworkCore;

public class CVDbContext : DbContext {

   public CVDbContext(DbContextOptions<CVDbContext> options) : base (options)
    {

    }

    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<PersonalData> PersonalDatas { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Skill> Skills { get; set; }

}