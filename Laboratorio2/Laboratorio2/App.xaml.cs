using Laboratorio2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Laboratorio2
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new Laboratorio2.View.LoginPage();

            //NavigationPage navigation = new NavigationPage(new People());

            //App.Current.MainPage = new MasterDetailPage
            //{
            //    Master = new HomeMenu(),
            //    Detail = navigation
            //};
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
