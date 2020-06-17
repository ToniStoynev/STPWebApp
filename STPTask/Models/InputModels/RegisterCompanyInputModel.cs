namespace STPTask.Models.InputModels
{
    using STPTask.Mappings;
    using STPTask.Services.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterCompanyInputModel : IMapTo<CompanyServiceModel>, 
        IMapTo<EditCompanyServiceModel>, IMapFrom<CompanyServiceModel>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
