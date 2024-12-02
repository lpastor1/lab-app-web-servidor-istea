namespace lab_app_web_servidor_istea.DTO
{
  public class EmpleadoResponseDTO
  {
    public required int Id { get; set; }
    public required string Nombre { get; set; }

    public required string Usuario { get; set; }

    public required string Sector { get; set; }

    public required string Rol { get; set; }
  }
}
