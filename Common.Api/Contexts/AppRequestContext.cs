using Auth.DataLayer;
using Auth.Shared.Services;
using Common.Magic;
using Education.DataLayer;

namespace Common.Api.Contexts
{
    public class AppRequestContext : IAppRequestContext,
        IHave<AuthContext>,
        IHave<EducationContext>,

        IHave<ICurrentUserProvider>
    {
        private readonly AuthContext authContext;
        private readonly EducationContext educationContext;
        private readonly ICurrentUserProvider currentUserProvider;

        public AppRequestContext(AuthContext authContext,
                                 EducationContext educationContext,

                                 ICurrentUserProvider currentUserProvider)
        {
            this.authContext = authContext;
            this.educationContext = educationContext;
            this.currentUserProvider = currentUserProvider;
        }

        AuthContext IHave<AuthContext>.Entity => authContext;

        EducationContext IHave<EducationContext>.Entity => educationContext;

        ICurrentUserProvider IHave<ICurrentUserProvider>.Entity => currentUserProvider;

        public void SaveChanges()
        {
            authContext.SaveChanges();
            educationContext.SaveChanges();
        }
    }
}
