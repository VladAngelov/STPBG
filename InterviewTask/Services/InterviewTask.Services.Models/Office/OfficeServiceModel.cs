﻿namespace InterviewTask.Services.Models.Office
{
    using Models.Company;
    using Models.Employee;
    using System.Collections.Generic;

    public class OfficeServiceModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public bool Headquarters { get; set; }

        public ICollection<EmployeeServiceModel> Employees { get; set; }

        public int CompanyId { get; set; }

        public CompanyServiceModel Company { get; set; }
    }
}
