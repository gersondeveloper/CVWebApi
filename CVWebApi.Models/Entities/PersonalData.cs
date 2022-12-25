using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace CVWebApi.Models.Entities;

[Table("PersonalDatas")]
public class PersonalData
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Email { get; set; }
    [Required] public List<string> PhoneNumberList {get ; set;}
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? WebSite { get; set; }
    [Required] public string Profile { get; set; }
    [Required] public string CurrentRole { get; set; }
    [Required] public string Country { get; set; }
    [Required] public string City { get; set; }


    public ICollection<Skill> Skills { get; set; }
    public ICollection<Education> Educations { get; set; }
    public ICollection<Experience> Experiences { get; set; }
    public ICollection<Reference>? References { get; set; }
}

public class PersonalDataValidator : AbstractValidator<PersonalData>
{
    public PersonalDataValidator()
    {
        RuleFor(x => x.City).NotNull().WithMessage("The city is required");
        RuleFor(x => x.Email).NotNull().WithMessage("The email is required");
        RuleFor(x => x.PhoneNumberList).NotEmpty().WithMessage("Must have at least one phonenumber");
        RuleFor(x => x.Profile).NotNull().WithMessage("The profile is required");
        RuleFor(x => x.CurrentRole).NotNull().WithMessage("The current role is required");
        RuleFor(x => x.Country).NotNull().WithMessage("The cuntry is required");
        RuleFor(x => x.City).NotNull().WithMessage("The city is required");
    }
}