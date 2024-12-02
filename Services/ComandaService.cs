using AutoMapper;
using lab_app_web_servidor_istea.Database.UnitOfWork;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;
using lab_app_web_servidor_istea.Interfaces;

namespace lab_app_web_servidor_istea.Services;

public class ComandaService(IUnitOfWork unitOfWork, IMapper mapper) : IComandaService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;

  public async Task<Comanda> Get(int idComanda)
  {
    var comanda = await _unitOfWork.ComandaRepository.GetId(idComanda);

    if (comanda == null)
    {
      throw new KeyNotFoundException($"Comanda {idComanda} no encontrada");
    }

    return comanda;
  }

  public async Task<ComandaResponseDTO> ObtenerComandaPorId(int idComanda)
  {
    try
    {
      var comanda = await _unitOfWork.ComandaRepository.ObtenerComandaPorId(idComanda);
      ComandaResponseDTO comandaDTO = _mapper.Map<ComandaResponseDTO>(comanda);
      return comandaDTO;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }


  public async Task<ComandaResponseDTO> Add(ComandaDTO comanda)
  {
    try
    {
      var comandaEntity = await _unitOfWork.ComandaRepository.AgregarComanda(comanda);

      ComandaResponseDTO comandaDTO = _mapper.Map<ComandaResponseDTO>(comandaEntity);

      return comandaDTO;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }

  public async Task<ComandaResponseDTO> Update(int idComanda, ComandaDTO comanda)
  {
    try
    {
      var comandaEntity = await _unitOfWork.ComandaRepository.ObtenerComandaPorId(idComanda) ?? throw new KeyNotFoundException($"Comanda {idComanda} no encontrada");

      await _unitOfWork.ComandaRepository.ActualizarComanda(comandaEntity);

      ComandaResponseDTO comandaDTO = _mapper.Map<ComandaResponseDTO>(comandaEntity);

      return comandaDTO;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }

  public async Task<bool> Delete(int idComanda)
  {
    Comanda comanda = await _unitOfWork.ComandaRepository.GetId(idComanda);
    _unitOfWork.ComandaRepository.Delete(comanda);
    var result = await _unitOfWork.Save();
    return result > 0;
  }
}
