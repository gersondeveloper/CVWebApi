using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace CVWebApi.Models.Entities;

[Table("Skills")]
public class Skill
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public SkillLevel SkillLevel { get; set; }
}

public class SkillValidator : AbstractValidator<Skill>
{
    public SkillValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("Skill name is required.");
    }
}