using SocialMediaLinks.Services;

namespace SocialMediaLinks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ISocial, SocialService>();
            builder.Services.Configure<SocialApi>
                (builder.Configuration.GetSection("SocialMediaLinks"));

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
