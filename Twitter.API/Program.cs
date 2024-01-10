using Microsoft.EntityFrameworkCore;
using Twitter.API;
using Twitter.Business;
using Twitter.DAL.Contexts;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Twitter.Core.Entities;
using Twitter.Core.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<TwitterContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
});
builder.Services.AddUserIdentity();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddBusinessLayer();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = builder.Configuration.GetSection("Jwt")["Issuer"],
                ValidAudience = builder.Configuration.GetSection("Jwt")["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt")["Key"])),
                LifetimeValidator = (nb, exp, token, _) => token != null ? exp >= DateTime.UtcNow && nb <= DateTime.UtcNow : false
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
app.Use(async (context, next) =>
{
    using (var scope = context.RequestServices.CreateScope())
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.Roles.AnyAsync())
        {
            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in result.Errors)
                    {
                        sb.Append(error.Description + " ");
                    }
                    throw new Exception(sb.ToString().TrimEnd());
                }
            }
        }
        if (await userManager.FindByNameAsync(app.Configuration.GetSection("Admin")["Username"]) == null)
        {
            var user = new AppUser
            {
                UserName = app.Configuration.GetSection("Admin")["Username"],
                Email = "admin@gmail.com",
                Name = "admin",
                Surname = "admin"
            }; 
            var result = await userManager.CreateAsync(user, app.Configuration.GetSection("Admin")["Password"]);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new Exception(sb.ToString().TrimEnd());
            }
            await userManager.AddToRoleAsync(user, nameof(Roles.Admin));
        }
    }
    await next();
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
