using System.Net.Http.Json;
using ProjetoDelivery.Models;


namespace ProjetoDelivery.Services;

public class CarrinhoService
{
    private readonly HttpClient _http;

    public CarrinhoService(HttpClient http)
    {
        _http = http;
    }

    public async Task<(bool sucesso, string mensagem, decimal novoSaldo)> ComprarAsync(int usuarioId, int alimentoId, int quantidade)
    {
        var dto = new
        {
            UsuarioId = usuarioId,
            AlimentoId = alimentoId,
            Quantidade = quantidade
        };

        var response = await _http.PostAsJsonAsync("http://localhost:5291/api/carrinho/comprar", dto);

        if (response.IsSuccessStatusCode)
        {
            var resultado = await response.Content.ReadFromJsonAsync<CompraResposta>();
            return (true, resultado?.Mensagem ?? "Compra realizada", resultado?.NovoSaldo ?? 0);
        }

        var erro = await response.Content.ReadAsStringAsync();
        return (false, erro, 0);
    }

    private class CompraResposta
    {
        public string Mensagem { get; set; } = "";
        public decimal NovoSaldo { get; set; }
    }

    public async Task<List<Pages.ItemCarrinho.ItemCarrinhoModel>> ListarCarrinhoAsync(int usuarioId)
    {
        return await _http.GetFromJsonAsync<List<Pages.ItemCarrinho.ItemCarrinhoModel>>($"http://localhost:5291/api/carrinho/{usuarioId}")
            ?? new();
    }

    public async Task<bool> RemoverItemAsync(int carrinhoId)
    {
        var response = await _http.DeleteAsync($"http://localhost:5291/api/carrinho/{carrinhoId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<(bool sucesso, string mensagem, decimal novoSaldo)> FinalizarCarrinhoAsync(int usuarioId)
    {
        var response = await _http.PostAsync($"http://localhost:5291/api/carrinho/{usuarioId}/comprar", null);
        if (!response.IsSuccessStatusCode)
            return (false, "Erro ao finalizar", 0);

        var novoSaldo = decimal.Parse(await response.Content.ReadAsStringAsync());
        return (true, "Compra confirmada!", novoSaldo);
    }

    public async Task<bool> AdicionarAoCarrinhoAsync(int usuarioId, int alimentoId, int quantidade)
    {
        var dto = new
        {
            UsuarioId = usuarioId,
            AlimentoId = alimentoId,
            Quantidade = quantidade
        };

        var response = await _http.PostAsJsonAsync("http://localhost:5291/api/carrinho/adicionar", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<CarrinhoHistorico>> ListarHistoricoAsync(int usuarioId)
    {
        return await _http.GetFromJsonAsync<List<CarrinhoHistorico>>(
            $"http://localhost:5291/api/carrinho/historico/{usuarioId}"
        ) ?? new();
    }




}
