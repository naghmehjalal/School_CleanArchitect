using Microsoft.Extensions.Configuration;
using System.Reflection;
using WebApp.Contracts;
using WebApp.Contracts.IService_Course;
using WebApp.Services;
using WebApp.Services.Base;
using WebApp.Services.Service_Course;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IClient, Client>(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    //var clientCredentialProvider = sp.GetRequiredService<IClient>();
    var baseUrl = builder.Configuration.GetSection("ApiAddress:Url").Value;
    return new Client(baseUrl, httpClientFactory.CreateClient());
    //{
    //    ClientCredentialProvider = clientCredentialProvider
    //};
});

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ICourseGroupService, CourseGroupService>();

//--------------------------------------------------------------------------
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


