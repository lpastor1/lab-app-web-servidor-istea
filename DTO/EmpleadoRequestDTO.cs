namespace lab_app_web_servidor_istea.DTO
{
  public class EmpleadoRequestDTO
  {
    public string Nombre { get; set; }

    public string Usuario { get; set; }

    public string Password { get; set; }
    public int IdSector { get; set; }

    public int RolId { get; set; }
  }
}
