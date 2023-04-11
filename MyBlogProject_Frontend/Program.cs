using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using MyBlogProject_Frontend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("MyDatabase");
builder.Services.AddDbContext<ConsumerDbContext>(options => options.UseSqlServer(connectionString));
    ;
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

app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(
    //  name: "areas",
    //  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    //);

    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "{controller=Home}/{action=Index}/{Id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    

    //endpoints.MapAreaControllerRoute(
    //   name: "admin",
    //   areaName: "admin",
    //   pattern: "{controller=Category}/{action=Delete}/{Id?}");




});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
