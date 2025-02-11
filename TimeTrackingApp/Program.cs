using DTO;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using System.Windows.Forms;
using System;
using TimeKeeping.DI_Factory;
using TimeKeeping.Users;

namespace TimeKeeping
{
    internal static class Program
    {
        // Global Service Provider
        private static IServiceProvider _serviceProvider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            // Apply migrations at startup
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
                using var dbContext = dbContextFactory.CreateDbContext();
                dbContext.Database.Migrate();  // Automatically apply any pending migrations
            }


            // Start the main form with DI
            var mainForm = _serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Creating factory for the classes that need to be created and not used as singleton
            services.AddTransient(typeof(IFactory<>), typeof(Factory<>));

            // Adding AutoMapper to dependecy injection
            services.AddAutoMapper(typeof(MappingProfile));

            #region Foms
            services.AddSingleton<MainForm>();
            services.AddTransient<UsersList>();
            services.AddTransient<UserForm>();
            #endregion

            #region DBContext
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

            string connectionString = configuration.GetConnectionString("AppDbContext");

            // Register IDbContextFactory instead of AddDbContext
            services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(connectionString));
            #endregion

            #region Repositories
            services.AddSingleton<IRepository<User>, Repository<User>>();
            services.AddSingleton<IRepository<TimeEntry>, Repository<TimeEntry>>();
            #endregion

            #region Services
            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<ITimeEntryService, TimeEntryService>();
            #endregion
        }
    }
}