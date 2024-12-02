using AutoMapper;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Mappers
{
  public class SectorMapper : Profile
  {
    public SectorMapper()
    {
      CreateMap<OperacionesEmpleado, OperacionesEmpleadoDTO>()
         .ForMember(src => src.CantidadPedidos, emp => emp.MapFrom(src => src.CantidadPedidos))
         .ForMember(src => src.NombreEmpleado, emp => emp.MapFrom(src => src.NombreEmpleado));

      CreateMap<OperacionesSectorEmpleado, OperacionesSectorEmpleadoDTO>()
         .ForMember(src => src.CantidadPedidos, emp => emp.MapFrom(src => src.CantidadPedidos))
         .ForMember(src => src.NombreEmpleado, emp => emp.MapFrom(src => src.NombreEmpleado))
         .ForMember(src => src.SectorDescripcion, emp => emp.MapFrom(src => src.SectorDescripcion));

      CreateMap<OperacionesSector, OperacionesSector>()
          .ForMember(src => src.CantidadPedidos, emp => emp.MapFrom(src => src.CantidadPedidos))
          .ForMember(src => src.NombreSector, emp => emp.MapFrom(src => src.NombreSector));
    }
  }
}
