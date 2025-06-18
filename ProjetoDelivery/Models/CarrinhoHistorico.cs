namespace ProjetoDelivery.Models;

public class CarrinhoHistorico
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int AlimentoId { get; set; }

    public Alimento Alimento { get; set; } = new Alimento();

    public int Quantidade { get; set; }
    public decimal Total { get; set; }
    public DateTime DataCompra { get; set; }
}
