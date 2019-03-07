using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using caredoctor.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace care_doctor.Views
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            try
            {
                if (Application.Current.Properties["care_id"].Equals(null))
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
                else
                {
                    MainPage = new NavigationPage(new Dashboard());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Exception in getting doctor properties. Redirecting to Login screen");
                MainPage = new NavigationPage(new LoginPage());
            }
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
