using AutoMapper;

namespace MappingInterfaceToViewModel
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Contract.Container, ViewModel.Container>();

            CreateMap<Contract.ICategory, ViewModel.Category>()
                    .Include<Contract.Category, ViewModel.Category>()
                    .Include<Contract.NoCategory, ViewModel.Category>();

            CreateMap<Contract.NoCategory, ViewModel.Category>()
                .ForMember(d => d.IsVisible, opt => opt.UseValue(false));

            CreateMap<Contract.Category, ViewModel.Category>()
                .ForMember(d => d.IsVisible, opt => opt.UseValue(true))
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(x => x.Id));
        }
    }
}