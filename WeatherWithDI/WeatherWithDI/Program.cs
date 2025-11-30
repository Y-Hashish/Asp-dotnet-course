using WeatherWithDI.Services;

namespace WeatherWithDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICityService, CityService>();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers(); 

            app.Run();
        }
    }
}
