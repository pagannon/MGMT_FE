namespace OTD.MappingService.ConfigUI.Services
{
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

    public interface ITokenStorageService
    {
        Task<AccessToken> GetToken();
        void SetToken(AccessToken token);
    }

    public class TokenStorageService : ITokenStorageService
    {
        private readonly ILocalStorageService localStorage;
        private const string storageKey = "TOKENSTORAGE";

        public TokenStorageService(ILocalStorageService LocalStorage)
        {
            this.localStorage = LocalStorage;
        }

        public async void SetToken(AccessToken token)
        {
            await this.localStorage.SetItemAsync<AccessToken>(storageKey, token);
        }

        public async Task<AccessToken?> GetToken()
        {
            return await this.localStorage.GetItemAsync<AccessToken>(storageKey);
        }
    }
}
