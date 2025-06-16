namespace ProjetoDelivery.Models;

public class CarrinhoHistorico
{
    public int Id { get; set; }
    public Alimento? Nome { get; set; }
    public int UsuarioId { get; set; }
    public int AlimentoId { get; set; }
    public Alimento? Alimento { get; set; } 
    public int Quantidade { get; set; }
    public decimal Total { get; set; }
    public DateTime DataCompra { get; set; }
}
