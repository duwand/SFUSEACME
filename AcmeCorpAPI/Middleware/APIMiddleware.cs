using Microsoft.AspNetCore.Mvc;

namespace AcmeCorpAPI.Middleware
{
    public class APIMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEY = "ApiKey";

        public APIMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out var headers))
            {
                await context.Response.WriteAsync("API key was not provided (custom).");
                return;
            }

            var appSetting = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSetting.GetValue<string>(APIKEY);

            if (!apiKey.Equals(headers))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("UnAuthorized (custom)");
                return;
            }
            await _next(context);
        }

    }
}
