using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Interfaces
{
  public interface IEmpleadoRepository : IRepository<Empleado>
  {
    Task<List<Empleado>> GetAllEmpleados();
    Task<Empleado?> GetEmpleadoById(int id);
    Task<Empleado> Update(Empleado emp);
    Task<Empleado> AddEmpleado(Empleado empleado);
    Task BorrarEmpleado(int empleadoId);
    Task<Empleado> GetEmpleadoByUsuario(string usuario);
    Task RegistrarLogin(int empleadoId);
  }
}
