using AutoMapper;
using PDVAplication.Domain.Model;
using PDVAplication.Shared.ViewModel.Customer;
using PDVAplication.Shared.ViewModel.Product;

namespace PDVAplication.Shared.Mapper
{
    public class PDVAplicationMappingProfile : Profile
    {
        public PDVAplicationMappingProfile()
        {
            CreateMap<CustomerModel, CustomerViewModel>().ReverseMap();
            CreateMap<CustomerModel, CustomerByIdViewModel>().ReverseMap();
            CreateMap<ProductModel, ProductViewModel>().ReverseMap();
        }
    }
}
