using IdentityServer4.Models;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("UserApi.read"), new ApiScope("UserApi.write")};

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("UserApi")
                {
                    Scopes = new List<string> {"UserApi.read", "UserApi.write" },
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"role" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credential Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ClientSecret1".Sha256())},
                    AllowedScopes = {"UserApi.read", "UserApi.write"}
                },
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = {new Secret("ClientSecret1".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"http://localhost:5205/signin-oidc"},
                    FrontChannelLogoutUri = "http://localhost:5205/signout-oidc",
                    PostLogoutRedirectUris = {"http://localhost:5205/signout-callback-oidc"},
                    AllowOfflineAccess = true,
                    AllowedScopes = {"openid", "profile", "UserApi.read" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false

                }
            };


    }
}
