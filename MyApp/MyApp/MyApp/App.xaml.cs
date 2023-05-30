using MyApp.Services;
using MyApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new MyApp.FirstPage();
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
