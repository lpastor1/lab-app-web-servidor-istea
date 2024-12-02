using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab_app_web_servidor_istea.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectorController : ControllerBase
{
  private readonly ISectorService _sectorService;

  public SectorController(ISectorService sectorService)
  {
    _sectorService = sectorService;
  }

  [HttpGet("GetOperacionesPorSector/{sectorDescripcion}")]
  public async Task<ActionResult<OperacionesSectorDTO>> GetOperacionesPorSector(string sectorDescripcion)
  {
    try
    {
      // Llama al servicio para obtener las operaciones por sector, pasando la descripci�n del sector
      var result = await _sectorService.GetOperacionesPorSector(sectorDescripcion);

      if (result == null)
      {
        return NotFound($"No se encontraron operaciones para el sector: {sectorDescripcion}");
      }

      return Ok(result);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor: {ex.Message}");
    }
  }


  [HttpGet("GetOperacionesPorSectorPorEmpleado/{sectorDescripcion}")]
  public async Task<ActionResult<OperacionesSectorEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado(string sectorDescripcion)
  {
    try
    {
      // Llama al servicio para obtener las operaciones por sector por empleado
      var result = await _sectorService.GetOperacionesPorSectorPorEmpleado(sectorDescripcion);

      if (result == null)
      {
        return NotFound($"No se encontraron empleados para el sector: {sectorDescripcion}");
      }

      return Ok(result);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor: {ex.Message}");
    }
  }

}
