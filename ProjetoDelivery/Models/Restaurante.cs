namespace ProjetoDelivery.Models;
public class Restaurante
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Local { get; set; } = "";
    public string Tipo { get; set; } = "";
    public double Nota { get; set; }
    public List<Alimento> Alimentos { get; set; } = new();
}
