using CurrencyManager.BLL;
using CurrencyManager.Entities;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications.Core;

namespace CurrencyManager.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private object obj = new object();
        private BLLayer _providerCurr;
        private Timer _timerRequestCurrency;
        public string SelectedCurrency;
        public ObservableCollection<CurrencyMarket> AllCurrencyMarket
        {
            get
            {
                return GetProperty(() => AllCurrencyMarket);
            }
            set
            {
                SetProperty(() => AllCurrencyMarket, value);
            }
        }


        public WindowState State
        {
            get
            {
                return GetProperty(() => State);
            }
            set
            {

                if (value == WindowState.Minimized)
                {
                    Application.Current.MainWindow.Hide();
                }
                if (value == WindowState.Normal)
                {
                    Application.Current.MainWindow.Show();
                    Application.Current.MainWindow.Activate();
                }
                SetProperty(() => State, value);
            }
        }

        MessageOptions _options;
        public void Loaded()
        {
            InitFieldsPrperties();
            //_timerRequestCurrency = new Timer(UpdateCurrency, Application.Current.Dispatcher, new TimeSpan(0), new TimeSpan(0, 0, 5));

            _options = new MessageOptions
            {
                NotificationClickAction = n => // set the callback for notification click event
                {
                    OpenWindow.Execute(null);
                },
            };
        }

        public ICommand Exit => new AsyncCommand(async () =>
        {
            Application.Current.Shutdown();
        });
        public ICommand OpenWindow => new AsyncCommand(async () =>
        {
            State = WindowState.Normal;
        });


        private void InitFieldsPrperties()
        {
            _providerCurr = new BLLayer();
        }

        public String Title
        {
            get
            {
                return "CurrencyManager v" + Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        //private void UpdateCurrency(object param)
        //{
        //    lock (obj)
        //    {
        //        var dispatcher = param as Dispatcher;

        //        if (AllCurrencyMarket != null)
        //        {
        //        }
        //    }
        //}

    }
}
