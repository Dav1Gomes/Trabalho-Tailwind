using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDelivery.Models;

public class Carrinho
{
    [Key]
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; } = null!;

    public int AlimentoId { get; set; }

    public int Quantidade { get; set; }

    public decimal Total { get; set; }

    public Alimento Alimento { get; set; } = null!;
}
