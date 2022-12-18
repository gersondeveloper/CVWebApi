using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVWebApi.Models.Entities;

[Table("Skills")]
public class Skill
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    public SkillLevel SkillLevel { get; set; }
}