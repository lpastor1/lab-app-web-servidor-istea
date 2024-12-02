using lab_app_web_servidor_istea.DTO;

namespace lab_app_web_servidor_istea.Interfaces
{
  public interface IEmpleadoService
  {
    Task<List<EmpleadoResponseDTO>> GetAll();
    Task<EmpleadoResponseDTO> Get(int empleadoId);
    Task<EmpleadoResponseDTO> Add(EmpleadoRequestDTO empleado);
    Task<EmpleadoResponseDTO> Update(int id, EmpleadoUpdateRequestDTO empleado);
    Task Delete(int empleadoId);

    Task<HorariosIngresoSistemaDTO> GetHorariosIngresoSistema(int empleadoId, DateTime fechaInicio,
        DateTime fechaFin = new DateTime());

    Task<OperacionesEmpleadoDTO> GetOperacionesPorEmpleado();
    Task<EmpleadoResponseDTO?> GetEmpleadoByUsuarioPass(string user, string pass);

    Task RegistrarLogin(int empleadoId);
  }
}
