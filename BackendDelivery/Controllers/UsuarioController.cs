using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendDelivery.Data;
using BackendDelivery.DTOs;
using BackendDelivery.Models;
using BCrypt.Net;

namespace BackendDelivery.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(AppDbContext context) : ControllerBase
{
    [HttpPost("registro")]
    public async Task<IActionResult> Registrar([FromBody] UsuarioRegistroDTO dto)
    {
        var existe = await context.Usuarios.AnyAsync(u => u.Email == dto.Email);
        if (existe)
            return BadRequest("Email já registrado.");

        var novo = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            CPF = dto.CPF,
            CEP = dto.CEP,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            Saldo = 0
        };

        context.Usuarios.Add(novo);
        await context.SaveChangesAsync();
        return Ok(novo);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] DTOs.LoginRequest login)
    {
        var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == login.Email);
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(login.Senha, usuario.SenhaHash))
            return Unauthorized("Credenciais inválidas.");

        return Ok(usuario);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarUsuario(int id)
    {
        var usuario = await context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        return Ok(usuario);
    }


    [HttpPost("{id}/adicionar-saldo")]
    public async Task<IActionResult> AdicionarSaldo(int id, [FromBody] decimal valor)
    {
        if (valor <= 0)
            return BadRequest("Valor inválido.");

        var usuario = await context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        usuario.Saldo += valor;
        await context.SaveChangesAsync();

        return Ok(new { mensagem = "Saldo adicionado com sucesso", saldoAtual = usuario.Saldo });
    }



    [HttpGet("{id}/cartoes")]
    public async Task<IActionResult> ObterCartoes(int id)
    {
        var usuario = await context.Usuarios
            .Include(u => u.Cartoes)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        return Ok(usuario.Cartoes);
    }

    [HttpPut("editar/{id}")]
    public async Task<IActionResult> EditarUsuario(int id, [FromBody] AtualizarCepCpfDTO dados)
    {
        var usuario = await context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        usuario.CPF = dados.CPF;
        usuario.CEP = dados.CEP;

        var result = await context.SaveChangesAsync();
        return result > 0 ? Ok(usuario) : BadRequest("Nada foi alterado.");
    }



   [HttpPost("{id}/cartoes")]
    public async Task<IActionResult> AdicionarCartao(int id, [FromBody] Cartao novoCartao)
    {
        if (string.IsNullOrWhiteSpace(novoCartao.Numero) ||
            string.IsNullOrWhiteSpace(novoCartao.CVV) ||
            string.IsNullOrWhiteSpace(novoCartao.Validade) ||
            string.IsNullOrWhiteSpace(novoCartao.Tipo))
        {
            return BadRequest("Todos os campos do cartão são obrigatórios.");
        }

        var usuario = await context.Usuarios.Include(u => u.Cartoes).FirstOrDefaultAsync(u => u.Id == id);
        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        novoCartao.UsuarioId = id;

        try
        {
            context.Cartoes.Add(novoCartao);
            await context.SaveChangesAsync();
            return Ok(novoCartao);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao salvar no banco: {ex.Message}");
        }
    }






}
