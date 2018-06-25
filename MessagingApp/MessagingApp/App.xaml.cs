using MessagingApp.Debug;
using MessagingApp.Managers;
using MessagingApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MessagingApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MessageManager.Instance.InitApplication();
            //MainPage = new NavigationPage(new ChatListView());
            MainPage = new NavigationPage(new LoginPage());
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
