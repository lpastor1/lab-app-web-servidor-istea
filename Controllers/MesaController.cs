using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Enums;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace lab_app_web_servidor_istea.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MesaController(IMesaService mesaService) : ControllerBase
  {
    private readonly IMesaService _mesaService = mesaService;

    [Authorize(Roles = RolTrabajador.Socio + "," + RolTrabajador.Mozo)]
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<MesaResponseDTO>>> GetMesas()
    {
      var mesas = await _mesaService.GetMesas();
      return Ok(mesas);
    }

    [Authorize(Roles = RolTrabajador.Socio)]
    [HttpPut("CerrarMesa")]
    public ActionResult CerrarMesa(string nombreMesa)
    {
      _mesaService.CerrarMesa(nombreMesa);
      return Ok("Mesa cerrada correctamente");
    }

    [Authorize(Roles = RolTrabajador.Socio + "," + RolTrabajador.Mozo)]
    [HttpPut("AbrirMesa")]
    public ActionResult AbrirMesa(string nombreMesa)
    {
      _mesaService.CambiarEstado(nombreMesa, (int)EstadoMesa.ClienteEsperandoPedido);
      return Ok("Mesa abierta correctamente, cliente esperando su pedido");
    }

    [Authorize(Roles = RolTrabajador.Mozo)]
    [HttpPut("CambiarEstadoClienteComiendo")]
    public ActionResult CambiarEstadoClienteComiendo(string nombreMesa)
    {

      _mesaService.CambiarEstado(nombreMesa, (int)EstadoMesa.ClienteComiendo);
      return Ok("Estado de mesa cambiado correctamente, cliente comiendo");
    }

    [Authorize(Roles = RolTrabajador.Mozo)]
    [HttpPut("CambiarEstadoClientePagando")]
    public ActionResult CambiarEstadoClientePagando(string nombreMesa)
    {
      _mesaService.CambiarEstado(nombreMesa, (int)EstadoMesa.ClientePagando);
      return Ok("Estado de mesa cambiado correctamente, cliente pagando");
    }
  }
}
