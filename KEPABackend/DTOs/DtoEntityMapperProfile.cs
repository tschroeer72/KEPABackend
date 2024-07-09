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
        CreateMap<MitgliedCreate, TblMitglieder>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<MitgliedUpdate, TblMitglieder>().ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
