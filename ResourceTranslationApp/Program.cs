using System.Reflection;
using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Persistence;
using ResourceTranslationApp.Extensions;

namespace ResourceTranslationApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(option =>
                {
                    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Resource translation", Version = "v1" });
                    option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter a valid token",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        BearerFormat = "JWT",
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });
                    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id=JwtBearerDefaults.AuthenticationScheme
                                }
                            },
                            new string[]{}
                        }
                    });
                });

                builder.Services.AddAutoMapper(cfg =>
                {
                    cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                    cfg.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDBContext).Assembly));
                });

                builder.Services.AddPersistence(builder.Configuration);
                builder.Services.AddApplication(builder.Configuration);

                builder.Services.AddCors(x =>
                x.AddDefaultPolicy(y =>
                {
                    y.AllowAnyHeader();
                    y.AllowAnyMethod();
                    y.AllowAnyOrigin(); //TODO change to appsettings
                }));

                var app = builder
                    .UseSerilog(builder.Configuration)
                    .Build();
                    app.UseCustomMiddleware();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                    app.UseHttpsRedirection();
                    app.UseCors();
                    app.UseAuthentication();
                    app.UseAuthorization();
                    app.MapControllers();
                    app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
