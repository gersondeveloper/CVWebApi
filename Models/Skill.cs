namespace CVWebApi.Models;

public class Skill {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public SkillLevel SkillLevel { get; set; }
}