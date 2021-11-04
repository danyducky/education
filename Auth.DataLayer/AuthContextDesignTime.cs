using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Auth.DataLayer
{
    public class AuthContextDesignTime : IDesignTimeDbContextFactory<AuthContext>
    {
        public AuthContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=edu_auth;Username=postgres;Password=1");

            return new AuthContext(optionsBuilder.Options);
        }
    }
}
