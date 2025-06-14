namespace BackendDelivery.Models;

public class Cartao
{
    public int Id { get; set; }
    public required string Numero { get; set; }
    public required string Validade { get; set; }
    public required string CVV { get; set; }
    public required string Tipo { get; set; }
    public int UsuarioId { get; set; }
}

