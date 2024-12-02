using AutoMapper;
using lab_app_web_servidor_istea.Database;
using lab_app_web_servidor_istea.Entities;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab_app_web_servidor_istea.Repositories
{
  public class EmpleadoRepository(RestauranteContext context, IMapper mapper) : Repository<Empleado>(context), IEmpleadoRepository
  {
    private readonly RestauranteContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<Empleado> AddEmpleado(Empleado empleado)
    {
      _context.Empleados.Add(empleado);
      await _context.SaveChangesAsync();
      return empleado;
    }

    public async Task BorrarEmpleado(int empleadoId)
    {
      var empleado = await _context.Empleados.FindAsync(empleadoId) ?? throw new Exception($"Empleado {empleadoId} no encontrado");
      _context.Empleados.Remove(empleado);
      await _context.SaveChangesAsync();
    }


    public async Task<Empleado> Update(Empleado emp)
    {
      var empleado = await _context.Empleados.FindAsync(emp.Id) ?? throw new Exception($"Empleado {emp.Id} no encontrado");

      var sector = await _context.Sectores.FindAsync(emp.IdSector) ?? throw new Exception($"Sector {emp.IdSector} no encontrado");

      var rol = await _context.Roles.FindAsync(emp.RolId) ?? throw new Exception($"Rol {emp.RolId} no encontrado");

      empleado.Nombre = emp.Nombre;
      empleado.IdSector = emp.IdSector;
      empleado.RolId = emp.RolId;

      // Guardar los cambios en la base de datos
      await _context.SaveChangesAsync();

      return empleado;
    }


    public Task<List<Empleado>> GetAllEmpleados()
    {
      return _context.Empleados
          .Include(e => e.Sector)
          .Include(e => e.Rol)
          .ToListAsync();
    }

    public Task<Empleado?> GetEmpleadoById(int id)
    {
      return _context.Empleados
          .Include(e => e.Sector)
          .Include(e => e.Rol)
          .Where(e => e.Id == id)
          .FirstOrDefaultAsync();
    }

    public Task<Empleado?> GetEmpleadoByUsuario(string usuario)
    {
      return _context.Empleados
          .Include(e => e.Sector)
          .Include(e => e.Rol)
          .Where(e => e.Usuario == usuario)
          .FirstOrDefaultAsync();
    }

    public async Task RegistrarLogin(int empleadoId)
    {
      var registroEmpleado = new RegistroEmpleado();
      registroEmpleado.IdEmpleado = empleadoId;
      registroEmpleado.FechaHora = DateTime.Now;

      _context.RegistroEmpleado.Add(registroEmpleado);
      await _context.SaveChangesAsync();
    }
  }
}
