namespace STPTask.Models.ViewModels
{
    using STPTask.Domain;
    using STPTask.Mappings;
    using System;

    public class CompanyAllViewModel : IMapFrom<Company>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
