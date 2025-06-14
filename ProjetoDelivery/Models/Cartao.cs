namespace ProjetoDelivery.Models;

public class Cartao
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Validade { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
    public string Tipo { get; set; } = string.Empty;

}

