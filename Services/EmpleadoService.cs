using AutoMapper;
using lab_app_web_servidor_istea.Database.UnitOfWork;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;
using lab_app_web_servidor_istea.Interfaces;

namespace lab_app_web_servidor_istea.Services;

public class EmpleadoService(IUnitOfWork unitOfWork, IMapper mapper) : IEmpleadoService

{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;

  public async Task<List<EmpleadoResponseDTO>> GetAll()
  {
    try
    {
      var _empleados = await _unitOfWork.EmpleadoRepository.GetAllEmpleados();

      return _mapper.Map<List<EmpleadoResponseDTO>>(_empleados);
    }
    catch
    {
      throw new ApplicationException("An error occurred while retrieving employees.");
    }
  }

  public async Task<EmpleadoResponseDTO> Get(int empleadoId)
  {
    try
    {
      var empleado = await _unitOfWork.EmpleadoRepository.GetEmpleadoById(empleadoId) ?? throw new KeyNotFoundException($"Empleado {empleadoId} no encontrado");

      var _empleadoDTO = new EmpleadoResponseDTO
      {
        Id = empleado.Id,
        Nombre = empleado.Nombre,
        Usuario = empleado.Usuario,
        Sector = empleado.Sector.Descripcion,
        Rol = empleado.Rol.Descripcion
      };

      return _empleadoDTO;
    }
    catch (Exception ex)
    {
      throw new ApplicationException("Se produjo un error al recuperar al empleado", ex);
    }
  }

  public async Task<EmpleadoResponseDTO> Add(EmpleadoRequestDTO emp)
  {
    try
    {
      var empleado = _mapper.Map<Empleado>(emp);
      var existeEmpleado = await _unitOfWork.EmpleadoRepository.GetEmpleadoByUsuario(emp.Usuario);

      if (existeEmpleado != null)
      {
        throw new ApplicationException("El usuario del empleado ya existe");
      }

      empleado = await _unitOfWork.EmpleadoRepository.AddEmpleado(empleado);
      return _mapper.Map<EmpleadoResponseDTO>(empleado);
    }
    catch (Exception ex)
    {
      throw new ApplicationException("Se produjo un error al agregar al empleado", ex);
    }
  }

  public async Task<EmpleadoResponseDTO> Update(int id, EmpleadoUpdateRequestDTO emp)
  {
    Empleado empleado = _mapper.Map<Empleado>(emp);
    empleado.Id = id;
    Empleado empleadoUpdate = await _unitOfWork.EmpleadoRepository.Update(empleado);
    return _mapper.Map<Empleado, EmpleadoResponseDTO>(empleadoUpdate);
  }

  public async Task Delete(int empleadoId)
  {
    await _unitOfWork.EmpleadoRepository.BorrarEmpleado(empleadoId);
  }

  public async Task<HorariosIngresoSistemaDTO> GetHorariosIngresoSistema(int empleadoId, DateTime fechaInicio,
      DateTime fechaFin = new DateTime())
  {
    throw new NotImplementedException();
  }

  public async Task<OperacionesEmpleadoDTO> GetOperacionesPorEmpleado()
  {
    throw new NotImplementedException();
  }

  public async Task<EmpleadoResponseDTO?> GetEmpleadoByUsuarioPass(string user, string pass)
  {
    var empleado = await _unitOfWork.EmpleadoRepository.GetEmpleadoByUsuario(user);
    if (empleado == null)
    {
      return null;
    }
    else if (empleado.Password != pass)
    {
      return null;
    }

    return _mapper.Map<EmpleadoResponseDTO>(empleado); ;
  }

  public async Task RegistrarLogin(int empleadoId)
  {
    await _unitOfWork.EmpleadoRepository.RegistrarLogin(empleadoId);
  }
}
