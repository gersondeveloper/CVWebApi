using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace CVWebApi.Models.Entities;

[Table("Educations")]
public class Education
{
    [Key] public Guid Id { get; set; }

    [Required] public string EducationalInstitution { get; set; }
    public EducationalType EducationalType { get; set; }
    [Required] public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool isFinished { get; set; }
    [Required] public DateTime CreationDate { get; set; }
    public bool isActive { get; set; }
}

public class EducationValidator : AbstractValidator<Education>
{
    public EducationValidator()
    {
        RuleFor(x => x.EducationalInstitution).NotNull().WithMessage("Educational institution is required");
        RuleFor(x => x.EducationalType).NotNull().WithMessage("Educational type is required");
        RuleFor(x => x.StartTime).NotNull().WithMessage("Start time is required");
    }
}