using DIFactory;
using DTO;
using Entity;
using ExcelGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using System;
using System.IO;
using System.Windows;
using TimeTracking.Users;
using TimeTrackingWpf.Users;
using TimeTrackingWpf.ViewModels;

namespace TimeTracking;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    // Global Service Provider
    private static IServiceProvider _serviceProvider;

    public App()
    {
        try
        {
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
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        try
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            var mainWindowViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Creating factory for the classes that need to be created and not used as singleton
        services.AddTransient(typeof(IFactory<>), typeof(Factory<>));

        // Adding AutoMapper to dependecy injection
        services.AddAutoMapper(typeof(MappingProfile));

        #region Foms
        services.AddSingleton<MainWindow>();
        services.AddTransient<UsersList>();
        services.AddTransient<UserForm>();
        services.AddSingleton<MainWindow>();
        #endregion

        #region ViewModels
        services.AddTransient<UsersListViewModel>();
        services.AddTransient<UserFormViewModel>();
        services.AddSingleton<MainWindowViewModel>();
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

        services.AddSingleton<IExcelGenerator, ExcelGenerator.ExcelGenerator>();

        #region Services
        services.AddSingleton<IUsersService, UsersService>();
        services.AddSingleton<ITimeEntryService, TimeEntryService>();
        services.AddSingleton<IReportGenerator, ReportGenerator>();
        #endregion
    }
}
