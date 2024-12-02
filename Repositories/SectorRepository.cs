using lab_app_web_servidor_istea.Database;
using lab_app_web_servidor_istea.Entities;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab_app_web_servidor_istea.Repositories
{
  public class SectorRepository(RestauranteContext context) : Repository<Sector>(context), ISectorRepository
  {
    async Task<Sector> ISectorRepository.GetSectorByDescription(string description)
    {
      try
      {
        var newSector = await _context.Sectores
            .FirstOrDefaultAsync(s => s.Descripcion == description);

        return newSector;
      }
      catch (Exception exception)
      {
        return null;
      }
    }

    async Task<List<OperacionesSector>> ISectorRepository.GetOperacionesPorSector(string description)
    {
      try
      {
        var resultado = await _context.Pedidos
         .Join(_context.Productos, pe => pe.ProductoId, pr => pr.Id, (pe, pr) => new { Pedido = pe, Producto = pr })
         .Join(_context.Sectores, combined => combined.Producto.SectorId, s => s.Id, (combined, sector) => new { combined.Pedido, combined.Producto, Sector = sector })
         .Join(_context.Empleados, combined => combined.Producto.SectorId, e => e.IdSector, (combined, empleado) => new { combined.Pedido, combined.Producto, combined.Sector, Empleado = empleado })
         .Join(_context.EstadosPedidos, combined => combined.Pedido.EstadosPedidoId, ep => ep.Id, (combined, estadoPedido) => new { combined.Pedido, combined.Producto, combined.Sector, combined.Empleado, EstadoPedido = estadoPedido })
         .GroupBy(g => g.Sector.Descripcion)
         .Select(group => new OperacionesSector
         {
           NombreSector = group.Key,
           CantidadPedidos = group.Count()
         })
         .ToListAsync();

        return resultado;
      }
      catch (Exception exception)
      {
        return null;
      }
    }

    async Task<List<OperacionesEmpleado>> ISectorRepository.GetOperacionesPorSectorPorEmpleado(string descriptionSector)
    {
      try
      {
        var resultado = await _context.Pedidos
            .Where(pe => pe.Producto.Sector.Descripcion.Contains(descriptionSector))
            .Join(_context.Productos, pe => pe.ProductoId, pr => pr.Id, (pe, pr) => new { Pedido = pe, Producto = pr })
            .Join(_context.Empleados, combined => combined.Producto.SectorId, e => e.IdSector, (combined, empleado) => new { combined.Pedido, Empleado = empleado })
            .Join(_context.EstadosPedidos, combined => combined.Pedido.EstadosPedidoId, ep => ep.Id, (combined, estadoPedido) => new { combined.Pedido, combined.Empleado, EstadoPedido = estadoPedido })
            .GroupBy(g => g.Empleado.Nombre)
            .Select(group => new OperacionesEmpleado
            {
              NombreEmpleado = group.Key,
              CantidadPedidos = group.Count()
            })
            .ToListAsync();

        return resultado;
      }
      catch (Exception exception)
      {
        return null;
      }
    }

    async Task<List<OperacionesSectorEmpleado>> ISectorRepository.GetOperacionesPorSectorPorEmpleado()
    {
      try
      {
        var resultado = await _context.Pedidos
            .Join(_context.Productos, pe => pe.ProductoId, pr => pr.Id, (pe, pr) => new { Pedido = pe, Producto = pr })
            .Join(_context.Sectores, combined => combined.Producto.SectorId, s => s.Id, (combined, sector) => new { combined.Pedido, combined.Producto, Sector = sector })
            .Join(_context.Empleados, combined => combined.Producto.SectorId, e => e.IdSector, (combined, empleado) => new { combined.Pedido, combined.Producto, combined.Sector, Empleado = empleado })
            .Join(_context.EstadosPedidos, combined => combined.Pedido.EstadosPedidoId, ep => ep.Id, (combined, estadoPedido) => new { combined.Pedido, combined.Producto, combined.Sector, combined.Empleado, EstadoPedido = estadoPedido })
            .GroupBy(g => new { g.Sector.Descripcion, g.Empleado.Nombre })
            .Select(group => new OperacionesSectorEmpleado
            {
              SectorDescripcion = group.Key.Descripcion,
              NombreEmpleado = group.Key.Nombre,
              CantidadPedidos = group.Count()
            })
            .ToListAsync();

        return resultado;
      }
      catch (Exception exception)
      {
        return null;
      }
    }

  }
}