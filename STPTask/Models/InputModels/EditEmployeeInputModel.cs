namespace STPTask.Models.InputModels
{
    using STPTask.Domain;
    using STPTask.Mappings;
    using System;

    public class EditEmployeeInputModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartingDate { get; set; }

        public int VacantionDays { get; set; }

        public decimal Salary { get; set; }

        public string ExperienceLevel { get; set; }

        public string OfficeId { get; set; }
        public Office Office { get; set; }

    }
}
