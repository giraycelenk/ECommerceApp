using ECommerceApp.Data.Abstract;
using ECommerceApp.Data.Concrete;
using ECommerceApp.Web.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<ECommerceDbContext>(options => {
    options.UseSqlite(builder.Configuration["ConnectionStrings:ECommerceDbConnection"], b => b.MigrationsAssembly("ECommerceApp.Web"));
});

builder.Services.AddScoped<IECommerceRepository, EfECommerceRepository>();
builder.Services.AddSession();

var app = builder.Build();


app.UseStaticFiles();
app.UseSession();


app.MapControllerRoute("product_in_category","products/{category?}",new { controller="Home", action = "Index" });

app.MapControllerRoute("product_details","{product_name}",new { controller="Home", action = "Details" });

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
