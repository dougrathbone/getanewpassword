using GANP.Website.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddXmlSerializerFormatters(); // API returns JSON or XML depending on the Accept header

builder.Services.AddSingleton<IFileOperationService, FileOperationService>();
builder.Services.AddSingleton<IFilePathService, ContentRootFilePathService>();
builder.Services.AddSingleton<IGeneratePasswordService, GeneratePasswordService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program { }
