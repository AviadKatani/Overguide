using MediaManager;
using Overguide.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Overguide
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTA4ODBAMzEzNzJlMzEyZTMwb3BacjVDTHpjbUVMdTNOdE1zK2hkRDFUTFhDSXQ1U1NUb0RKNmlLeStpOD0=");
            CrossMediaManager.Current.Init();
            InitializeComponent();

            MainPage = new NavigationPage(new LanguagePage());
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