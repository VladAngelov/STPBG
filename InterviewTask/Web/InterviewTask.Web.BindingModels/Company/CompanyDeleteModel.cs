namespace InterviewTask.Web.BindingModels.Company
{
    using Services.Mapping;
    using Services.Models.Company;

    public class CompanyDeleteModel : IMapFrom<CompanyServiceModel>
    {
        public string Name { get; set; }
    }
}
