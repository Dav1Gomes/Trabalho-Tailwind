using System.Net.Http.Json;
using System.Threading.Tasks;
using ProjetoDelivery.Models;


namespace ProjetoDelivery.Services;

public class UsuarioService
{
    private readonly HttpClient _http;

    public UsuarioService(HttpClient http)
    {
        _http = http;
    }

    public async Task<HttpResponseMessage> RegistrarAsync(Usuario usuario)
    {
        return await _http.PostAsJsonAsync("http://localhost:5291/api/usuario/registro", usuario);
    }

    public async Task<HttpResponseMessage> LoginAsync(LoginRequest login)
    {
        return await _http.PostAsJsonAsync("http://localhost:5291/api/usuario/login", login);
    }
}
