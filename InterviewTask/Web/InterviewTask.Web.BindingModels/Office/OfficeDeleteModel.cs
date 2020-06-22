namespace InterviewTask.Web.BindingModels.Office
{
    using Services.Mapping;
    using Services.Models.Office;

    public class OfficeDeleteModel : IMapFrom<OfficeServiceModel>
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }
    }
}
