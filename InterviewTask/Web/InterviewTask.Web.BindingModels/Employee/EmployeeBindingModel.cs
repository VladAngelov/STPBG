namespace InterviewTask.Web.BindingModels.Employee
{
    using Services.Models.Employee;
    using Services.Models.Office;
    using Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;
    using TextConstants;

    public class EmployeeBindingModel : IMapTo<EmployeeServiceModel>
    {
        public int EmpolyeeId { get; set; }

        [Required(ErrorMessage = StaticTextConstants.NAME_ERROR_MESSAGE)]
        [StringLength(30, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 2)]
        [Display(Name = StaticTextConstants.EMPLOYEE_DISPLAY_FIRST_NAME)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = StaticTextConstants.NAME_ERROR_MESSAGE)]
        [StringLength(30, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 2)]
        [Display(Name = StaticTextConstants.EMPLOYEE_DISPLAY_LAST_NAME)]
        public string LastName { get; set; }

        [Required(ErrorMessage = StaticTextConstants.DATE_ERROR_MESSAGE)]
        [DisplayFormat(DataFormatString = StaticTextConstants.DATE_FORMAT)]
        [Display(Name = StaticTextConstants.EMPLOYEE_DISPALY_START_DATE)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = StaticTextConstants.NUMBER_ERROR_MESSAGE)]
        [Range(typeof(decimal), StaticTextConstants.EMPLOYEE_SALARY_MIN_VALUE, 
                                StaticTextConstants.EMPLOYEE_SALARY_MAX_VALUE)]
        [Display(Name = StaticTextConstants.EMPLOYEE_DISPLAY_SALARY)]
        public Decimal Salary { get; set; }

        public int VacantionDays { get; set; }

        [Required(ErrorMessage = StaticTextConstants.EXPIRIENCE_ERROR)]
        [Display(Name = StaticTextConstants.EMPLOYEE_DISPLAY_EXPIRIENCE)]
        public EmployeeExperienceLevelBindingModel ExperienceLevel { get; set; }

        public int OfficeId { get; set; }

        public OfficeServiceModel Office { get; set; }
    }
}
