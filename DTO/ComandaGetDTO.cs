namespace lab_app_web_servidor_istea.DTO
{
  public class ComandaGetDTO
  {
    public string NombreCliente { get; set; }
    public string NombreMesa { get; set; }
    public List<PedidoComandaDTO> Pedidos { get; set; }
  }
}
