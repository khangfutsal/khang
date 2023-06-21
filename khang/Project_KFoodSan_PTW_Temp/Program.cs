using Microsoft.EntityFrameworkCore;
using Project_KFoodSan_PTW_Temp.Models;
using Project_KFoodSan_PTW_Temp.Reposistory;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<KfoodSanContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("KFoodSanDB"));

});
builder.Services.AddTransient<ICategoryReposistory, CategoryReposistory>();
builder.Services.AddTransient<IUserReposistory, UserReposistory>();
builder.Services.AddTransient<IFoodReposistory, FoodReposistory>();
builder.Services.AddTransient<IRoleReposistory, RoleReposistory>();
builder.Services.AddTransient<IOrderBookReposistory, OrderBookReposistory>();
builder.Services.AddTransient<ICountryReposistory, CountryReposistory>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapAreaControllerRoute(
     name: "MyAreas",
     areaName: "Admin",
     pattern: "Admin/{controller}/{action}/{id?}",
     defaults: new { controller = "Home", action = "Index" }
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
