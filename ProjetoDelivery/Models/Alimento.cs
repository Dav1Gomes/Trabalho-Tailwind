namespace ProjetoDelivery.Models;

public class Alimento
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public decimal Preco { get; set; }
    public double Nota { get; set; }
    public string Descricao { get; set; } = "";
    public string? FotoUrl { get; set; }
    public int TempoPreparo { get; set; }
    public string Tipo { get; set; } = "";

    public int RestauranteId { get; set; }
    public Restaurante Restaurante { get; set; } = new Restaurante();
}
