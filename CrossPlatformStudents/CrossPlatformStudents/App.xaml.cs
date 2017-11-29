using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CrossPlatformStudents
{
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();

            Data data = new Data();

            MainPage = new CrossPlatformStudents.MainPage() { BindingContext = data };
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
