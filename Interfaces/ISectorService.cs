using lab_app_web_servidor_istea.DTO;

namespace lab_app_web_servidor_istea.Interfaces;

public interface ISectorService
{
  Task<List<OperacionesSectorDTO>> GetOperacionesPorSector(string sectorDescripcion);

  Task<List<OperacionesSectorEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado();
  Task<List<OperacionesEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado(string sectorDescripcion);
}
