﻿using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Business.ExtarnelServices.Implements;
using Twitter.Business.ExtarnelServices.Interfaces;
using Twitter.Business.Profiles;
using Twitter.Business.Repositories.Implements;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Implements;
using Twitter.Business.Services.Interfaces;

namespace Twitter.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPostService, PostService>();
            return services;
        }
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<TopicCreateDtoValidator>());
            services.AddAutoMapper(typeof(TopicMappingProfile).Assembly);
            services.AddAutoMapper(typeof(PostMappingProfile).Assembly);
            return services;
        }
    }
}
