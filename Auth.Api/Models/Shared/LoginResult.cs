using Auth.Shared.Models;
using System;

namespace Auth.Api.Models.Shared
{
    public class LoginResult
    {
        public TokenPack Pack { get; }

        public bool IsValid { get => Pack != null; }

        public static LoginResult Invalid => InvalidResult;
        public static LoginResult Valid(TokenPack pack) => ValidResult(pack);

        public LoginResult(TokenPack pack)
        {
            Pack = pack;
        }

        private static readonly LoginResult InvalidResult = new(null);
        private static LoginResult ValidResult(TokenPack pack) => new(pack);
    }
}
