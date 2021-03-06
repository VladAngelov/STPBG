﻿namespace InterviewTask.Web.ViewModels.Employee
{
    using Services.Mapping;
    using Services.Models.Employee;
    using Services.Models.Office;
    using System;

    public class EmployeeViewModel : IMapFrom<EmployeeServiceModel>, IMapTo<EmployeeServiceModel>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }

        public Decimal Salary { get; set; }

        public int VacantionDays { get; set; }

        public EmployeeExperienceLevelServiceModel ExperienceLevel { get; set; }

        public int OfficeId { get; set; }

        public OfficeServiceModel Office { get; set; }
    }
}
