using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
                options.LoginPath = "/Login/Login"

    )
    ;

builder.Services.AddSession();


#region DI
builder.Services.AddHttpClient<IServiceHelper, ServiceHelper>();
builder.Services.AddScoped<IServiceHelper, ServiceHelper>();
builder.Services.AddScoped<ICategoryHelper, CategoryHelper>();
builder.Services.AddScoped<IProductHelper, ProductHelper>();
builder.Services.AddScoped<ISupplierHelper, SupplierHelper>();
builder.Services.AddScoped<ISecurityHelper, SecurityHelper>();
builder.Services.AddScoped<IUserHelper, UserHelper>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
