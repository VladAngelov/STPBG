namespace InterviewTask.Services.Models.Company
{
    using Data.Models.Company;
    using Data.Models.Office;
    using Data.Models.User;
    using Services.Mapping;
    using System.Collections.Generic;

    public class CompanyServiceModel : IMapFrom<Company>, IMapTo<Company>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Office> Offices { get; set; }

        public string UserId { get; set; }

        public InterviewTaskUser User { get; set; }
    }
}
