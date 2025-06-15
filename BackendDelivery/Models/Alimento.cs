using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDelivery.Models;

public class Alimento
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = "";

    [Required]
    public decimal Preco { get; set; }

    public double Nota { get; set; }

    public string Descricao { get; set; } = "";

    public string? FotoUrl { get; set; }

    public int TempoPreparo { get; set; } 

    public string Tipo { get; set; } = ""; 

    [ForeignKey("Restaurante")]
    public int RestauranteId { get; set; }
    public Restaurante Restaurante { get; set; } = null!;
}
