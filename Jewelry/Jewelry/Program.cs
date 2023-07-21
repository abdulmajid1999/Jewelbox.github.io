using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Jewelry.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JewelryContextConnection") ?? throw new InvalidOperationException("Connection string 'JewelryContextConnection' not found.");

builder.Services.AddDbContext<JewelryContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<JewelryContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Session Work

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(50);
    x.Cookie.IsEssential = true;
    
});

//Session End

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
//pattern: "{controller=Home}/{action=Index}/{id?}");
//pattern: "{controller=UserRegMsts}/{action=userlogin}/{id?}");
pattern: "{controller=user}/{action=Index}/{id?}");


app.Run();
