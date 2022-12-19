namespace CVWebApi.ViewModel;

public class ExperienceViewModel
{
    public Guid Id { get; private set; }
    public string CompanyName { get; private set; }
    public string Role { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? FinishDate { get; private set; }
    public string RoleDescription { get; private set; }
    public IEnumerable<string> TechnologiesList { get; private set; }
}