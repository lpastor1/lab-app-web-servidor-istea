using AutoMapper;
using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Entities;

namespace lab_app_web_servidor_istea.Mappers
{
  public class ComandaMapper : Profile
  {
    public ComandaMapper()
    {
      CreateMap<Comanda, ComandaGetDTO>()
          .ForMember(dest => dest.NombreMesa, opt => opt.MapFrom(src => src.Mesa.Nombre))
          .ForMember(dest => dest.NombreCliente, opt => opt.MapFrom(src => src.NombreCliente))
          .ForMember(dest => dest.Pedidos, opt => opt.MapFrom(src => src.Pedidos.Select(p => p.Producto)));

      CreateMap<Pedido, PedidoComandaDTO>()
          .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.Producto.Descripcion))
          .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Producto.Precio.ToString("F2")))
          .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Producto.Sector.Descripcion));

      CreateMap<Comanda, ComandaResponseDTO>()
          .ForMember(dest => dest.NombreMesa, opt => opt.MapFrom(src => src.Mesa.Nombre))
          .ForMember(dest => dest.NombreCliente, opt => opt.MapFrom(src => src.NombreCliente))
          .ForMember(dest => dest.Pedidos, opt => opt.MapFrom(src => src.Pedidos));
    }
  }
}