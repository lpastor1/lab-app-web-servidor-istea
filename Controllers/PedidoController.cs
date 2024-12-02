using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Enums;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace lab_app_web_servidor_istea.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
  private readonly IPedidoService _pedidoService;

  public PedidoController(IPedidoService pedidoService)
  {
    _pedidoService = pedidoService;
  }

  [Authorize(Roles = RolTrabajador.Socio)]
  [HttpGet("GetPedidos")]
  public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidos()
  {
    var pedidos = await _pedidoService.GetPedidos();
    if (pedidos == null) return Ok(new List<PedidoResponseDTO>());
    return Ok(pedidos);

  }

  [Authorize(Roles = RolTrabajador.Cocinero + "," + RolTrabajador.Cervecero + "," + RolTrabajador.Bartender)]
  [HttpGet("GetPedidosPendientes")]
  public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidosPendientes()
  {
    var userRol = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

    var pedidos = await _pedidoService.GetPedidosPorRol(userRol);
    if (pedidos == null) return NotFound();
    var pedidosPendientes = pedidos?.Where(p => p.EstadosPedido != "Listo para servir").ToList();
    return Ok(pedidosPendientes);
  }

  [Authorize(Roles = RolTrabajador.Mozo)]
  [HttpGet("GetPedidosListos")]
  public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidosListos()
  {
    var pedidos = await _pedidoService.GetPedidosListos();
    if (pedidos == null) return NotFound();
    return Ok(pedidos);
  }

  [Authorize(Roles = RolTrabajador.Socio)]
  [HttpGet("GetPedidos/{sector}")]
  public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidosPorSector(string sector)
  {
    var pedidos = await _pedidoService.GetPedidosPorSector(sector);
    if (pedidos == null) return NotFound();
    return Ok(pedidos);
  }

  [HttpGet("GetPedidosRetrasados")]
  public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidosNoEntregadosATiempo()
  {
    var pedidos = await _pedidoService.GetPedidosNoEntregadosATiempo();
    if (pedidos == null) return NotFound();
    return Ok(pedidos);
  }

  [HttpGet("GetPedidoPorId/{id}")]
  public async Task<ActionResult<PedidoResponseDTO>> GetPedidoPorId(int id)
  {
    var pedido = await _pedidoService.GetPedidoPorId(id);
    if (pedido == null) return NotFound();
    return Ok(pedido);
  }

  [Authorize(Roles = RolTrabajador.Cocinero + "," + RolTrabajador.Cervecero + "," + RolTrabajador.Bartender)]
  [HttpPut("CambiarEstadoPedidoEnPreparacion/{pedidoId}")]
  public async Task<ActionResult<PedidoResponseDTO>> CambiarEstadoPedidoEnPreparacion([FromRoute] int pedidoId)
  {
    try
    {
      var userRol = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

      var sectorDescription = _pedidoService.ObtenerSectorPorRol(userRol);

      var pedido = await _pedidoService.CambiarEstadoPedido(pedidoId, sectorDescription, (int)EstadoPedido.EnPreparacion);
      if (pedido == null) return NotFound("Pedido no encontrado.");

      return Ok(pedido);
    }
    catch (KeyNotFoundException ex)
    {
      return NotFound(ex.Message);
    }
    catch (UnauthorizedAccessException ex) // Manejar la excepci�n de acceso no autorizado
    {
      return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, "Ocurri� un error al procesar la solicitud.");
    }
  }

  [Authorize(Roles = RolTrabajador.Cocinero + "," + RolTrabajador.Cervecero + "," + RolTrabajador.Bartender)]
  [HttpPut("CambiarEstadoPedidoListoParaServir/{pedidoId}")]
  public async Task<ActionResult<PedidoResponseDTO>> CambiarEstadoPedidoListoParaServir([FromRoute] int pedidoId)
  {
    try
    {
      var userRol = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
      var sectorDescription = _pedidoService.ObtenerSectorPorRol(userRol);

      var pedido = await _pedidoService.CambiarEstadoPedido(pedidoId, sectorDescription, (int)EstadoPedido.ListoParaServir);
      if (pedido == null) return NotFound("Pedido no encontrado.");

      return Ok(pedido);
    }
    catch (KeyNotFoundException ex)
    {
      return NotFound(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, "Ocurri� un error al procesar la solicitud.");
    }
  }

  [Authorize(Roles = RolTrabajador.Mozo)]
  [HttpPost("AddPedido")]
  public async Task<ActionResult> AddPedido([FromBody] PedidoPostDTO pedido)
  {
    var ped = await _pedidoService.AddPedido(pedido);
    return Created(string.Empty, string.Empty);
  }

  [HttpGet("GetMenosPedido")]
  public async Task<ActionResult<PedidoResponseDTO>> GetMenosPedido()
  {
    var pedidos = await _pedidoService.GetMenosPedido();
    return Ok(pedidos);
  }

  [HttpGet("GetMasPedido")]
  public async Task<ActionResult<PedidoResponseDTO>> GetMasPedido()
  {
    var pedidos = await _pedidoService.GetMasPedido();
    return Ok(pedidos);
  }
}
