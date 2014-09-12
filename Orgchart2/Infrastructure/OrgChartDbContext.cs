using System.Data.Entity;
using Orgchart2.Models;

namespace Orgchart2.Infrastructure
{
    public class OrgChartDbContext : DbContext
    {
        public OrgChartDbContext()
            : base("orgchartConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTitle>().HasKey(_ => _.Id).ToTable("Job_Title");
            modelBuilder.Entity<JobTitle>().Property(_ => _.Id).HasColumnName("JOB_TITLE_ID");
            modelBuilder.Entity<JobTitle>().Property(_ => _.Description).HasColumnName("DESCRIPTION");

            modelBuilder.Entity<Employee>().HasKey(_ => _.Id).ToTable("Employee");
            modelBuilder.Entity<Employee>().Property(_ => _.Id).HasColumnName("EMPLOYEE_ID");
            modelBuilder.Entity<Employee>().Property(_ => _.FirstName).HasColumnName("FIRST_NAME");
            modelBuilder.Entity<Employee>().Property(_ => _.LastName).HasColumnName("LAST_NAME");
            modelBuilder.Entity<Employee>().Property(_ => _.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<Employee>().Property(_ => _.SkypeName).HasColumnName("SKYPE_NAME");
            modelBuilder.Entity<Employee>().Property(_ => _.JobTitleId).HasColumnName("JOB_TITLE_ID");
            modelBuilder.Entity<Employee>().Property(_ => _.IsManager).HasColumnName("IS_MANAGER");
            modelBuilder.Entity<Employee>().Property(_ => _.ManagerId).HasColumnName("MANAGER_ID");
            modelBuilder.Entity<Employee>().Property(_ => _.DepartmentId).HasColumnName("DEPARTMENT_ID");
            modelBuilder.Entity<Employee>().HasOptional(_ => _.Manager).WithMany(_ => _.ManagedEmployees).HasForeignKey(_ => _.ManagerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Employee>().HasOptional(_ => _.JobTitle).WithMany(_ => _.Employees).HasForeignKey(_ => _.JobTitleId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Employee>().HasOptional(_ => _.Department).WithMany(_ => _.Employees).HasForeignKey(_ => _.DepartmentId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>().HasKey(_ => _.Id).ToTable("Department");
            modelBuilder.Entity<Department>().Property(_ => _.Id).HasColumnName("DEPARTMENT_ID");
            modelBuilder.Entity<Department>().Property(_ => _.ManagerId).HasColumnName("MANAGER_ID");
            modelBuilder.Entity<Department>().Property(_ => _.Name).HasColumnName("NAME");
            modelBuilder.Entity<Department>().Property(_ => _.ParentDepartmentId).HasColumnName("PARENT_DEPARTMENT_ID");
            modelBuilder.Entity<Department>().HasOptional(_ => _.Manager).WithMany(_ => _.ManagedDepartments).HasForeignKey(_ => _.ManagerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Department>().HasOptional(_ => _.ParentDepartment).WithMany(_ => _.ChildDepartments).HasForeignKey(_ => _.ParentDepartmentId).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}