using ReturnTrue.AspNetCore.Identity.Anonymous;

namespace Anonymous_Identity_Tracker_Middleware_Integration
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)

        {

            _ = app.UseRouting();


            _ = app.UseAnonymousId(new AnonymousIdCookieOptionsBuilder()

                .SetCustomCookieName("Anonymous_Cookie_Tracker")

                //.SetCustomCookieRequireSsl(true) // Uncomment in case of using SSL

                .SetCustomCookieTimeout(120)

            );


            _ = app.UseEndpoints(endpoints =>

            {

                _ = endpoints.MapGet("/", async context =>

                {

                    IAnonymousIdFeature feature = context.Features.Get<IAnonymousIdFeature>();

                    string anonymousId = feature.AnonymousId;


                    await context.Response.WriteAsync($"Hello world with anonymous id {anonymousId}");

                });

            });

        }
    }
}
