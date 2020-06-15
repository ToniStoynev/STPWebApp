namespace STPTask.Models.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterCompanyInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
