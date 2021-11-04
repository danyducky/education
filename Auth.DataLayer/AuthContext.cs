using Auth.DataLayer.Entities;
using Common.Magic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Auth.DataLayer
{
    public class AuthContext : DbContext
    {
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleBindings> ModuleBindings { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credential>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<ModuleBindings>()
                .HasKey(x => new { x.ModuleId, x.RoleId });
        }
    }

    public static class AuthContextExtensions
    {
        public static IQueryable<TEntity> Get<TEntity>(this IHave<AuthContext> context)
            where TEntity : class, IAuthEntity
        {
            return context.Entity.Set<TEntity>().AsNoTracking();
        }

        public static void Attach<TEntity>(this IHave<AuthContext> context, TEntity entity)
            where TEntity : class, IAuthEntity
        {
            var entry = context.Entity.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Unchanged;
            }
        }

        public static void Add<TEntity>(this IHave<AuthContext> context, TEntity entity)
            where TEntity : class, IAuthEntity
        {
            context.Entity.Entry(entity).State = EntityState.Added;
        }

        public static void Remove<TEntity>(this IHave<AuthContext> context, TEntity entity)
            where TEntity : class, IAuthEntity
        {
            context.Entity.Entry(entity).State = EntityState.Deleted;
        }
    }
}
