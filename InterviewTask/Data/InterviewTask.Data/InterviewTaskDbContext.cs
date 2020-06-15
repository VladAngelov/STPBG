﻿namespace InterviewTask.Data
{
    using InterviewTask.Data.Models.User;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models.Company;
    using Models.Employee;
    using Models.Office;

    public class InterviewTaskDbContext : IdentityDbContext<InterviewTaskUser>
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Office> Offices { get; set; }


        public InterviewTaskDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
