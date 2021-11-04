using Common.Magic;
using Education.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Education.DataLayer
{
    public class EducationContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupRequest> GroupRequests { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Student> Students { get; set; }

        public EducationContext(DbContextOptions<EducationContext> options) : base(options) { }
    }

    public static class EducationContextExtensions
    {
        public static IQueryable<TEntity> Get<TEntity>(this IHave<EducationContext> context)
            where TEntity : class, IEducationEntity
        {
            return context.Entity.Set<TEntity>().AsNoTracking();
        }

        public static void Attach<TEntity>(this IHave<EducationContext> context, TEntity entity)
            where TEntity : class, IEducationEntity
        {
            var entry = context.Entity.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Unchanged;
            }
        }

        public static void Add<TEntity>(this IHave<EducationContext> context, TEntity entity)
            where TEntity : class, IEducationEntity
        {
            context.Entity.Entry(entity).State = EntityState.Added;
        }

        public static void Remove<TEntity>(this IHave<EducationContext> context, TEntity entity)
            where TEntity : class, IEducationEntity
        {
            context.Entity.Entry(entity).State = EntityState.Deleted;
        }
    }
}
