using Microsoft.EntityFrameworkCore;
using BackendDelivery.Models;

namespace BackendDelivery.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Cartao> Cartoes => Set<Cartao>();
    public DbSet<Carrinho> Carrinhos => Set<Carrinho>();
    
}
