using LightsOutWpf.Shared.Services;

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

            // IoC code.
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOptions();
            serviceCollection.AddScoped<IGameFieldService, GameFieldService>();
            serviceCollection.AddTransient<GameWindow>();

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var gameFieldService = ServiceProvider.GetRequiredService<IGameFieldService>();
            gameFieldService.PlayerWins += GameFieldService_PlayerWins;

            var gameWindow = ServiceProvider.GetRequiredService<GameWindow>();

            gameWindow.Show();
        }

        private void GameFieldService_PlayerWins(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Play again?", "You win!", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                ((IGameFieldService) sender).SetupGameField();
            }
        }
    }
}
