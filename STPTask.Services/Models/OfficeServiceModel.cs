namespace STPTask.Services.Models
{
    public class OfficeServiceModel
    {
        public string Id { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public bool IsHeadquerter { get; set; }

        public string CompanyId { get; set; }

        public CompanyServiceModel Company { get; set; }
    }
}
