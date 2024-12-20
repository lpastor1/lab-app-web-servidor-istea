﻿using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Interfaces
{
  public interface ISectorRepository : IRepository<Sector>
  {
    Task<List<OperacionesSector>> GetOperacionesPorSector(string description);
    Task<Sector> GetSectorByDescription(string description);
    Task<List<OperacionesSectorEmpleado>> GetOperacionesPorSectorPorEmpleado();

    Task<List<OperacionesEmpleado>> GetOperacionesPorSectorPorEmpleado(string descriptionSector);

  }
}
