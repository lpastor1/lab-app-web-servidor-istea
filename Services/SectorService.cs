using AutoMapper;
using lab_app_web_servidor_istea.Interfaces;
using lab_app_web_servidor_istea.Database.UnitOfWork;
using lab_app_web_servidor_istea.DTO;
namespace lab_app_web_servidor_istea.Services
{
  public class SectorService(IUnitOfWork unitOfWork, IMapper mapper) : ISectorService
  {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<OperacionesSectorDTO>> GetOperacionesPorSector(string sectorDescripcion)
    {
      var operacionesPorSectorEmpleado = await _unitOfWork.SectorRepository.GetOperacionesPorSector(sectorDescripcion);
      return _mapper.Map<List<OperacionesSectorDTO>>(operacionesPorSectorEmpleado);
    }

    public async Task<List<OperacionesSectorEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado()
    {
      var operacionesPorSectorEmpleado = await _unitOfWork.SectorRepository.GetOperacionesPorSectorPorEmpleado();
      return _mapper.Map<List<OperacionesSectorEmpleadoDTO>>(operacionesPorSectorEmpleado);
    }

    public async Task<List<OperacionesEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado(string sectorDescripcion)
    {
      var operacionesPorSectorEmpleado = await _unitOfWork.SectorRepository.GetOperacionesPorSectorPorEmpleado(sectorDescripcion);
      return _mapper.Map<List<OperacionesEmpleadoDTO>>(operacionesPorSectorEmpleado);
    }

  }
}
