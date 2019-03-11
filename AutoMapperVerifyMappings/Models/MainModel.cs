using System;

namespace AutoMapperVerifyMappings.Models
{
    public class MainModel
    {
        public int Id { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public int? ItemId { get; set; }
    }
}