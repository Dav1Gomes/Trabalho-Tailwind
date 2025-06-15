using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendDelivery.Data;
using BackendDelivery.Models;

namespace BackendDelivery.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestauranteController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Restaurante>>> Listar()
    {
        return await context.Restaurantes
            .Include(r => r.Alimentos)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurante>> BuscarPorId(int id)
    {
        var restaurante = await context.Restaurantes
            .Include(r => r.Alimentos)
            .FirstOrDefaultAsync(r => r.Id == id);

        return restaurante is null ? NotFound() : Ok(restaurante);
    }
}
