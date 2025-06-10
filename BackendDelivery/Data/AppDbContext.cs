using Microsoft.EntityFrameworkCore;
using BackendDelivery.Models;

namespace BackendDelivery.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();
}
