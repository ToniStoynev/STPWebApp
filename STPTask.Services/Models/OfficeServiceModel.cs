namespace STPTask.Services.Models
{
    using STPTask.Domain;
    using STPTask.Mappings;

    public class OfficeServiceModel : IMapTo<Office>, IMapFrom<Office>
    {
        public string Id { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public bool IsHeadquarter { get; set; }

        public string CompanyId { get; set; }

        public CompanyServiceModel Company { get; set; }
    }
}
