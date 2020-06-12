namespace STPTask.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Company
    {
        public Company()
        {
            this.Offices = new HashSet<Office>();
            this.Employees = new HashSet<Employee>();
        }
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public ICollection<Office> Offices { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
