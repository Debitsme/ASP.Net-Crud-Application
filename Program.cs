using MyApp.Data;
using MyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;


var builder = WebApplication.CreateBuilder(args);
// intialize the web application instnace of the builder class


// Add services to the dependency injection container.
//alllow out application to handle http request and render html views
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyAppContext>(options => options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));
//doing dependency injection
//we are telling the application to use the connection string from the appsettings.json file
//"I’m using Entity Framework Core." "I want to connect to a SQL Server database."
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));

//Identity is a built-in membership system that handles authentication, authorization, and user management features
//we are adding identity to our application
//users is the model class that we created
//IdentityRole represents a role (e.g., Admin, User, etc.)--from .net identity service.
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//Tells Identity to use AppDbContext for its data storage.

//I could use (users) as for custom class with predefined properties
// (IdentityUser) is the default implementation provided by ASP.NET Core Identity. after migration it will define this based on build in properties
// It contains all the standard properties needed for authentication and authorization, such as:
//UserName
//Email
//PasswordHash
//SecurityStamp
//PhoneNumber

//more explanation
//Identity includes middleware, services, and data models that handle:

//1--Hashing and verifying passwords
//2-- Generating and validating authentication cookies
//3-- Managing roles and claims
//4--Securely storing sensitive user data



var app = builder.Build();//compiling the applicatroin


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//enable routing to allow the incoming http request to be routed to the correct controller
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
//serve static files like images, css, js files from www root folder

 

//default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")   //every url have this patter. action is the method of the controller. id is optional
    .WithStaticAssets();
//if not controller or action is specified it would take the default home and action index

app.Run();

//this line starts the application

