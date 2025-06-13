using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDelivery.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string SenhaHash { get; set; } = string.Empty;

    public decimal Saldo { get; set; } = 0;

    public string CPF { get; set; } = string.Empty;

    public string CEP { get; set; } = string.Empty;

    public List<Cartao>? Cartoes { get; set; }

    public List<Carrinho>? Carrinho { get; set; }
}
