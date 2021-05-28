using CurrencyManager.Jobs;
using CurrencyManager.ViewModels;
using CurrencyManager.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var MainWindow = new MainView();

            MainWindow.DataContext = new MainViewModel();

            MainWindow.Show();

            CurrencyScheduler.Start();
            //LibraryScheduler.Start();
            base.OnStartup(e);
        }

    }
}
