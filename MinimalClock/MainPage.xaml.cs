using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;

namespace MinimalClock
{
    public partial class MainPage : PhoneApplicationPage
    {
		private DispatcherTimer _timer;
		
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			RefreshUI(this, null);

			Storyboard sb = (Storyboard)this.Resources["IntialAnimation"];
            sb.BeginTime = TimeSpan.FromSeconds(0.1);
            sb.Begin();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(0.5);
            _timer.Tick += RefreshUI;
            _timer.Start();
        }
		
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (_timer != null)
            {
                _timer.Stop();
            }
        }
		
        public void RefreshUI(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            int seconds = dt.Second;
            int minutes = dt.Minute;
            int hour = dt.Hour;

            int year = dt.Year;

            // Time 
            if (TimeHours.Text != dt.Hour.ToString())
            {
                TimeHours.Text = dt.Hour.ToString();
            }

            if (TimeMinutes.Text != dt.Minute.ToString("D2"))
            {
                TimeMinutes.Text = dt.Minute.ToString("D2");
            }

            if (TimeSeconds.Text != dt.Second.ToString("D2"))
            {
                TimeSeconds.Text = dt.Second.ToString("D2");
            }
        }		
    }
}
