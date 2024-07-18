using AutoMapper;
using KEPABackend.DTOs.Post;
using KEPABackend.Modell;

namespace KEPABackend.DTOs;

/// <summary>
/// Config für AutoMapper
/// </summary>
public class DtoEntityMapperProfile : Profile
{
    /// <summary>
    /// Constructor
    /// </summary>
    public DtoEntityMapperProfile()
    {
        CreateMap<MitgliedCreate, TblMitglieder>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.AusgeschiedenAm, opt => opt.Ignore())
            .ForMember(dest => dest.Ehemaliger, opt => opt.Ignore())
            .ForMember(dest => dest.HolzGes, opt => opt.Ignore())
            .ForMember(dest => dest.HolzMax, opt => opt.Ignore())
            .ForMember(dest => dest.HolzMin, opt => opt.Ignore())
            .ForMember(dest => dest.PassivSeit, opt => opt.Ignore())
            .ForMember(dest => dest.Platz, opt => opt.Ignore())
            .ForMember(dest => dest.Punkte, opt => opt.Ignore())
            .ForMember(dest => dest.SpAnz, opt => opt.Ignore())
            .ForMember(dest => dest.SpGew, opt => opt.Ignore())
            .ForMember(dest => dest.SpUn, opt => opt.Ignore())
            .ForMember(dest => dest.SpVerl, opt => opt.Ignore())
            .ForMember(dest => dest.TurboDbnummer, opt => opt.Ignore());
        CreateMap<MitgliedUpdate, TblMitglieder>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<MeisterschaftCreate, TblMeisterschaften>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<MeisterschaftUpdate, TblMeisterschaften>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<SpieltagCreate, TblSpieltag>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<NeunerRattenCreate, Tbl9erRatten>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<NeunerRattenUpdate, Tbl9erRatten>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Spiel6TageRennenCreate, TblSpiel6TageRennen>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Spiel6TageRennenUpdate, TblSpiel6TageRennen>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<SpielBlitztunierCreate, TblSpielBlitztunier>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<SpielBlitztunierUpdate, TblSpielBlitztunier>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<SpielMeisterschaftCreate, TblSpielMeisterschaft>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<SpielMeisterschaftUpdate, TblSpielMeisterschaft>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<SpielKombimeisterschaftCreate, TblSpielKombimeisterschaft>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<SpielKombimeisterschaftUpdate, TblSpielKombimeisterschaft>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<SpielPokalCreate, TblSpielPokal>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<SpielPokalUpdate, TblSpielPokal>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<SpielSargkegelnCreate, TblSpielSargKegeln>().ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
