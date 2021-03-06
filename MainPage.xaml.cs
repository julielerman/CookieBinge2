﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CookieBinge2
{
    public sealed partial class MainPage 
    {
        private readonly BingeViewModel _binge;

        public MainPage()
        {
            InitializeComponent();
            //InitializeComponent(new Uri("ms-appx:///DeviceFamily-Mobile///MainPage.xaml", UriKind.Absolute));

            _binge = new BingeViewModel();
            NomText.Visibility = Visibility.Collapsed;
            // Refresh bing list after a new binge is added
            _binge.BingeCompleted += s => { ReloadHistory(); };
            BingePane.DataContext = _binge;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadHistory();
        }

        private void ReloadHistory()
        {
            BingeList.ItemsSource = BingeService.GetRecentBinges(5);
        }

        //private void Image_Tapped(object sender, TappedRoutedEventArgs e) {
        //  _binge.HandleClick();
        //}

        private void Play_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _binge.StartNewBinge();
        }


        private void WorthIt_Click(object sender, RoutedEventArgs e)
        {
            _binge.StoreBinge(true);
        }

        private void NotWorthIt_Click(object sender, RoutedEventArgs e)
        {
            _binge.StoreBinge(false);
        }

        private void CookieImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

            if (_binge.Binging)
            {
                ((Image)sender).CapturePointer(e.Pointer);

                var pt = e.GetCurrentPoint(BingeGrid);
                NomText.Margin = new Thickness(pt.Position.X, pt.Position.Y, 0, 0);

                NomText.Visibility = Visibility.Visible;
                _binge.HandleClick();
                ReloadHistory();

            }
        }

        private void CookieImage_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            ((Image)sender).ReleasePointerCapture(e.Pointer);

            NomText.Visibility = Visibility.Collapsed;
        }

        private void CookieImage_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ClearHistory_Click(object sender, RoutedEventArgs e)
        {
            BingeService.ClearHistory();
            ReloadHistory();
        }
    }

}