using Overguide.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Overguide.Services
{
    public class DataService
    {
        public ObservableCollection<Language> getLanguageData()
        {
            var languages = new ObservableCollection<Language>
            {
                new Language("עברית", "he", ImageSource.FromResource("Overguide.Images.ilflag.png")),
                new Language("English", "en", ImageSource.FromResource("Overguide.Images.usflag.png")),
                new Language("Pусский ", "ru", ImageSource.FromResource("Overguide.Images.russianflag.jpg")),
                new Language("Deutsch", "de", ImageSource.FromResource("Overguide.Images.flagermany.png")),
                new Language("Français", "fr", ImageSource.FromResource("Overguide.Images.franceflag.png")),
                new Language("Dutch", "nl", ImageSource.FromResource("Overguide.Images.flagnetherland.png")),
                new Language("Español", "es", ImageSource.FromResource("Overguide.Images.spainflag.png")),
                new Language("Italiano", "it", ImageSource.FromResource("Overguide.Images.italyflag.png")),
                new Language("العربية", "ar", ImageSource.FromResource("Overguide.Images.arabflag.png"))
            };
            return languages;
        }
    }
}