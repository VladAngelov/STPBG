namespace InterviewTask.Web.BindingModels.Company
{
    using Services.Mapping;
    using Services.Models.Company;
    using System.ComponentModel.DataAnnotations;
    using TextConstants;

    public class CompanyBindingModel : IMapTo<CompanyServiceModel>
    {
        [Required(ErrorMessage = StaticTextConstants.NAME_ERROR_MESSAGE)]
        [StringLength(100, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 2)]
        [Display(Name = StaticTextConstants.COMPANY_DISPLAY_NAME)]
        public string Name { get; set; }

        [Required(ErrorMessage = StaticTextConstants.NAME_ERROR_MESSAGE)]
        [StringLength(800, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 5)]
        [Display(Name = StaticTextConstants.COMPANY_DISPLAY_ADDRESS)]
        public string Address { get; set; }
    }
}
