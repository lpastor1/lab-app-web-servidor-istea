using AutoMapper;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Mappers
{

  public class EmpleadoMapper : Profile
  {
    public EmpleadoMapper()
    {
      CreateMap<Empleado, EmpleadoResponseDTO>()
          .ForMember(src => src.Id, emp => emp.MapFrom(src => src.Id))
          .ForMember(src => src.Nombre, emp => emp.MapFrom(src => src.Nombre))
          .ForMember(src => src.Usuario, emp => emp.MapFrom(src => src.Usuario))
          .ForMember(src => src.Sector, emp => emp.MapFrom(src => src.Sector.Descripcion))
          .ForMember(src => src.Rol, emp => emp.MapFrom(src => src.Rol.Descripcion));

      CreateMap<EmpleadoRequestDTO, Empleado>()
          .ForMember(src => src.Nombre, emp => emp.MapFrom(src => src.Nombre))
          .ForMember(src => src.RolId, emp => emp.MapFrom(src => src.RolId))
          .ForMember(src => src.IdSector, emp => emp.MapFrom(src => src.IdSector));

      CreateMap<EmpleadoUpdateRequestDTO, Empleado>()
         .ForMember(src => src.Nombre, emp => emp.MapFrom(src => src.Nombre))
         .ForMember(src => src.RolId, emp => emp.MapFrom(src => src.RolId))
         .ForMember(src => src.IdSector, emp => emp.MapFrom(src => src.IdSector));
    }
  }
}
