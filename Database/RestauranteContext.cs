using lab_app_web_servidor_istea.Database.DataSeed;
using Microsoft.EntityFrameworkCore;
using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Database;

public class RestauranteContext : DbContext
{
  public RestauranteContext()
  {
  }

  public RestauranteContext(DbContextOptions<RestauranteContext> options)
      : base(options)
  {
  }

  public DbSet<EstadosPedido> EstadosPedidos { get; set; }
  public DbSet<EstadosMesa> EstadosMesas { get; set; }
  public DbSet<Comanda> Comandas { get; set; }
  public DbSet<Empleado> Empleados { get; set; }
  public DbSet<Mesa> Mesas { get; set; }
  public DbSet<Pedido> Pedidos { get; set; }
  public DbSet<Producto> Productos { get; set; }
  public DbSet<Rol> Roles { get; set; }
  public DbSet<Sector> Sectores { get; set; }
  public DbSet<RegistroEmpleado> RegistroEmpleado { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new EstadosMesaSeed());
    modelBuilder.ApplyConfiguration(new EstadosPedidosSeed());
    modelBuilder.ApplyConfiguration(new SectoresSeed());
    modelBuilder.ApplyConfiguration(new MesaSeed());
    modelBuilder.ApplyConfiguration(new ProductosSeed());
    modelBuilder.ApplyConfiguration(new RolesSeed());
    modelBuilder.ApplyConfiguration(new EmpleadoSeed());
  }
}