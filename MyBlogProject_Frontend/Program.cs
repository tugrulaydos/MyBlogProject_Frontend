using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using MyBlogProject_Frontend.Areas.Validations.LoginValidator;
using MyBlogProject_Frontend.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<LoginValidator>();
    x.DisableDataAnnotationsValidation = true;
    x.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("tr"); 
});

var connectionString = builder.Configuration.GetConnectionString("MyDatabase");
builder.Services.AddDbContext<ConsumerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSession();


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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "areaDefault",
        pattern: "{area:exists}/{controller=Authentication}/{action=Login}/{id?}"
        );

    //endpoints.MapAreaControllerRoute(
    //   name: "admin",
    //   areaName: "admin",
    //   pattern: "admin/{controller=Authentication}/{action=Login}");


    endpoints.MapControllerRoute(
        name: "default",
        pattern:"{controller=HomePage}/{action=Index}/{id?}"); 
   

});


app.Run();
