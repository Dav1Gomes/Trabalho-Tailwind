using ProjetoDelivery.Models;

namespace ProjetoDelivery.Services;

public class UserStateService
{
    private readonly UsuarioService _usuarioService;

    public string UserName { get; set; } = string.Empty;
    public int UserId { get; set; }
    public decimal Saldo { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string CEP { get; set; } = string.Empty;

    public event Action? OnChange;

    public UserStateService(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public void SetUser(int id, string nome, decimal saldo, string cpf = "", string cep = "")
    {
        UserId = id;
        UserName = nome;
        Saldo = saldo;
        CPF = cpf;
        CEP = cep;
        NotifyStateChanged();
    }

    public async Task<Usuario> GetUsuarioAtual()
{
    var usuario = await _usuarioService.BuscarPorIdAsync(UserId);

    if (usuario is not null)
    {
        UserName = usuario.Nome;
        Saldo = usuario.Saldo;
        CPF = usuario.CPF;
        CEP = usuario.CEP;

        NotifyStateChanged(); 
        return usuario;
    }

    return new Usuario
    {
        Id = UserId,
        Nome = UserName,
        Saldo = Saldo,
        CPF = CPF,
        CEP = CEP
    };
}


    public void NotifyStateChanged() => OnChange?.Invoke();
    
}
