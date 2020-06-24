namespace STPTask.Models.InputModels
{
    using STPTask.Domain;
    using STPTask.Mappings;
    using STPTask.Services.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterCompanyInputModel : IMapTo<Company>, 
        IMapTo<EditCompanyServiceModel>, IMapFrom<Company>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string OwnerId { get; set; }
    }
}
