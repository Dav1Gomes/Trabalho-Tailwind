namespace ProjetoDelivery.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string CEP { get; set; } = string.Empty;
    public decimal Saldo { get; set; } = 0;
    public List<Cartao>? Cartoes { get; set; }
}
