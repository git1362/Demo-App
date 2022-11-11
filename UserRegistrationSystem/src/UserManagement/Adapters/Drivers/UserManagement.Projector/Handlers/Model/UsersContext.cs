using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Projections.Sql.Handlers.Model
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=UserProjection;Persist Security Info=True;User ID=oddman;Password=oddman;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}