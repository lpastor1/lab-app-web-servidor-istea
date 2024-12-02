using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Interfaces
{
  public interface IMesaRepository
  {
    Task<List<Mesa>> GetMesas();
    Task CerrarMesa(string nombreMesa);
    Task CambiarEstado(string nombreMesa, int idEstado);
  }
}
