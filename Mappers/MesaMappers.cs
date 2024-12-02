using AutoMapper;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;
namespace lab_app_web_servidor_istea.Mappers
{
  public class MesaMapper : Profile
  {
    public MesaMapper()
    {
      CreateMap<Mesa, MesaResponseDTO>()
          .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
          .ForMember(dest => dest.EstadoDescripcion, opt => opt.MapFrom(src => src.EstadosMesa.Descripcion));
    }
  }
}
