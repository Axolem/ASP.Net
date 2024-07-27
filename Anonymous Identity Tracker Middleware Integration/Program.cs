using ReturnTrue.AspNetCore.Identity.Anonymous;

namespace Anonymous_Identity_Tracker_Middleware_Integration

{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            //builder.Services.AddControllersWithViews();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.Run();

            var app = WebApplication.Create();

            app.UseAnonymousId(new AnonymousIdCookieOptionsBuilder()

                .SetCustomCookieName("Anoymous_Cookie_Tracker")

                //.SetCustomCookieRequireSsl(true) //Uncomment this in the case of usign SSL, such as the default setup of .NET Core 2.1 

                .SetCustomCookieTimeout(120)

            );

            app.Run(async context =>

            {

                IAnonymousIdFeature feature = context.Features.Get<IAnonymousIdFeature>();

                string anonymousId = feature.AnonymousId;

                await context.Response.WriteAsync($"Hello world with anonymous id {anonymousId}");

            });

            app.Run();
        }
    }
}
