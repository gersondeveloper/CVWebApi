using AutoMapper;
using CVWebApi.ViewModel;

namespace CVWebApi.Mapping;

public class ViewModelToModel: Profile
{
    public ViewModelToModel()
    {
        CreateMap<ExperienceViewModel, Experience>();
    }
}