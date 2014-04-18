using AutoMapper;

namespace Car.Test.Portal.Helpers.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<VmToDomainProfile>());
            Mapper.Initialize(x => x.AddProfile<DomainToVmProfile>());
        }
    }
}