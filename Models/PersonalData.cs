namespace CVWebApi.Models;

public class PersonalData {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> PhoneNumber { get; set; }
    public string?  GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
    public string Profle { get; set; }
    public string CurrentRole { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string? WebSite { get; set; }

    public virtual List<Skill> SkillsList { get; set;}
    public virtual List<Education> EducationList { get; set; }
    public virtual List<Experience> ExperienceList { get; set; }
    public virtual List<Reference> ReferenceList { get; set; }
}