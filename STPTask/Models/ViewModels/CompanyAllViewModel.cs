namespace STPTask.Models.ViewModels
{
    using STPTask.Mappings;
    using STPTask.Services.Models;
    using System;

    public class CompanyAllViewModel : IMapFrom<CompanyServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
