using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Overguide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StationPage : ContentPage
    {
        public static string chosen_stage;

        public StationPage()
        {
            InitializeComponent();
        }

        private async void Station_Choosed(object sender, EventArgs e)
        {
            var classID = (sender as SfButton).ClassId;
            chosen_stage = classID;
            await Navigation.PushAsync(new PlayerPage());
        }
    }
}