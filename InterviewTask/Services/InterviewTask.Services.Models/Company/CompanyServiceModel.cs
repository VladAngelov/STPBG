namespace InterviewTask.Services.Models.Company
{
    using Data.Models.Company;
    using Data.Models.Office;
    using InterviewTask.Services.Mapping;
    using System.Collections.Generic;

    public class CompanyServiceModel : IMapFrom<Company>, IMapTo<Company>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Office> Offices { get; set; }
    }
}
