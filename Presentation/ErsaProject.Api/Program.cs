using ErsaProject.Api.Filters;
using ErsaProject.Application;
using ErsaProject.Infrastructure;
using ErsaProject.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddAplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<RolePermissionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin",options =>
{
    options.TokenValidationParameters = new() { 
        ValidateAudience = true , //token degerini kimlerin/hangi originlerin / sitelerin kullancagını belirler
        ValidateIssuer=true,//token degerini kimin dağıttıgını ifade eder
        ValidateLifetime=true, // token süresini kontrol eder
        ValidateIssuerSigningKey=true, // token uygulamamıza ait bir deger oldugunu ifade eder
        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer=builder.Configuration["Token:Issuer"],
        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),//simetrik key
        LifetimeValidator=(notBefore,expires,securityToken,validationParameters) =>expires!=null? expires>DateTime.UtcNow:false,//token süresi gectiginde false dönecek yetki düşecek 401 dönecek
        NameClaimType=ClaimTypes.Name, // Jwt üzerinde name claimne karşılık gelen değeri user.identity.name propertysinden elde ediyor
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
