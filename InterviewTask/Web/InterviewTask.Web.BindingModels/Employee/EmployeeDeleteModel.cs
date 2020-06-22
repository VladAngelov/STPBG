namespace InterviewTask.Web.BindingModels.Employee
{
    using Services.Mapping;
    using Services.Models.Employee;
    using System;

    public class EmployeeDeleteModel : IMapFrom<EmployeeServiceModel>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }
    }
}
