namespace InterviewTask.Data.Models.User
{
    using Company;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;


    public class InterviewTaskUser : IdentityUser
    {
        private string fullName;

        public InterviewTaskUser()
        {
            this.Companies = new HashSet<Company>();
        }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = FirstName + " " + LastName;
            }
        }

        public ICollection<Company> Companies { get; set; }
    }
}
