using JobPortal.Data;
using JobPortal.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using JobPortal.Repositories;
using JobPortal.Repositories.UnitOfWork;
using JobPortal.Services;
using JobPortal.Helpers;
using JobPortal.Helpers.Extensions;
using JobPortal.Helpers.JwtUtils;
using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);

// legam contextul de baza de date cu aplicatia noastra (PortalContext) 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PortalContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSeeders();

//transient => se creeze de fiecare cand se face un request
//scoped => se creeaza o singura data pe request
//singleton => se creeaza o singura data pe aplicatie

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddEndpointsApiExplorer();

// Add authentication scheme
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:Token").Value!))

    };
});

builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// cand se face request, trecem prin fiecare middleware !conteaza ordinea
// pentru response => ordine inversa
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();


void SeedData(IHost app) // se ruleaza la inceput cand nu ai nimic in tabela
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<UserSeeder>(); // luam serviciile inregistrate
        seeder.SeedInitialUsers();
    }
}
