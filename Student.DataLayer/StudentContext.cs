using Microsoft.EntityFrameworkCore;

namespace Student.DataLayer
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
    }
}
