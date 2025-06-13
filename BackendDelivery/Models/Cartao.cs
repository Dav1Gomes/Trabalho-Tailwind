namespace BackendDelivery.Models;

public class Cartao
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public string Cvv { get; set; }
    public string Validade { get; set; }
    public int UsuarioId { get; set; }
}
