using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendDelivery.Data;
using BackendDelivery.Models;

namespace BackendDelivery.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(AppDbContext context) : ControllerBase
{
    [HttpPost("registro")]
    public async Task<IActionResult> Registrar([FromBody] Usuario novo)
    {
        var existe = await context.Usuarios.AnyAsync(u => u.Email == novo.Email);
        if (existe)
            return BadRequest("Email já registrado.");

        context.Usuarios.Add(novo);
        await context.SaveChangesAsync();
        return Ok(novo);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest login)
    {
        var usuario = await context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == login.Senha);

        if (usuario is null)
            return Unauthorized("Credenciais inválidas.");

        return Ok(usuario);
    }


}
