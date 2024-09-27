using ECommerceApp.Data.Abstract;
using ECommerceApp.Data.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ECommerceDbContext>(options => {
    options.UseSqlite(builder.Configuration["ConnectionStrings:ECommerceDbConnection"], b => b.MigrationsAssembly("ECommerceApp.Web"));
});

builder.Services.AddScoped<IECommerceRepository, EfECommerceRepository>();

var app = builder.Build();


app.UseStaticFiles();


app.MapControllerRoute("product_in_category","products/{category?}",new { controller="Home", action = "Index" });

app.MapControllerRoute("product_details","{product_name}",new { controller="Home", action = "Details" });

app.MapDefaultControllerRoute();

app.Run();
