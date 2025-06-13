namespace BackendDelivery.Models;

public class Carrinho
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public int AlimentoId { get; set; }
    // public Alimento Alimento { get; set; } 
}
