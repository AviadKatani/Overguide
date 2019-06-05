using MediaManager;
using Overguide.Helpers;
using Overguide.Services;
using Overguide.ViewModels;
using Plugin.Multilingual;
using Syncfusion.SfCarousel.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Overguide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        private Boolean isRunning;

        public PlayerPage()
        {
            InitializeComponent();
            lblcurrent.Text = "0:00";
            SetupAudioFile();
            isRunning = false;
            MessagingCenter.Send(this, "Hi", "John");

            initCarousel();
            initHeader();
        }

        public void initCarousel()
        {
            SfCarousel carousel = new SfCarousel() { ViewMode = ViewMode.Linear };
            carousel.ItemHeight = 400;
            ObservableCollection<SfCarouselItem> collectionOfItems = new ObservableCollection<SfCarouselItem>();
            // StackLayout textLayout = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand};
            Frame frame = new Frame()
            {
                BackgroundColor = Color.Transparent,
                BorderColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(10)
            };
            //StackLayout item = new StackLayout() {HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            Label label = new Label
            {
                Text = getTranslatedString("StationTemporary"),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontFamily =
                (OnPlatform<string>)Application.Current.Resources["RobotoThin"]
            };
            ScrollView scrollView = new ScrollView() { Content = label, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(10) };
            scrollView.Content = label;
            frame.Content = scrollView;
            frame.BorderColor = Color.LightGray;
            frame.HasShadow = false;
            //frame.Content = scrollView;
            collectionOfItems.Add(new SfCarouselItem() { ItemContent = frame });
            collectionOfItems.Add(new SfCarouselItem() { ImageName = "camel.jpg" });
            carousel.ItemsSource = collectionOfItems;
            MainLayout.Children.Add(carousel, 0, 1);
            Grid.SetColumnSpan(carousel, 3);
            this.Content = MainLayout;
        }

        public void initHeader()
        {
            Label ChosenStation = new Label()
            {
                Text = getTranslatedString(StationPage.chosen_stage),
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontFamily = (OnPlatform<string>)Application.Current.Resources["RobotoThin"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label SeeMoreLabel = new Label()
            {
                Text = getTranslatedString("SeeMore"),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontFamily = (OnPlatform<string>)Application.Current.Resources["RobotoLight"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            StackLayout stackLayout = new StackLayout() { HorizontalOptions = LayoutOptions.Center, Spacing = 5, Children = { ChosenStation, SeeMoreLabel } };
            MainLayout.Children.Add(stackLayout, 0, 0);
            Grid.SetColumnSpan(stackLayout, 3);
            this.Content = MainLayout;
            Debug.WriteLine("Font is: " + (OnPlatform<string>)Application.Current.Resources["RobotoBlack"]);
        }

        public String getTranslatedString(String text)
        {
            const string ResourceId = "Overguide.Helpers.Resources.AppResources";
            var resmgr = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            var ci = CrossMultilingual.Current.CurrentCultureInfo;
            //TODO: Check for current course and stage and get the needed string from the AppResources.
            return resmgr.GetString(text, ci);
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Play();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
                dialer.RemoveNotification();
        }

        public void SetupAudioFile()
        {
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
            {
                dialer.positionChanged += Dialer_PositionChanged;
                dialer.SetUpAudio();
                lblTotalCount.Text = (string)dialer.getTotaltime();
                customSlider.Maximum = Convert.ToDouble(dialer.MediaTotalDuration());
            }
        }

        private void PlayClick(object sender, System.EventArgs e)
        {
            if (!isRunning)
            {
                var dialer = DependencyService.Get<AudioInterface>();
                if (dialer != null)
                {
                    //Setuptimer();

                    dialer.Play();
                    Device.BeginInvokeOnMainThread(() => { StartButton.Text = System.Web.HttpUtility.HtmlDecode("&#xf04c;"); });
                    isRunning = true;
                }
            }
            else
            {
                PauseClick();
                Device.BeginInvokeOnMainThread(() => { StartButton.Text = System.Web.HttpUtility.HtmlDecode("&#xf04b;"); });
                isRunning = false;
            }
        }

        private void PauseClick()
        {
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
                dialer.Pause();
        }

        private void RestartClick(object sender, System.EventArgs e)
        {
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
            {
                dialer.Restart();
            }
            lblcurrent.Text = "0:00";
        }

        protected override bool OnBackButtonPressed()
        {
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
            {
                dialer.Restart();
                dialer.Pause();
                lblcurrent.Text = "0:00";
            }
            return base.OnBackButtonPressed();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs eventArgs)
        {
            Debug.WriteLine("ConsoleTimer:" + eventArgs.NewValue);
            customSlider.Value = eventArgs.NewValue;
        }

        private void Dialer_PositionChanged(object sender, EventArgs e)
        {
            var dicitionary = sender as Dictionary<string, object>;
            lblcurrent.Text = (string)dicitionary["CurrentText"];
            customSlider.Value = Convert.ToDouble(dicitionary["CurrentDuration"]);
        }
    }
}