using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneySaver
{
    public partial class App : Application
    {
        public static string ListOfExpenses = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string listOfExpenses)
        {
            ListOfExpenses = listOfExpenses;

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
