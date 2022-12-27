using JobPortal.Data;
using JobPortal.Helpers;
using JobPortal.Helpers.Extensions;
using JobPortal.Helpers.Middleware;
using JobPortal.Helpers.Seeders;
using JobPortal.Repositories.UserRepository;
using JobPortal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// legam contextul de baza de date cu aplicatia noastra (PortalContext) 
builder.Services.AddDbContext<PortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRepository, UserRepository>();   // se creeaza de fiecare data cand se face request
//builder.Services.AddSingleton<IUserRepository, UserRepository>();   //  -||- la primul request
//builder.Services.AddScoped<IUserRepository, UserRepository>();      //-||- o singura data/request de la client
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSeeders();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<UserSeeder>();
        service.SeedInitialUsers();
    }
}