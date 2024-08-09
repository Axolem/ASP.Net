namespace uniapi.Middlewares
{
    public class APIKeyMiddleware : IMiddleware
    {

        private readonly string _apiKey = "123456";
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            if (context.Request.Path.StartsWithSegments("/api") && context.Request.Headers.TryGetValue("X-API-KEY", out Microsoft.Extensions.Primitives.StringValues extractedApiKey))
            {
                // Validate the API key
                if (extractedApiKey == _apiKey)
                {
                    // Call the next delegate/middleware in the pipeline
                    await next(context);
                    return;
                }
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}
