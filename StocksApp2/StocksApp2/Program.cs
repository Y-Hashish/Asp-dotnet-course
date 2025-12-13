using StocksApp2.Services;

namespace StocksApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IFinnHub,FinnHubService>();
            builder.Services.AddHttpClient();

            var app = builder.Build();


            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
