using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Interfaces
{
  public interface IPedidoRepository : IRepository<Pedido>
  {
    Task<List<Pedido>> GetPedidoByEstado(int idEstado);
    Task<List<Pedido>> GetAllPedidos();

    Task<List<Pedido>> GetPedidosListos();

    Task<List<Pedido>> GetMenosPedido();
    Task<List<Pedido>> GetMasPedido();
    Task<List<Pedido>> GetPedidosBySector(Sector sector);
    Task<Pedido> AddPedido(Pedido pedido);
    Task<Pedido> CambiarEstadoPedido(int idPedido, string sector, int estado);

    Task<Pedido> GetPedidoPorId(int idPedido);

  }
}
