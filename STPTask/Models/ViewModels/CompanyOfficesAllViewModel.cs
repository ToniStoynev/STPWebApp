namespace STPTask.Models.ViewModels
{
    using STPTask.Domain;
    using STPTask.Mappings;
    public class CompanyOfficesAllViewModel : IMapFrom<Office>
    {
        public string Id { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public bool IsHeadquarter { get; set; }
    }
}
