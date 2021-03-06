﻿namespace STPTask.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Domain;

    public class STPTaskDbContext : IdentityDbContext<STPUser, IdentityRole, string>
    {
        public DbSet<Office> Offices { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public STPTaskDbContext(DbContextOptions<STPTaskDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TONI\SQLEXPRESS;Database=STPTask;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Office>()
                .HasKey(office => office.Id);

            modelBuilder.Entity<Office>()
                .HasMany(office => office.Employees);

            modelBuilder.Entity<Company>()
                .HasKey(company => company.Id);

            modelBuilder.Entity<Company>()
                .HasMany(company => company.Offices)
                .WithOne(office => office.Company);

            modelBuilder.Entity<Employee>()
              .HasKey(employee => employee.Id);

            base.OnModelCreating(modelBuilder);
        }

    }
}
