namespace CVWebApi.Models;

public class Reference {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? WebSite { get; set; }
}