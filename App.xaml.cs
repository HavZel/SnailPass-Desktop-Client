﻿using SnailPass_Desktop.Data.API;
using SnailPass_Desktop.Model;
using SnailPass_Desktop.Repositories;
using SnailPass_Desktop.View;
using SnailPass_Desktop.ViewModel;
using SnailPass_Desktop.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SnailPass_Desktop
{
    public partial class App : Application
    {
        private IRestClient _httpClient;
        private UserIdentityStore _userIdentityStore;
        private Window _startupWindow;

        public Window StartupWindow
        { 
            get { return _startupWindow; }
        } 

        protected override void OnStartup(StartupEventArgs e)
        {
            _httpClient = new RestAPI();
            _userIdentityStore = new UserIdentityStore();

            //NavigationStore navigationStoreStartup = new NavigationStore();
            //navigationStoreStartup.CurrentViewModel = new LoginViewModel(navigationStoreStartup, _userIdentityStore, _httpClient);
            //navigationStoreStartup.TextHeader = "Login";

            //_startupWindow = new StartupWindow()
            //{
            //    DataContext = new StartupViewModel(navigationStoreStartup)
            //};

            //StartupWindow.Show();

            //StartupWindow.IsVisibleChanged += (s, ev) =>
            //{
            //    if (StartupWindow.IsVisible == false && MainWindow.IsLoaded)
            //    {
                    NavigationStore navigationStoreMain = new NavigationStore();
                    navigationStoreMain.CurrentViewModel = new AccountsViewModel(_userIdentityStore);

                    MainWindow = new MainWindow()
                    {
                        DataContext = new ApplicationViewModel(navigationStoreMain, _userIdentityStore)
                    };

                    //StartupWindow.Close();
                    MainWindow.Show();
            //    }
            //};

            base.OnStartup(e);
        }
    }
}