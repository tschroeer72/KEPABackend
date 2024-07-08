using AutoMapper;
using KEPABackend.DTOs;
using KEPABackend.Modell;

namespace KEPABackend.Services;

public class DtoEntityMapperProfile : Profile
{
    public DtoEntityMapperProfile()
    {
        CreateMap<MitgliedCreate, TblMitglieder>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<MitgliedUpdate, TblMitglieder>().ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
