using BookMyShowApi.Data;
using Microsoft.EntityFrameworkCore;
using BookMyShowApi.Repository;
using BookMyShowApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAppRepository, AppRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

var key =Encoding.UTF8.GetBytes("1234567891234567");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x=>
{
    x.RequireHttpsMetadata= false;
    x.SaveToken = false;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
       ValidateIssuerSigningKey=true,
       IssuerSigningKey= new SymmetricSecurityKey(key),
       ValidateIssuer=false,
       ValidateAudience=false,
       ClockSkew=TimeSpan.Zero,
    };
});
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric=false;
    options.Password.RequireDigit=false;
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase=false;
    options.Password.RequireLowercase=false;
});

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

//app.UseStaticFiles();

app.MapControllers();

app.Run();
