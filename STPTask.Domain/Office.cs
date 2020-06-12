namespace STPTask.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Office
    {
        [Required]
        public string Id { get; set; }

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
        public Company Company { get; set; }
    }
}
