using AutoMapper;
using PDVAplication.Domain.Model;
using PDVAplication.Shared.ViewModel.Customer;

namespace PDVAplication.Shared.Mapper
{
    public class PDVAplicationMappingProfile : Profile
    {
        public PDVAplicationMappingProfile()
        {
            CreateMap<CustomerModel, CustomerViewModel>().ReverseMap();
            CreateMap<CustomerModel, CustomerByIdViewModel>().ReverseMap();
        }
    }
}
