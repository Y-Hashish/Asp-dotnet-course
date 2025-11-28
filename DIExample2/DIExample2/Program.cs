using ServiceContracts;
using Services;

namespace DIExample2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            /* the same instance is created once cross the request
             even if we use the service or inject it multiple times
            and every request it changes*/
            builder.Services.AddScoped<ICitiesService, CitiesServices>();

            // the instance is changed  it we use the service or inject it multiple times 
            //builder.Services.AddTransient<ICitiesService, CitiesServices>();


            /*the instance is the same at every request and doesn't change 
             across the requests */
            //builder.Services.AddSingleton<ICitiesService, CitiesServices>();
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
