public class CarrinhoDto
{
    public int Id { get; set; }
    public int AlimentoId { get; set; }
    public string Nome { get; set; } = "";
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}
