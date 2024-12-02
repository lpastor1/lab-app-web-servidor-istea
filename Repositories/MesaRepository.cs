using lab_app_web_servidor_istea.Database;
using lab_app_web_servidor_istea.Entities;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lab_app_web_servidor_istea.Repositories;
public class MesaRepository(RestauranteContext context) : Repository<Mesa>(context), IMesaRepository
{
  public async Task<List<Mesa>> GetMesas()
  {
    var mesas = await _context.Mesas
        .Include(m => m.EstadosMesa)
        .ToListAsync();
    return mesas;
  }
  public async Task CerrarMesa(string nombreMesa)
  {
    var mesa = await _context.Mesas.FirstOrDefaultAsync(m => m.Nombre == nombreMesa);

    if (mesa != null)
    {
      var estadoCerrada = await _context.EstadosMesas.FirstOrDefaultAsync(e => e.Descripcion == "Cerrada");
      if (estadoCerrada != null)
      {
        mesa.EstadosMesaId = estadoCerrada.Id;
        await _context.SaveChangesAsync();
      }
    }
  }

  public async Task CambiarEstado(string nombreMesa, int idEstado)
  {
    try
    {
      var mesa = await _context.Mesas.FirstOrDefaultAsync(m => m.Nombre == nombreMesa);
      if (mesa != null)
      {
        mesa.EstadosMesaId = idEstado;
        await _context.SaveChangesAsync();
      }
    }
    catch (Exception ex)
    {
      throw new ApplicationException($"No se pudo actualizar la mesa {nombreMesa}", ex);
    }
  }
}
