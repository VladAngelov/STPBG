namespace InterviewTask.Services.Models.Office
{
    using Data.Models.Company;
    using Data.Models.Employee;
    using System.Collections.Generic;

    public class OfficeServiceModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public bool Headquarters { get; set; }

        public List<Employee> Employees { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
