using AutoMapper;
using Car.Test.Model;
using Car.Test.Portal.Models;

namespace Car.Test.Portal.Helpers.AutoMapper
{
    public class DomainToVmProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CarCategory, CarCategoryVm>();
        }
    }
}