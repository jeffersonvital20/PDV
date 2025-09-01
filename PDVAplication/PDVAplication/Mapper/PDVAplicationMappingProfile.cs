using AutoMapper;
using PDVAplication.Domain.Model;
using PDVAplication.Shared.ViewModel.Customer;
using PDVAplication.Shared.ViewModel.Product;
using PDVAplication.Shared.ViewModel.Sale;

namespace PDVAplication.Shared.Mapper
{
    public class PDVAplicationMappingProfile : Profile
    {
        public PDVAplicationMappingProfile()
        {
            CreateMap<CustomerModel, CustomerViewModel>().ReverseMap();
            CreateMap<CustomerModel, CustomerByIdViewModel>().ReverseMap();
            CreateMap<ProductModel, ProductViewModel>().ReverseMap();
            CreateMap<ProductModel, ProductSoldViewModel>().ReverseMap();
            CreateMap<SalesModel, SaleViewModel>().ReverseMap();
            CreateMap<SalesModel, InitialSaleViewModel>().ReverseMap();
            CreateMap<SalesModel, UpdateProductSaleViewModel>().ReverseMap();
        }
    }
}
