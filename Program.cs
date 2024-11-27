using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using OTD.MappingService.ConfigUI;
using OTD.MappingService.ConfigUI.Constants;
using OTD.MappingService.ConfigUI.Handlers;
using OTD.MappingService.ConfigUI.Services;
using OTD.MappingService.ConfigUI.Services.API;
using Refit;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddMudServices();
        builder.Services.AddBlazoredLocalStorage();

        builder.Services.AddOidcAuthentication(options =>
        {
            options.ProviderOptions.AdditionalProviderParameters.Add("audience", Settings.Auth0.Audience);
            options.ProviderOptions.AdditionalProviderParameters.Add("organization", Settings.Auth0.Organisation);
            options.ProviderOptions.AdditionalProviderParameters.Add("prompt", "select_account");
            options.ProviderOptions.ClientId = Settings.Auth0.ClientId;
            options.ProviderOptions.Authority = Settings.Auth0.Domain;
            options.ProviderOptions.DefaultScopes.Add("email");
            options.ProviderOptions.DefaultScopes.Add("offline_access");
            options.ProviderOptions.DefaultScopes.Add("openid");
            options.ProviderOptions.DefaultScopes.Add("profile");
            options.ProviderOptions.ResponseType = "code";
        });

        Uri mappingServiceBase = new Uri(Settings.MappingService.BaseURL);

        builder.Services.AddTransient<ITokenStorageService, TokenStorageService>();
        builder.Services.AddTransient<ApiAuthHeaderHandler>();
        builder.Services.AddRefitClient<IAppInstanceConfigService>()
            .ConfigureHttpClient(c => c.BaseAddress = mappingServiceBase)
            .AddHttpMessageHandler<ApiAuthHeaderHandler>()
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        builder.Services.AddRefitClient<IMappingModelConfigService>()
            .ConfigureHttpClient(c => c.BaseAddress = mappingServiceBase)
            .AddHttpMessageHandler<ApiAuthHeaderHandler>()
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        builder.Services.AddRefitClient<ITransformationConfigService>()
            .ConfigureHttpClient(c => c.BaseAddress = mappingServiceBase)
            .AddHttpMessageHandler<ApiAuthHeaderHandler>()
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        builder.Services.AddRefitClient<ITransformationFlowConfigService>()
            .ConfigureHttpClient(c => c.BaseAddress = mappingServiceBase)
            .AddHttpMessageHandler<ApiAuthHeaderHandler>()
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        await builder.Build().RunAsync();
    }
}