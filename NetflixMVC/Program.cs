using DAL.DAL;
using DAL.Extention;
using Interfaces.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;
using DAL.Repository;
using DAL.GeneralClass;
using BusinesLogic.LayerExtention;
using DAL.Entities.User;
using Microsoft.AspNetCore.Identity;

using DAL.Utilites;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDataLayerExtention(builder.Configuration);
builder.Services.AddServiceLayerExtention();



//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddScoped<IBaseRepository<Actor>, BaseRepository<Actor>>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 6;
    opt.User.RequireUniqueEmail = true;
    
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();




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
app.UseAuthentication();

//app.UseMiddleware<AccountLimitMiddleware>();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
