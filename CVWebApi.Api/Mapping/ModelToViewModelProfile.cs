using AutoMapper;
using CVWebApi.ViewModel;

namespace CVWebApi.Mapping;

public class ModelToViewModelProfile : Profile
{
    public ModelToViewModelProfile()
    {
        CreateMap<Experience, ExperienceViewModel>();
    }
}