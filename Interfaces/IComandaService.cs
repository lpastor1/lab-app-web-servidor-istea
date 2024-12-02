using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Interfaces
{
  public interface IComandaService
  {
    Task<Comanda> Get(int idComanda);
    Task<ComandaResponseDTO> Add(ComandaDTO comanda);
    Task<ComandaResponseDTO> Update(int idComanda, ComandaDTO comanda);
    Task<bool> Delete(int idComanda);
    Task<ComandaResponseDTO> ObtenerComandaPorId(int idComanda);
  }
}
