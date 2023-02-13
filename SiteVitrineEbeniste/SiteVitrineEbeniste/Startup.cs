using Microsoft.AspNetCore.Builder;

namespace SiteVitrineEbeniste
{
    public static class Startup
    {
        public static void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
        public static WebApplication InitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void Configure(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
        }
    }
}


