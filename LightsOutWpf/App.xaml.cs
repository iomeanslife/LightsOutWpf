using LightsOutWpf.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LightsOutWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            var serviceCollection = new ServiceCollection();
            ConfigurationServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var gameWindow = ServiceProvider.GetRequiredService<GameWindow>();

            gameWindow.Show();
        }

        private void ConfigurationServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddScoped<IGameFieldService,GameFieldService>();
            services.AddTransient< GameWindow>();
            
        }
    }
}
