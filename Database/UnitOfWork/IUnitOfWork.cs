using lab_app_web_servidor_istea.Interfaces;

namespace lab_app_web_servidor_istea.Database.UnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    IComandaRepository ComandaRepository { get; }
    IEmpleadoRepository EmpleadoRepository { get; }
    IPedidoRepository PedidoRepository { get; }
    ISectorRepository SectorRepository { get; }
    IMesaRepository MesaRepository { get; }
    Task<int> Save();
  }
}
