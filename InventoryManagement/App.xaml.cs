using InventoryManagement.Converter;
using InventoryManagement.Core.Context;
using InventoryManagement.Core.Repository;
using InventoryManagement.Core.Service;
using InventoryManagement.Repository;
using InventoryManagement.Service;
using InventoryManagement.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            #region Repositories
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            #endregion

            #region Services
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<INotificationService, WindowNotificationService>();
            #endregion

            #region ViewModels
            services.AddTransient<MainViewModel>();
            #endregion

            #region Data Context
            services.AddTransient<ApplicationContext>();
            #endregion

            services.AddTransient<HierarchyConverter>();

            #region Main Window
            services.AddScoped<MainWindow>();
            #endregion

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }

}
