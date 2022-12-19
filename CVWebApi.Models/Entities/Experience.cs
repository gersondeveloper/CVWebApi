using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

[Table("Experiences")]
public class Experience
{
    [Key] public Guid Id { get; private set; }
    [Required] public string CompanyName { get; private set; }
    [Required] public string Role { get; private set; }
    [Required] public DateTime StartDate { get; private set; }
    public DateTime? FinishDate { get; private set; }
    [Required] public string RoleDescription { get; private set; }
    [Required]
    public IEnumerable<string> TechnologiesList { get; private set; }

    public Experience()
    {

    }
    //create constructor
    private Experience(string companyName, string role, DateTime startDate, string roleDescription, IEnumerable<string> technologiesList)
    {
        Id = Guid.NewGuid();
        CompanyName = companyName;
        Role = role;
        StartDate = startDate;
        FinishDate = null;
        RoleDescription = roleDescription;
        TechnologiesList = technologiesList;
    }

    //update constructor
    private Experience(Guid id, string companyName, string role, DateTime startDate, DateTime? finishDate, string roleDescription, IEnumerable<string> technologiesList)
    {
        Id = id;
        CompanyName = companyName;
        Role = role;
        StartDate = startDate;
        FinishDate = finishDate;
        RoleDescription = roleDescription;
        TechnologiesList = technologiesList;
    }

    public Experience AddExperience(string companyName, string role, DateTime startDate, string roleDescription, IEnumerable<string> technologiesList)
    {
        return new Experience(companyName, role, startDate, roleDescription, technologiesList);
    }

    public Experience UpdateExperience(Guid id, string companyName, string role, DateTime startDate, DateTime? finishDate, string roleDescription, IEnumerable<string> technologiesList)
    {
        return new Experience(id, companyName, role, startDate, finishDate, roleDescription, technologiesList);
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