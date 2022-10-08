using Assignment_12_1.Models;
using Assignment_12_1.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IproductRepository, ProductRepository>();
builder.Services.AddScoped<IproductRepository, DBCRUDRepository>();
builder.Services.AddScoped<iFileUpload, FileUpload>();
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlite("Data Source = Productdb.db"));
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<UserContext>();
builder.Services.AddDbContext<UserContext>(options => options.UseSqlite("Data Source = Users.db"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
if(app.Environment.IsStaging())
{
    app.UseExceptionHandler("Home/StagingError");
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductContext>();
    dbContext.Database.EnsureCreated();
    var userdbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
    userdbContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
