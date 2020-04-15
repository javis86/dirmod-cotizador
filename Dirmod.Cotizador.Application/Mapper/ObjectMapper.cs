using AutoMapper;
using Dirmod.Cotizador.Application.Core;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CotizacionExterna, Cotizacion>()
            .ForMember(dest =>
                dest.Moneda,
                opt => opt.MapFrom(src => src.source))
            .ForMember(dest =>
                dest.Precio,
                opt => opt.MapFrom(src => src.value))
            .ReverseMap(); ; 
    }
}