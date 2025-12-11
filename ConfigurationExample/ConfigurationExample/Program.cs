namespace ConfigurationExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.Configure<PersonApiOptions>
                (builder.Configuration.GetSection("person"));

            builder.Configuration
                .AddJsonFile("MyAppSetting.json", optional: true, reloadOnChange: true);

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
