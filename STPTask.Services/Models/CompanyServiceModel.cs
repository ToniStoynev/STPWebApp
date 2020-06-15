namespace STPTask.Services.Models
{
    using System;
    public class CompanyServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public string OwnerId { get; set; }
    }
}
