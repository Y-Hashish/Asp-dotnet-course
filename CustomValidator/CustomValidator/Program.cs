using CustomValidator.CustomModelBinding;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Insert(0, new PersonBindingProvider());
}).AddXmlSerializerFormatters();
var app = builder.Build();

app.UseStaticFiles();   
app.UseRouting();
app.MapControllers();

 
app.Run();
