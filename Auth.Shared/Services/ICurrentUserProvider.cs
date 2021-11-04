using Auth.Shared.Models;
using Common.Magic;

namespace Auth.Shared.Services
{
    public interface ICurrentUserProvider
    {
        CurrentUserModel CurrentUser { get; }
    }

    public static class CurrentUserProviderExtensions
    {
        public static CurrentUserModel GetCurrentUser(this IHave<ICurrentUserProvider> context)
            => context.Entity.CurrentUser;
    }
}
