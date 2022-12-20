using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

[Table("Experiences")]
public class Experience
{
    [Key]
    public Guid Id { get; private set; }

    [Required]
    public string CompanyName { get;  set; }

    [Required]
    public string Role { get;  set; }

    [Required]
    public DateTime StartDate { get;  set; }

    public DateTime? FinishDate { get;  set; }

    [Required]
    public string RoleDescription { get;  set; }

    [Required]
    public List<string> TechnologiesList { get; set; }

    public Experience()
    {

    }

    public Experience(string companyName, string role, DateTime startDate, DateTime? finishDate, string roleDescription, List<string> technologiesList)
    {
        Id = Guid.NewGuid();
        CompanyName = companyName;
        Role = role;
        StartDate = startDate;
        FinishDate = finishDate;
        RoleDescription = roleDescription;
        TechnologiesList = technologiesList;
    }
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