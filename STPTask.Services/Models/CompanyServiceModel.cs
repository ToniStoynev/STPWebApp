namespace STPTask.Services.Models
{
    using STPTask.Domain;
    using STPTask.Mappings;
    using System;
    public class CompanyServiceModel : IMapTo<Company>, IMapFrom<Company>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public string OwnerId { get; set; }
    }
}
