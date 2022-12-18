using System.ComponentModel.DataAnnotations;

namespace CVWebApi.Models.Entities;

public class PhoneNumber {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Number { get; set; }
}