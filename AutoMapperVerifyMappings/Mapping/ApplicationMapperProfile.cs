using System;
using AutoMapper;
using AutoMapperVerifyMappings.Models;

namespace AutoMapperVerifyMappings.Mapping
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            this.CreateMap<MainViewModel, MainModel>()
                // this does not appear to be recognised by the AssertConfigurationIsValid() method
                .ForMember(m => m.ItemId, opts => opts.MapFrom<ResolveNullableIdFromReferenceModel, ReferenceViewModel>(vm => vm.Item));
        }
    }

    public class ApplicationMapperProfileWorkaround : Profile
    {
        public ApplicationMapperProfileWorkaround()
        {
            this.CreateMap<MainViewModel, MainModel>()
                // this uses the overload that uses a string to specify the Property name to read the source data from
                .ForMember(m => m.ItemId, opts => opts.MapFrom<ResolveNullableIdFromReferenceModel, ReferenceViewModel>(nameof(MainViewModel.Item)));
        }
    }
}