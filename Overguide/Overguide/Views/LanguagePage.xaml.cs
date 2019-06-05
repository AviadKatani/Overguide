using Overguide.Models;
using Plugin.Multilingual;
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
    public partial class LanguagePage : ContentPage
    {
        public LanguagePage()
        {
            InitializeComponent();
        }

        private async void Language_Choosed(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var a = (Language)e.ItemData;
            CrossMultilingual.Current.CurrentCultureInfo = new System.Globalization.CultureInfo(a.nametag);
            await Navigation.PushAsync(new CoursePage());
        }
    }
}