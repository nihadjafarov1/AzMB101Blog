using Microsoft.AspNetCore.Identity;
using Twitter.Core.Entities;
using Twitter.DAL.Contexts;

namespace Twitter.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 4;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<TwitterContext>();
            return services;
        }
    }
}
