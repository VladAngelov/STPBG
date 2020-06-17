namespace InterviewTask.Web.ViewModels.Office
{
    using Services.Models.Company;
    using Services.Mapping;
    using Services.Models.Employee;
    using Services.Models.Office;
    using System.Collections.Generic;

    public class OfficeViewModel : IMapFrom<OfficeServiceModel>, IMapTo<OfficeServiceModel>
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
