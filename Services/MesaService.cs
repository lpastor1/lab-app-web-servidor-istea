using AutoMapper;
using lab_app_web_servidor_istea.Database.UnitOfWork;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Interfaces;
namespace lab_app_web_servidor_istea.Services
{
  public class MesaService : IMesaService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MesaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }
    public async Task<List<MesaResponseDTO>> GetMesas()
    {
      var mesas = await _unitOfWork.MesaRepository.GetMesas();
      return _mapper.Map<List<MesaResponseDTO>>(mesas);
    }

    public async Task CerrarMesa(string nombreMesa)
    {
      await _unitOfWork.MesaRepository.CerrarMesa(nombreMesa);
    }

    public async Task CambiarEstado(string nombreMesa, int idEstado)
    {
      await _unitOfWork.MesaRepository.CambiarEstado(nombreMesa, idEstado);
    }
  }
}
