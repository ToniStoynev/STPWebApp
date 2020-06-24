namespace STPTask.Models.InputModels
{
    using STPTask.Domain;
    using STPTask.Mappings;
    using System.ComponentModel.DataAnnotations;

    public class OpenOfficeInputModel : IMapTo<Office>
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
        public bool IsHeadquarter { get; set; }

        [Required]
        public string CompanyId { get; set; }
    }
}
