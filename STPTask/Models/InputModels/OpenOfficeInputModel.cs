namespace STPTask.Models.InputModels
{
    using STPTask.Mappings;
    using STPTask.Services.Models;
    using System.ComponentModel.DataAnnotations;

    public class OpenOfficeInputModel : IMapTo<OfficeServiceModel>
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public bool IsHeadquerter { get; set; }

        [Required]
        public string CompanyId { get; set; }
    }
}
