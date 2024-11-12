using Application.Interfaces;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Seeders;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static async Task<IServiceCollection> AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());

            //services.AddAutoMigrate();

            await services.AddInfrastructure(configuration);

            return services;
        }

        private static void AddAutoMigrate(this IServiceCollection services)
        {
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                try
                {
                    scope.ServiceProvider.GetRequiredService<ApplicationDBContext>().Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private static async Task<IServiceCollection> AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>(opt =>
            {

            })
            .AddEntityFrameworkStores<ApplicationDBContext>();
            await services.AddSeeders(configuration);
            return services;
        }

        private static async Task AddSeeders(this IServiceCollection services, IConfiguration configuration)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var context = serviceProvider.GetRequiredService<ApplicationDBContext>();
                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
                await new RolesSeeder(roleManager).Seed();
                await new UserSeeder(userManager, roleManager, configuration).Seed();
                await new ClaimsSeeder(userManager, roleManager).Seed();
                await context.SaveChangesAsync();
            }
        }
    }
}
