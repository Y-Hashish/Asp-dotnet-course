namespace ConfigurationExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/config", async context =>
                {
                    await context.Response.WriteAsync(app.Configuration["myKey"]+"\n");
                    await context.Response.WriteAsync(app.Configuration.GetValue<string>("myKey") + "\n");
                    await context.Response.WriteAsync(app.Configuration.GetValue<string>("myKeys","nigga chill"));
                    
                });
            });
            app.MapControllers();

            app.Run();
        }
    }
}
