using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Icatu.EmployeeManagerAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Icatu.EmployeeManagerAPI.Core.Contexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Set { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ForSqlServerUseIdentityColumns();
            builder.Entity<Employee>(emp =>
            {
                emp.ToTable("Employees");
                emp.HasKey(e => e.Id).HasName("Id");
                emp.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                emp.Property(e => e.Name).HasColumnName("Name").HasMaxLength(60);
                emp.Property(e => e.Email).HasColumnName("Email").HasMaxLength(40);
                emp.Property(e => e.Department).HasColumnName("Department").HasMaxLength(10);
            });
        }
    }
}
