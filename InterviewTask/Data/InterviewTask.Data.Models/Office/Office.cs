namespace InterviewTask.Data.Models.Office
{
    using Company;
    using Employee;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Office
    {
        public Office()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public bool Headquarters { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
