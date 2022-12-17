using FluentValidation;

public class Experience {
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Role { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public string RoleDescription { get; set; }
    public List<string> TechnologiesList { get; set; }
}

public class ExperienceValidator : AbstractValidator<Experience>
{
    public ExperienceValidator()
    {
        RuleFor(x => x.Role).NotNull().WithMessage("The role is required");
        RuleFor(x => x.CompanyName).NotNull().WithMessage("The company name is required");
        RuleFor(x => x.StartDate).NotNull().WithMessage("The start date is required");
        RuleFor(x => x.RoleDescription).NotNull().WithMessage("The role description is required");
        RuleFor(x => x.TechnologiesList).NotEmpty().WithMessage("Technologies list must have at least one item");
    }
}