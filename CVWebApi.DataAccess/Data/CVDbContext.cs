using CVWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

public class CVDbContext : DbContext {

    public CVDbContext(DbContextOptions<CVDbContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Experience>(builder =>
        {
            builder.Property(x => x.TechnologiesList)
                .HasConversion(new ValueConverter<IEnumerable<string>,string>(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<string>>(v)));
        });
    }



    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<PersonalData> PersonalDatas { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Skill> Skills { get; set; }

}