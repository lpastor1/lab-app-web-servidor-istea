using lab_app_web_servidor_istea.DTO;

namespace lab_app_web_servidor_istea.Interfaces;
public interface IMesaService
{
  Task<List<MesaResponseDTO>> GetMesas();
  Task CerrarMesa(string nombreMesa);
  Task CambiarEstado(string nombreMesa, int idEstado);
}
