namespace InterviewTask.Services.Models.Employee
{
    using Data.Models.Employee;
    using Mapping;
    using Office;
    using System;

    public class EmployeeServiceModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public int EmpolyeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }

        public Decimal Salary { get; set; }

        public int VacantionDays { get; set; }

        public EmployeeExperienceLevelServiceModel ExperienceLevel { get; set; }

        public int OfficeId { get; set; }

        public OfficeVieweModel Office { get; set; }
    }
}
