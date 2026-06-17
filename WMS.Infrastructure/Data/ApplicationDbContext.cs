using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Data {
  public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Leave> Leaves { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // EMPLOYEE
      modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();

      modelBuilder.Entity<Employee>()
        .ToTable(t => {
          t.HasCheckConstraint(name: "CK_Employee_Age18", sql: "DATEDIFF(year, [DOB], GETDATE()) >= 18");
          t.HasCheckConstraint(name: "CK_Employee_Status", sql: "[Status] in ('Active', 'Inactive')");
          t.HasCheckConstraint(name: "CK_Employee_Gender", sql: "[Gender] in ('M', 'F', 'O')");
        });

      // DEPARTMENT
      modelBuilder.Entity<Department>().Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");

      // LEAVE
      modelBuilder.Entity<Leave>().Property(l => l.AppliedOn).HasDefaultValueSql("GETDATE()");

      // ANNOUNCEMENT
      modelBuilder.Entity<Announcement>().Property(l => l.CreatedOn).HasDefaultValueSql("GETDATE()");

      // ATTENDANCE
      modelBuilder.Entity<Attendance>()
        .Property(a => a.TotalHours)
        .HasComputedColumnSql(sql: "ISNULL(DATEDIFF(MINUTE, [CheckIn], [CheckOut]) / 60.0, 0)", stored: true);

      // USER LOGIN
      modelBuilder.Entity<UserLogin>().HasIndex(u => u.Username).IsUnique();

      //FOREIGN KEYS
      // EMPLOYEE
      // One Department to Many Employees
      modelBuilder.Entity<Employee>()
        .HasOne(e => e.Department)
        .WithMany(d => d.Employees)
        .HasForeignKey(e => e.DepartmentId)
        .OnDelete(DeleteBehavior.Restrict);

      // One Role to Many Employees
      modelBuilder.Entity<Employee>()
        .HasOne(e => e.Role)
        .WithMany(r => r.Employees)
        .HasForeignKey(e => e.RoleId)
        .OnDelete(DeleteBehavior.Restrict);

      // ATTENDANCE
      // One Employee to Many Attendances
      modelBuilder.Entity<Attendance>()
         .HasOne(a => a.Employee)
         .WithMany(e => e.Attendances)
         .HasForeignKey(a => a.EmpId)
         .OnDelete(DeleteBehavior.Restrict);

      // LEAVE
      // One Applicant Employee to Many Applied Leaves
      modelBuilder.Entity<Leave>()
        .HasOne(l => l.Applicant)
        .WithMany(e => e.AppliedLeaves)
        .HasForeignKey(l => l.EmpId)
        .OnDelete(DeleteBehavior.Restrict);

      // One Approver Employee to Many Approved Leaves
      modelBuilder.Entity<Leave>()
        .HasOne(l => l.Approver)
        .WithMany(e => e.ApprovedLeaves)
        .HasForeignKey(l => l.ApprovedBy)
        .OnDelete(DeleteBehavior.Restrict);

      // ANNOUNCEMENT
      // One Employee to Many Announcements
      modelBuilder.Entity<Announcement>()
        .HasOne(a => a.Creator)
        .WithMany(e => e.Announcements)
        .HasForeignKey(a => a.CreatedBy)
        .OnDelete(DeleteBehavior.Restrict);

      // PROJECT
      // One Client to Many Projects
      modelBuilder.Entity<Project>()
        .HasOne(p => p.Client)
        .WithMany(c => c.Projects)
        .HasForeignKey(p => p.ClientId)
        .OnDelete(DeleteBehavior.Restrict);

      // ALLOCATION
      // One Allocated Employee to Many Allocations
      modelBuilder.Entity<Allocation>()
        .HasOne(a => a.AllocatedEmployee)
        .WithMany(e => e.Allocations)
        .HasForeignKey(a => a.EmpId)
        .OnDelete(DeleteBehavior.Restrict);

      // One Allocated Project to Many Allocations
      modelBuilder.Entity<Allocation>()
        .HasOne(a => a.AllocatedProject)
        .WithMany(p => p.Allocations)
        .HasForeignKey(a => a.ProjectId)
        .OnDelete(DeleteBehavior.Restrict);

      // USER LOGIN
      // One Role to Many Users
      modelBuilder.Entity<UserLogin>()
        .HasOne(u => u.Role)
        .WithMany(r => r.Users)
        .HasForeignKey(u => u.RoleId)
        .OnDelete(DeleteBehavior.Restrict);
    }
  }
}