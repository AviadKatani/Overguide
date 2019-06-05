using Overguide.Models;
using Overguide.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Overguide.ViewModels
{
    public class LanguageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Language> languages;

        public event PropertyChangedEventHandler PropertyChanged;

        private DataService _dataService = new DataService();

        public ObservableCollection<Language> Languages
        {
            get { return languages; }
            set
            {
                this.languages = value;
                OnPropertyChanged();
            }
        }

        public LanguageViewModel()
        {
            GetLanguageData();
        }

        private void GetLanguageData()
        {
            languages = _dataService.getLanguageData();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}