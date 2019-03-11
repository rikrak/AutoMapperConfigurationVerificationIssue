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
                .ForMember(m => m.EffectiveFrom, opts => opts.MapFrom((vm, cmd) => vm.EffectiveFrom ?? DateTime.UtcNow))
                .ForMember(m => m.ItemId, opts => opts.MapFrom<ResolveNullableIdFromReferenceModel, ReferenceViewModel>(vm => vm.Item))
                .ForMember(m => m.Id, opts => opts.MapFrom(vm => DataConstants.UndefinedId));

        }
    }
}