﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RunningApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DB.OpenConnection();
            MainPage = new NavigationPage(new RunningApp.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
