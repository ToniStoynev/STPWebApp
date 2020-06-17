namespace STPTask.Models.ViewModels
{
    using STPTask.Mappings;
    using STPTask.Services.Models;
    public class CompanyOfficesAllViewModel : IMapFrom<OfficeServiceModel>
    {
        public string Id { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public bool IsHeadquarter { get; set; }
    }
}
