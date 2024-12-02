using AutoMapper;
using lab_app_web_servidor_istea.Database.UnitOfWork;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;
using lab_app_web_servidor_istea.Enums;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab_app_web_servidor_istea.Services;

public class PedidoService : IPedidoService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public PedidoService(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<PedidoResponseDTO>> GetPedidos()
  {
    var pedidosEntity = await _unitOfWork.PedidoRepository.GetAllPedidos();
    List<PedidoResponseDTO> pedidosDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidosEntity);
    return pedidosDTO;
  }

  public string ObtenerSectorPorRol(string userRole)
  {
    return userRole switch
    {
      RolTrabajador.Bartender => "Barra de tragos y vinos",
      RolTrabajador.Cervecero => "Barra de choperas de cerveza artesanal",
      RolTrabajador.Cocinero => "Cocina",
      RolTrabajador.Mozo => "",
      RolTrabajador.Socio => "",
      _ => throw new NotImplementedException(),
    };
  }

  public async Task<List<PedidoResponseDTO>> GetPedidosListos()
  {
    var pedidosEntity = await _unitOfWork.PedidoRepository.GetPedidosListos();
    List<PedidoResponseDTO> pedidosDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidosEntity);
    return pedidosDTO;
  }

  public async Task<List<PedidoResponseDTO>> GetPedidosPorSector(string sector)
  {
    try
    {
      var newSector = await _unitOfWork.SectorRepository.GetSectorByDescription(sector);

      if (newSector == null)
      {
        return new List<PedidoResponseDTO>();
      }

      var pedidos = await _unitOfWork.PedidoRepository.GetPedidosBySector(newSector);

      var pedidosDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

      return pedidosDTO;
    }
    catch (Exception ex)
    {
      throw new ApplicationException("Se produjo un error al recuperar pedidos por sector", ex);
    }
  }

  public async Task<List<PedidoResponseDTO>> GetPedidosPorRol(string rol)
  {
    try
    {
      var sector = ObtenerSectorPorRol(rol);

      var newSector = await _unitOfWork.SectorRepository.GetSectorByDescription(sector);

      if (newSector == null)
      {
        return [];
      }

      var pedidos = await _unitOfWork.PedidoRepository.GetPedidosBySector(newSector);

      var pedidosDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

      return pedidosDTO;
    }
    catch (Exception ex)
    {
      throw new ApplicationException("Se produjo un error al recuperar pedidos por sector", ex);
    }
  }

  public async Task<List<PedidoResponseDTO>> GetPedidosNoEntregadosATiempo()
  {
    try
    {
      var pedidos = await _unitOfWork.PedidoRepository.GetPedidoByEstado((int)EstadoPedido.ListoParaServir);
      var pedidosResponseDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

      return pedidosResponseDTO;
    }
    catch
    {
      throw new ApplicationException("Se produjo un error al recuperar pedidos");
    }
  }


  public async Task<List<PedidoResponseDTO>> GetMenosPedido()
  {
    try
    {
      var pedidos = await _unitOfWork.PedidoRepository.GetMenosPedido();

      var pedidosResponseDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

      return pedidosResponseDTO;
    }
    catch (Exception ex)
    {
      throw new ApplicationException($"Se produjo un error al recuperar los productos menos pedidos: {ex.Message}");
    }
  }

  public async Task<List<PedidoResponseDTO>> GetMasPedido()
  {
    try
    {
      var pedidos = await _unitOfWork.PedidoRepository.GetMasPedido();

      var pedidosResponseDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

      return pedidosResponseDTO;
    }
    catch (Exception ex)
    {
      throw new ApplicationException($"Se produjo un error al recuperar los productos más pedidos: {ex.Message}");
    }
  }

  public async Task<PedidoResponseDTO> GetPedidoPorId(int id)
  {
    try
    {
      var pedido = await _unitOfWork.PedidoRepository.GetId(id) ?? throw new KeyNotFoundException($"Pedido {id} no encontrado");

      var pedidoResponseDTO = _mapper.Map<PedidoResponseDTO>(pedido);

      return pedidoResponseDTO;
    }
    catch (Exception ex)
    {
      throw new ApplicationException($"Se produjo un error al recuperar el pedido: {ex.Message}");
    }
  }


  public async Task<PedidoResponseDTO> CambiarEstadoPedido(int id, string sector, int estado)
  {
    var pedido = await _unitOfWork.PedidoRepository.CambiarEstadoPedido(id, sector, estado);

    var pedidoDto = _mapper.Map<PedidoResponseDTO>(pedido);

    return pedidoDto;
  }


  public async Task<Pedido> AddPedido(PedidoPostDTO pedidoDTO)
  {
    Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
    return await _unitOfWork.PedidoRepository.AddPedido(pedido);
  }
}
