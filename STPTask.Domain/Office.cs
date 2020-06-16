namespace STPTask.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Office
    {
        public Office()
        {
            this.Employees = new HashSet<Employee>();
        }

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

        public ICollection<Employee> Employees { get; set; }
    }
}
