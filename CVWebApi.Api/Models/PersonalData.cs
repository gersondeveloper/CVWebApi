using FluentValidation;

namespace CVWebApi.Models;

public class PersonalData {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> PhoneNumber { get; set; }
    public string?  GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? WebSite { get; set; }
    public string Profile { get; set; }
    public string CurrentRole { get; set; }
    public string Country { get; set; }
    public string City { get; set; }


    public virtual List<Skill> SkillsList { get; set;}
    public virtual List<Education> EducationList { get; set; }
    public virtual List<Experience> ExperienceList { get; set; }
    public virtual List<Reference>? ReferenceList { get; set; }
}

public class PersonalDataValidator : AbstractValidator<PersonalData>
{
    public PersonalDataValidator()
    {
        RuleFor(x => x.City).NotNull().WithMessage("The city is required");
        RuleFor(x => x.Email).NotNull().WithMessage("The email is required");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Must have at least one phonenumber");
        RuleFor(x => x.Profile).NotNull().WithMessage("The profile is required");
        RuleFor(x => x.CurrentRole).NotNull().WithMessage("The current role is required");
        RuleFor(x => x.Country).NotNull().WithMessage("The cuntry is required");
        RuleFor(x => x.City).NotNull().WithMessage("The city is required");
    }
}