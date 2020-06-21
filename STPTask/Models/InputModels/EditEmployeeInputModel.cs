namespace STPTask.Models.InputModels
{
    using STPTask.Mappings;
    using STPTask.Services.Models;
    using System;

    public class EditEmployeeInputModel : IMapFrom<EmployeeServiceModel>, IMapTo<EmployeeServiceModel>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartingDate { get; set; }

        public int VacantionDays { get; set; }

        public decimal Salary { get; set; }

        public string ExperienceLevel { get; set; }

        public string OfficeId { get; set; }
        public OfficeServiceModel Office { get; set; }

    }
}
