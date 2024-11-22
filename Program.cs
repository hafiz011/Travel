using Flyjaatra.BbContext;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using AspNetCore.Identity.MongoDbCore.Extensions;
using Flyjaatra.IdentityModels;


var builder = WebApplication.CreateBuilder(args);

// Configure your custom MongoDbSettings
builder.Services.Configure<Flyjaatra.BbContext.MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<Flyjaatra.BbContext.MongoDbSettings>();



// Add Identity with MongoDB store using the Identity MongoDbSettings
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(
        mongoDbSettings.ConnectionString,
        mongoDbSettings.DatabaseName)
    .AddDefaultTokenProviders();

// Add MVC
builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages();


// Register custom repositories
//builder.Services.AddSingleton<ServiceItemRepository>();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
