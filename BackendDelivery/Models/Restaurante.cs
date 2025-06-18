using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; 

namespace BackendDelivery.Models;

public class Restaurante
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = "";

    [Required]
    public string Local { get; set; } = "";

    public string Tipo { get; set; } = "";

    public double Nota { get; set; }

    [JsonIgnore]    
    public List<Alimento> Alimentos { get; set; } = new();
}
