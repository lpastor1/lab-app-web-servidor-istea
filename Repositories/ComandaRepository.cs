using lab_app_web_servidor_istea.Database;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab_app_web_servidor_istea.Repositories
{
  public class ComandaRepository(RestauranteContext context) : Repository<Comanda>(context), IComandaRepository
  {
    public async Task<Comanda> ObtenerComandaPorId(int idComanda)
    {
      var comandaDto = await _context.Comandas
          .Include(c => c.Pedidos)
              .ThenInclude(z => z.EstadosPedido)
          .Include(c => c.Pedidos)
              .ThenInclude(p => p.Producto)
              .ThenInclude(x => x.Sector)
          .Include(c => c.Mesa)
          .FirstOrDefaultAsync(c => c.Id == idComanda);

      if (comandaDto == null)
      {
        throw new KeyNotFoundException($"Comanda {idComanda} no encontrada");
      }

      return comandaDto;
    }

    public async Task<Comanda> AgregarComanda(ComandaDTO comanda)
    {
      Comanda nuevaComanda = new()
      {
        NombreCliente = comanda.NombreCliente,
        MesaId = comanda.IdMesa,
      };

      _context.Add(nuevaComanda);

      await _context.SaveChangesAsync();

      await _context.Entry(nuevaComanda)
          .Reference(c => c.Mesa)
          .LoadAsync();

      await _context.Entry(nuevaComanda)
          .Collection(c => c.Pedidos)
          .LoadAsync();

      return nuevaComanda;
    }

    public async Task<Comanda> ActualizarComanda(Comanda comanda)
    {
      var comandaExistente = await _context.Comandas.FindAsync(comanda.Id) ?? throw new KeyNotFoundException($"Comanda {comanda.Id} no encontrada");

      comandaExistente.NombreCliente = comanda.NombreCliente;
      comandaExistente.MesaId = comanda.MesaId;

      await _context.SaveChangesAsync();

      await _context.Entry(comandaExistente)
          .Reference(c => c.Mesa)
          .LoadAsync();

      await _context.Entry(comandaExistente)
          .Collection(c => c.Pedidos)
          .LoadAsync();

      return comandaExistente;
    }
  }
}
