namespace Common.Magic
{
    public interface IHave<TEntity>
    {
        TEntity Entity { get; }
    }

    public static class IHaveExtensions
    {
        public static T Entity<T>(this IHave<T> owner) => owner.Entity;
    }
}
