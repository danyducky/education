using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Education.DataLayer
{
    public class EducationContextDesignTime : IDesignTimeDbContextFactory<EducationContext>
    {
        public EducationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EducationContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=edu_education;Username=postgres;Password=1");

            return new EducationContext(optionsBuilder.Options);
        }
    }
}
