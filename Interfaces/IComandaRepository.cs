using lab_app_web_servidor_istea.Entities;
using lab_app_web_servidor_istea.DTO;

namespace lab_app_web_servidor_istea.Interfaces
{
  public interface IComandaRepository : IRepository<Comanda>
  {
    public Task<Comanda> ObtenerComandaPorId(int idComanda);
    public Task<Comanda> AgregarComanda(ComandaDTO comanda);
    public Task<Comanda> ActualizarComanda(Comanda comanda);
  }

}
