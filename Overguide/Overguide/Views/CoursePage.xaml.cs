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
    public partial class CoursePage : ContentPage
    {
        public static string chosen_course;

        public CoursePage()
        {
            InitializeComponent();
        }

        private async void Course_Choosed(object sender, EventArgs e)
        {
            var classID = (sender as SfButton).ClassId;
            chosen_course = classID;
            await Navigation.PushAsync(new StationPage());
        }
    }
}