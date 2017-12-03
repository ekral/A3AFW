using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CrossPlatformNavigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainView view = new MainView();
            MainViewModel viewModel = new MainViewModel(view.Navigation);
            view.BindingContext = viewModel;

            MainPage = new NavigationPage(view);

            // Smazat pokud chci vychozi kulturu na telefonu
            CultureInfo czechCulture = new CultureInfo("cs-CZ");
            CultureInfo.DefaultThreadCurrentCulture = czechCulture;

            //Xamarin.Forms.PlatformConfiguration.iOSSpecific.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
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
