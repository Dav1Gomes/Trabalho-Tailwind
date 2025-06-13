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

    [HttpPost("{id}/adicionar-saldo")]
    public async Task<IActionResult> AdicionarSaldo(int id, [FromBody] decimal valor)
    {
        if (valor <= 0)
            return BadRequest("Valor inválido.");

        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        usuario.Saldo += valor;
        await _context.SaveChangesAsync();

        return Ok(new { mensagem = "Saldo adicionado com sucesso", saldoAtual = usuario.Saldo });
    }


    [HttpGet("{id}/cartoes")]
    public async Task<IActionResult> ObterCartoes(int id)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Cartoes)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        return Ok(usuario.Cartoes);
    }



}
