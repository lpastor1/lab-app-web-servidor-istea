namespace lab_app_web_servidor_istea.DTO
{
  public class EmpleadoUpdateRequestDTO
  {
    public required string Nombre { get; set; }

    public int IdSector { get; set; }

    public int RolId { get; set; }
  }
}
