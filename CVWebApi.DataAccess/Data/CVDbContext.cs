using System.Text.Json;
using CVWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using JsonSerializer = System.Text.Json.JsonSerializer;

public class CVDbContext : DbContext {

    public CVDbContext(DbContextOptions<CVDbContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Experience>()
            .Property(e => e.TechnologiesList)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));
    }



    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<PersonalData> PersonalDatas { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Skill> Skills { get; set; }

}