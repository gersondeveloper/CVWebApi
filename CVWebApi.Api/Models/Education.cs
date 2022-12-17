using FluentValidation;

namespace CVWebApi.Models;

public class Education {
    public Guid Id { get; set; }
    public string EducationalInstitution { get; set; }
    public EducationalType EducationalType { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool isFinished { get; set; }
    public DateTime CreationDate { get; set; }
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