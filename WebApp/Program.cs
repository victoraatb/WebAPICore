using App.Repository.ApiClient;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyApp.ApplicationLogic;
using MyApp.Repository;
using WebApp;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<WebApp.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddOptions();
//builder.Services.AddAuthorizationCore();
//builder.Services.AddSingleton<AuthenticationStateProvider, CustomTokenAuthenticationStateProvider>();

//builder.Services.AddSingleton<ITokenRepository, TokenRepository>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("WebAPI"));

builder.Services.AddHttpClient(
        "WebAPI",
        client => client.BaseAddress = new Uri("https://localhost:44304"))
    .AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddTransient<AuthorizationMessageHandler>(
    sp =>
    {
        var provider = sp.GetRequiredService<IAccessTokenProvider>();
        var naviManager = sp.GetRequiredService<NavigationManager>();

        var handler = new AuthorizationMessageHandler(provider, naviManager);
        handler.ConfigureHandler(authorizedUrls: new[]
        {
            "https://localhost:44304"
        });
        return handler;
    });

builder.Services.AddSingleton<IWebApiExecuter, WebApiExecuter>();

//builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
//builder.Services.AddTransient<IAuthenticationUseCases, AuthenticationUseCases>();
builder.Services.AddTransient<IProjectsScreenUseCases, ProjectsScreenUseCases>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<ITicketsScreenUseCases, TicketsScreenUseCases>();
builder.Services.AddTransient<ITicketScreenUseCases, TicketScreenUseCases>();

/*
builder.Services.AddOidcAuthentication(opt =>
{
    builder.Configuration.Bind("Local", opt.ProviderOptions);
    opt.ProviderOptions.DefaultScopes.Add("webapi");
});
*/

builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("oidc", options.ProviderOptions);

    options.ProviderOptions.DefaultScopes.Add("webapi");                
});

await builder.Build().RunAsync();
