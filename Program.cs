using DataAccess_lib.Internal.DataAccess;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using SmartSchool.BLL.Repo;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

// The path that would contain the vocabulary data
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add the localization for the app
builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<ILessonRepo, LessonRepo>();
builder.Services.AddScoped<ISubjectsRepo, SubjectsRepo>();
builder.Services.AddScoped<IClassesRepo, ClassesRepo>();
builder.Services.AddScoped<IUsersRepo, UsersRepo>();


// Define which languages to support
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var SupportedCultures = new[]
    {
          new CultureInfo("en"),
          new CultureInfo("ar")
     };

    options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
    options.SupportedCultures = SupportedCultures;
    options.SupportedUICultures = SupportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

var options = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(options.Value);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(@"D:\Repos\MoviesStore\wwwroot", "Images")),
    RequestPath = "/Images"
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
