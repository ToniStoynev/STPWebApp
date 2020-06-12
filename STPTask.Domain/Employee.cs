namespace STPTask.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Employee
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int VacantionDays { get; set; }

        [Required]
        public string ExperienceLevel { get; set; }

        [Required]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
