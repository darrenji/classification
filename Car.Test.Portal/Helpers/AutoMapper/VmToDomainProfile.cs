using AutoMapper;
using Car.Test.Model;
using Car.Test.Portal.Models;

namespace Car.Test.Portal.Helpers.AutoMapper
{
    public class VmToDomainProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CarCategoryVm, CarCategory>()
                .ForMember("Car", opt => opt.Ignore());
        }
    }
}