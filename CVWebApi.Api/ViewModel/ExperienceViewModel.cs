namespace CVWebApi.ViewModel;

public class ExperienceViewModel
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Role { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public string RoleDescription { get; set; }
    public IEnumerable<string> TechnologiesList { get; set; }
}