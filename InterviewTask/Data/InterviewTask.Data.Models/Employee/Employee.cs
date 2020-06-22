namespace InterviewTask.Data.Models.Employee
{
    using Office;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public Decimal Salary { get; set; }

        public int VacantionDays { get; set; }

        [Required]
        public EmployeeExperienceLevel ExperienceLevel { get; set; }

        public int OfficeId { get; set; }

        public Office Office { get; set; }
    }
}
