using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDelivery.Models;

public class CarrinhoHistorico
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UsuarioId { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuario? Usuario { get; set; }

    [Required]
    public int AlimentoId { get; set; }

    [ForeignKey("AlimentoId")]
    public Alimento? Alimento { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    public decimal Total { get; set; }

    public DateTime DataCompra { get; set; } = DateTime.Now;
}
