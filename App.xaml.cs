using Assignment_11._1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Assignment_11._1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider; //for dependent injection
        private ServiceProvider _petContext;
        //constructor
        public App()
        {
            //collection of services
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<Data.PetContext>(options =>
            {
                options.UseSqlite("Data Source = petJournal.db");
            }); //registering the db to context using sqlite
            services.AddSingleton<MainWindow>(); //register the main window
            services.AddSingleton<ICRUD, CRUD>();//register the crud services            
            _serviceProvider = services.BuildServiceProvider();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }

}
