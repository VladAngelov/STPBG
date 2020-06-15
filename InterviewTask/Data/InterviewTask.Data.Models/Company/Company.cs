namespace InterviewTask.Data.Models.Company
{
    using Office;
    using User;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        public Company()
        {
            this.Offices = new HashSet<Office>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Office> Offices { get; set; }

        public int InterviewTaskUserId { get; set; }

        public InterviewTaskUser User { get; set; }
    }
}
