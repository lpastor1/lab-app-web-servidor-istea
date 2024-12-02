using lab_app_web_servidor_istea.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab_app_web_servidor_istea.Database.UnitOfWork
{
  public class UnitOfWork(RestauranteContext context, IComandaRepository comandaRepository,
      IEmpleadoRepository empleadoRepository, IPedidoRepository pedidoRepository,
      ISectorRepository sectorRepository, IMesaRepository mesaRepository) : IUnitOfWork
  {
    public IComandaRepository ComandaRepository { get; } = comandaRepository;

    public IEmpleadoRepository EmpleadoRepository { get; } = empleadoRepository;

    public IPedidoRepository PedidoRepository { get; } = pedidoRepository;

    public ISectorRepository SectorRepository { get; } = sectorRepository;

    public IMesaRepository MesaRepository { get; } = mesaRepository;

    private readonly RestauranteContext _context = context;

    public void Dispose()
    {
      _context?.Dispose();
    }

    public async Task<int> Save()
    {
      return await _context.SaveChangesAsync();
    }
  }
}
