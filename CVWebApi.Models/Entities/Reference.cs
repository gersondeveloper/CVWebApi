using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVWebApi.Models.Entities;

[Table("References")]
public class Reference
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? WebSite { get; set; }
}