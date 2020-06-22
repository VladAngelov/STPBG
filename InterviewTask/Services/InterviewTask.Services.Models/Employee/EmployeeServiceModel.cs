namespace InterviewTask.Services.Models.Employee
{
    using Data.Models.Employee;
    using Data.Models.Office;
    using Mapping;
    using System;

    public class EmployeeServiceModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }

        public Decimal Salary { get; set; }

        public int VacantionDays { get; set; }

        public EmployeeExperienceLevel ExperienceLevel { get; set; }

        public int OfficeId { get; set; }

        public Office Office { get; set; }
    }
}
