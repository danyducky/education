using Auth.DataLayer;
using Auth.DataLayer.Factories;
using Auth.Shared.Services;
using Common.Magic;
using Common.Services;
using Microsoft.AspNetCore.Http;

namespace Auth.Api.Contexts
{
    public class AppRequestContext : IAppRequestContext,
        IHave<AuthContext>,

        IHave<IHttpContextAccessor>,

        IHave<IDataCryptor>, IHave<IDataHasher>,
        IHave<ITokenService>,
        IHave<ICurrentUserProvider>,

        IHave<IUserFactory>, IHave<IPersonFactory>, IHave<ICredentialFactory>
    {
        private readonly AuthContext authContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDataCryptor dataCryptor;
        private readonly IDataHasher dataHasher;
        private readonly ITokenService tokenService;
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly IUserFactory userFactory;
        private readonly IPersonFactory personFactory;
        private readonly ICredentialFactory credentialFactory;

        public AppRequestContext(AuthContext authContext,

                                 IHttpContextAccessor httpContextAccessor,

                                 IDataCryptor dataCryptor,
                                 IDataHasher dataHasher,
                                 ITokenService tokenService,
                                 ICurrentUserProvider currentUserProvider,

                                 IUserFactory userFactory,
                                 IPersonFactory personFactory,
                                 ICredentialFactory credentialFactory)
        {
            this.authContext = authContext;
            this.httpContextAccessor = httpContextAccessor;
            this.dataCryptor = dataCryptor;
            this.dataHasher = dataHasher;
            this.tokenService = tokenService;
            this.currentUserProvider = currentUserProvider;
            this.userFactory = userFactory;
            this.personFactory = personFactory;
            this.credentialFactory = credentialFactory;
        }

        AuthContext IHave<AuthContext>.Entity => authContext;

        IDataHasher IHave<IDataHasher>.Entity => dataHasher;

        IDataCryptor IHave<IDataCryptor>.Entity => dataCryptor;

        IUserFactory IHave<IUserFactory>.Entity => userFactory;

        IPersonFactory IHave<IPersonFactory>.Entity => personFactory;

        ICredentialFactory IHave<ICredentialFactory>.Entity => credentialFactory;

        ITokenService IHave<ITokenService>.Entity => tokenService;

        IHttpContextAccessor IHave<IHttpContextAccessor>.Entity => httpContextAccessor;

        ICurrentUserProvider IHave<ICurrentUserProvider>.Entity => currentUserProvider;

        public void SaveChanges()
        {
            authContext.SaveChanges();
        }
    }
}
