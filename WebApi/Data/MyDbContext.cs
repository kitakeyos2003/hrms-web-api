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
        public DbSet<DepartmentEntity> Department { get; set; }
    }
}
