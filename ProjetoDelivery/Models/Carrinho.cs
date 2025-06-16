namespace ProjetoDelivery.Models;
public class Carrinho

{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int AlimentoId { get; set; }
    public Alimento? Alimento { get; set; }
    public int Quantidade { get; set; }
    public decimal Total { get; set; }
}
