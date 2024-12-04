namespace OTD.MappingService.ConfigUI.Handlers
{
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using OTD.MappingService.ConfigUI.Services;
    using System.Net.Http.Headers;

    public class ApiAuthHeaderHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider TokenProvider;
        private readonly ITokenStorageService tokenStorage;

        public ApiAuthHeaderHandler(IAccessTokenProvider TokenProvider, ITokenStorageService tokenStorage)
        {
            this.TokenProvider = TokenProvider;
            this.tokenStorage = tokenStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AccessToken? token = await tokenStorage.GetToken();
            if (token is null || token.Expires <= DateTimeOffset.UtcNow)
            {
                AccessTokenResult accessTokenResult = await TokenProvider.RequestAccessToken();
                if (accessTokenResult.TryGetToken(out token))
                {
                    this.tokenStorage.SetToken(token);
                }
            }

            if (token is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
