using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Enums;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_app_web_servidor_istea.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComandaController : ControllerBase
{
  private readonly IComandaService _comandaService;

  public ComandaController(IComandaService comandaService)
  {
    _comandaService = comandaService;
  }

  [HttpGet("Buscar/{idComanda}")]
  public async Task<ActionResult<ComandaResponseDTO>> Get([FromRoute] int idComanda)
  {
    try
    {
      var comanda = await _comandaService.ObtenerComandaPorId(idComanda);

      return Ok(comanda);
    }
    catch (Exception ex)
    {
      return NotFound(new { Message = ex.Message });
    }
  }

  [Authorize(Roles = RolTrabajador.Mozo)]
  [HttpPost("Agregar")]
  public async Task<ActionResult<ComandaResponseDTO>> Add([FromBody] ComandaDTO comanda)
  {
    var comandaCreada = await _comandaService.Add(comanda);

    return Created(String.Empty, comandaCreada);
  }

  [Authorize(Roles = RolTrabajador.Mozo)]
  [HttpPut("ActualizarComanda/{idComanda}")]
  public async Task<ActionResult<ComandaResponseDTO>> Update([FromRoute] int idComanda, [FromBody] ComandaDTO comandaDTO)
  {
    if (comandaDTO == null)
    {
      return BadRequest("La comanda no puede ser nula");
    }

    try
    {
      // Llamar al servicio para actualizar la comanda
      var comandaActualizada = await _comandaService.Update(idComanda, comandaDTO);

      if (comandaActualizada == null)
      {
        return NotFound($"Comanda {idComanda} no encontrada");
      }

      return Ok(comandaActualizada);
    }
    catch (Exception ex)
    {
      return StatusCode(500, "Internal server error: " + ex.Message);
    }
  }

  //socio
  [Authorize(Roles = RolTrabajador.Socio + "," + RolTrabajador.Mozo)]
  [HttpDelete("BorrarComanda/{idComanda}")]
  public async Task<ActionResult> Delete([FromRoute] int idComanda)
  {
    bool success = await _comandaService.Delete(idComanda);

    if (success)
    {
      return NoContent();
    }

    return NotFound();
  }
}
