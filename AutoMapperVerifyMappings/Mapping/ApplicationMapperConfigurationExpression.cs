using System;
using AutoMapper.Configuration;

namespace AutoMapperVerifyMappings.Mapping
{
    public class ApplicationMapperConfigurationExpression : MapperConfigurationExpression
    {
        public ApplicationMapperConfigurationExpression()
        {
            // prevent AutoMapper from trying to build target objects by automagically 
            // mapping constructor params from the source object properties
            this.DisableConstructorMapping();
            this.AllowNullCollections = true;

            // needed to prevent AutoMapper from auto-auto-mapping which is not 100% reliable and can lead to subtle errors not caught without specific testing for each conversion map
            this.CreateMissingTypeMaps = false; 
        }
    }

}
