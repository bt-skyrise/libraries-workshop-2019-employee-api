using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Builder;

namespace Workshop2019.EmployeeApi
{
    public static class ApiKeyAuthorization
    {
        public static void UseApiKeyAuthorization(this IApplicationBuilder app, string apiKey)
        {
            app.Use(async (context, next) =>
            {
                var requestApiKeyOrNull = context.Request.Headers["ApiKey"].FirstOrDefault();

                if (requestApiKeyOrNull != null && requestApiKeyOrNull == apiKey)
                {
                    await next();
                }
                else
                {
                    context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                }
            });
        }
    }
}