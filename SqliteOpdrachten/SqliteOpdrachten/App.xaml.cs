﻿using SqliteOpdrachten.JSONUpdate;
using SqliteOpdrachten.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SqliteOpdrachten
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ContactsPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}