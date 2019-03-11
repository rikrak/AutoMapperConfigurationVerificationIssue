using AutoMapper;
using AutoMapperVerifyMappings.Models;

namespace AutoMapperVerifyMappings.Mapping
{
    public class ResolveNullableIdFromReferenceModel : IMemberValueResolver<object, object, ReferenceViewModel, int?>
    {
        public ResolveNullableIdFromReferenceModel()
        {
        }

        public int? Resolve(object source, object destination, ReferenceViewModel sourceMember, int? destMember, ResolutionContext context)
        {
            return sourceMember?.Id ?? DataConstants.UndefinedId;
        }
    }
}