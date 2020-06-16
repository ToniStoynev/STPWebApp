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
        }
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public STPUser Owner { get; set; }

        public ICollection<Office> Offices { get; set; }
    }
}
