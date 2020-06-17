namespace InterviewTask.Web.BindingModels.Office
{
    using Services.Mapping;
    using Services.Models.Company;
    using Services.Models.Employee;
    using Services.Models.Office;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TextConstants;

    public class OfficeBindingModel : IMapTo<OfficeVieweModel>
    {
        [Required(ErrorMessage = StaticTextConstants.NAME_ERROR_MESSAGE)]
        [StringLength(30, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 2)]
        [Display(Name = StaticTextConstants.COUNTRY_DISPLAY_NAME)]
        public string Country { get; set; }

        [Required(ErrorMessage = StaticTextConstants.NAME_ERROR_MESSAGE)]
        [StringLength(30, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 2)]
        [Display(Name = StaticTextConstants.CITY_DISPLAY_NAME)]
        public string City { get; set; }

        [Required(ErrorMessage = StaticTextConstants.NAME_ERROR_MESSAGE)]
        [StringLength(50, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 2)]
        [Display(Name = StaticTextConstants.STREET_DISPLAY_NAME)]
        public string Street { get; set; }

        [Required(ErrorMessage = StaticTextConstants.NUMBER_ERROR_MESSAGE)]
        [Range(typeof(int), StaticTextConstants.NUMBER_MIN_VALUE, StaticTextConstants.NUMBER_MAX_VALUE)]
        [Display(Name = StaticTextConstants.STREET_DISPLAY_NUMBER )]
        public int StreetNumber { get; set; }

        [Required(ErrorMessage = StaticTextConstants.HEADQUARTERS_ERROR_MESSAGE)]
        [Display(Name = StaticTextConstants.HEADQUARTERS_DISPLAY)]
        public bool Headquarters { get; set; }

        public ICollection<EmployeeServiceModel> Employees { get; set; }

        public int CompanyId { get; set; }

        public CompanyServiceModel Company { get; set; }
    }
}
