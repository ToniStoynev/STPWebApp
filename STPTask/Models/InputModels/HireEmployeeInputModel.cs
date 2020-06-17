﻿namespace STPTask.Models.InputModels
{
    using STPTask.Mappings;
    using STPTask.Services.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HireEmployeeInputModel : IMapTo<EmployeeServiceModel>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public int VacantionDays { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string ExperienceLevel { get; set; }

        [Required]
        public string CompanyId { get; set; }
    }
}
