using System.Security.Principal;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Enums;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_app_web_servidor_istea.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmpleadoController(IEmpleadoService empleadoService) : ControllerBase
  {
    private readonly IEmpleadoService _empleadoService = empleadoService;

    [Authorize(Roles = RolTrabajador.Socio)]
    [HttpGet("GetEmpleados")]
    public async Task<ActionResult<List<EmpleadoResponseDTO>>> GetAll()
    {
      var emp = await _empleadoService.GetAll();
      if (emp.Count == 0) return NotFound();
      return Ok(emp);
    }

    [HttpGet("GetEmpleadoPorId/{id}")]
    public async Task<ActionResult<EmpleadoResponseDTO>> Get(int id)
    {
      var emp = await _empleadoService.Get(id);
      if (emp == null) return NotFound();
      return Ok(emp);
    }

    [Authorize(Roles = RolTrabajador.Socio)]
    [HttpPost("AgregarEmpleado")]
    public async Task<ActionResult<EmpleadoResponseDTO>> Add(EmpleadoRequestDTO empleado)
    {
      return await _empleadoService.Add(empleado);
    }

    [HttpPut("EditarEmpleado/{id}")]
    public async Task<ActionResult<EmpleadoResponseDTO>> Update([FromRoute] int id, EmpleadoUpdateRequestDTO empleado)
    {
      var emp = await _empleadoService.Update(id, empleado);
      if (emp != null)
      {
        return Created(string.Empty, emp);
      }

      return NotFound();
    }

    [HttpDelete("EliminarEmpleado/{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
      try
      {
        await _empleadoService.Delete(id);
        return NoContent();
      }
      catch (Exception ex)
      {
        return NotFound(ex.Message);
      }
    }

    [HttpGet("ObtenerIngresosDeEmpleado/{id}")]
    public async Task<ActionResult<HorariosIngresoSistemaDTO>> GetHorariosIngresoSistema(
        [FromRoute] int empleadoId,
        DateTime fechaInicio,
        [FromBody] DateTime fechaFin = new())
    {
      var horarios = await _empleadoService.GetHorariosIngresoSistema(empleadoId, fechaInicio, fechaFin);
      if (horarios == null) return NotFound();
      return Ok(horarios);
    }

    [HttpGet("GetOperacionesPorEmpleado")]
    public async Task<ActionResult<OperacionesEmpleadoDTO>> GetOperacionesPorEmpleado()
    {
      var operaciones = await _empleadoService.GetOperacionesPorEmpleado();
      if (operaciones == null) return NotFound();
      return Ok(operaciones);
    }
  }
}