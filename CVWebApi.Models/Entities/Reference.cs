using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace CVWebApi.Models.Entities;

[Table("References")]
public class Reference
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? WebSite { get; set; }

    public Reference()
    {

    }

    public Reference(string name, string? email, string? phone, string? website)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Phone = phone;
        WebSite = website;
    }
}

public class ReferenceValidator : AbstractValidator<Reference>
{
    public ReferenceValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("Reference name is required.");
    }
}