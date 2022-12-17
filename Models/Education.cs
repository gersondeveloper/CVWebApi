namespace CVWebApi.Models;

public class Education {
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string EducationalInstitution { get; set; }
    public EducationalType EducationalType { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool isFinished { get; set; }
    public DateTime CreationDate { get; set; }
    public bool isActive { get; set; }
}