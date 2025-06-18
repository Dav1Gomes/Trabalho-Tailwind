using BackendDelivery.Data;
using BackendDelivery.DTOs;
using BackendDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDelivery.DTOs;

namespace BackendDelivery.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly AppDbContext _context;

    public CarrinhoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("comprar")]
        public async Task<IActionResult> Comprar([FromBody] CompraRequestDTO compra)
        {
            var usuario = await _context.Usuarios.FindAsync(compra.UsuarioId);
            var alimento = await _context.Alimentos.FindAsync(compra.AlimentoId);

            if (usuario is null || alimento is null)
                return NotFound("Usuário ou alimento não encontrado.");

            var itemExistente = await _context.Carrinhos
                .FirstOrDefaultAsync(c =>
                    c.UsuarioId   == compra.UsuarioId &&
                    c.AlimentoId  == compra.AlimentoId);

            if (itemExistente != null)
            {
                itemExistente.Quantidade += compra.Quantidade;
                itemExistente.Total      = itemExistente.Quantidade * alimento.Preco;
                _context.Carrinhos.Update(itemExistente);
            }
            else
            {
                var novoItem = new Carrinho
                {
                    UsuarioId  = compra.UsuarioId,
                    AlimentoId = compra.AlimentoId,
                    Quantidade = compra.Quantidade,
                    Total      = compra.Quantidade * alimento.Preco
                };
                _context.Carrinhos.Add(novoItem);
                itemExistente = novoItem; 
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                QuantidadeConsolidada = itemExistente.Quantidade,
                TotalProItem          = itemExistente.Total
            });
        }

    [HttpGet("historico/{usuarioId}")]
    public async Task<ActionResult<List<CarrinhoHistorico>>> Historico(int usuarioId)
    {
        var historico = await _context.HistoricoCompras
            .Include(c => c.Alimento)
            .Where(c => c.UsuarioId == usuarioId)
            .OrderByDescending(c => c.DataCompra)
            .ToListAsync();

        return Ok(historico);
    }



    [HttpGet("{usuarioId}")]
    public async Task<ActionResult<List<CarrinhoDto>>> ListarCarrinho(int usuarioId)
    {
        var itens = await _context.Carrinhos
            .Include(c => c.Alimento)
            .Where(c => c.UsuarioId == usuarioId)
            .Select(c => new CarrinhoDto
            {
                Id = c.Id,
                AlimentoId = c.AlimentoId,
                Nome = c.Alimento.Nome,
                PrecoUnitario = c.Alimento.Preco,
                Quantidade = c.Quantidade
            }).ToListAsync();

        return Ok(itens);
    }

    [HttpDelete("{carrinhoId}")]
    public async Task<IActionResult> RemoverItem(int carrinhoId)
    {
        var item = await _context.Carrinhos.FindAsync(carrinhoId);
        if (item == null) return NotFound();

        _context.Carrinhos.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("{usuarioId}/comprar")]
    public async Task<ActionResult<decimal>> FinalizarCompra(int usuarioId)
    {
        var usuario = await _context.Usuarios.FindAsync(usuarioId);
        if (usuario == null) return NotFound();

        var itens = await _context.Carrinhos
            .Include(c => c.Alimento)
            .Where(c => c.UsuarioId == usuarioId)
            .ToListAsync();

        if (!itens.Any()) return BadRequest("Carrinho vazio.");

        var total = itens.Sum(i => i.Quantidade * i.Alimento.Preco);

        if (usuario.Saldo < total)
            return BadRequest("Saldo insuficiente.");

        usuario.Saldo -= total;

        var historico = itens.Select(i => new CarrinhoHistorico
        {
            UsuarioId = usuarioId,
            AlimentoId = i.AlimentoId,
            Quantidade = i.Quantidade,
            Total = i.Total,
            DataCompra = DateTime.Now
        }).ToList();

        _context.HistoricoCompras.AddRange(historico);

        _context.Carrinhos.RemoveRange(itens);
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();

        return Ok(usuario.Saldo);
    }


    [HttpPost("adicionar")]
    public async Task<IActionResult> AdicionarAoCarrinho([FromBody] CompraRequestDTO dto)
    {
        var alimento = await _context.Alimentos.FindAsync(dto.AlimentoId);
        if (alimento is null) return NotFound("Alimento não encontrado.");

        var itemExistente = await _context.Carrinhos
            .FirstOrDefaultAsync(c => c.UsuarioId == dto.UsuarioId && c.AlimentoId == dto.AlimentoId);

        if (itemExistente != null)
        {
            itemExistente.Quantidade += dto.Quantidade;
            itemExistente.Total = itemExistente.Quantidade * alimento.Preco;
        }
        else
        {
            var novoItem = new Carrinho
            {
                UsuarioId = dto.UsuarioId,
                AlimentoId = dto.AlimentoId,
                Quantidade = dto.Quantidade,
                Total = dto.Quantidade * alimento.Preco
            };
            _context.Carrinhos.Add(novoItem);
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

}
