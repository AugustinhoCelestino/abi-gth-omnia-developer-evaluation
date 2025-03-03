using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllCategories
{
    public class GetAllCategoriesProfile : Profile
    {
        public GetAllCategoriesProfile() 
        {
            CreateMap<GetAllCategoriesCommand, string>();
        }
    }
}
