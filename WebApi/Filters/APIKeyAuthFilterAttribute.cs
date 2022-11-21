using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    public class APIKeyAuthFilterAttribute : Attribute, IAuthorizationFilter
    {
        private const string apiKeyHeader = "ApiKey";
        private const string ClientIdHeader = "ClientId";
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ClientIdHeader, out var clientId))
            {
                context.Result = new UnauthorizedResult();
            }
            
            if (!context.HttpContext.Request.Headers.TryGetValue(apiKeyHeader, out var clientApiKey))
            {
                context.Result = new UnauthorizedResult();
            }

            var config = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration; 
            var apiKey = config.GetValue<string>($"ApiKey:{clientId}");

            if (apiKey != clientApiKey)
                context.Result = new UnauthorizedResult();
        }
    }
    
}