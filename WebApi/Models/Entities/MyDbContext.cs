using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<AttendanceEntity> Attendances { get; set; }
        public DbSet<CandidateEntity> Candidates { get; set; }
        public DbSet<ContractEntity> Contracts { get; set; }
        public DbSet<EvaluateEntity> Evaluations { get; set; }
        public DbSet<SalaryEntity> Salarys { get; set;}
    }
}
