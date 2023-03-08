using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Clock
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        
        public MainPage()
        {
            this.InitializeComponent();

        }



        private async void SwitchFloatWindow_Click(object sender, RoutedEventArgs e)
        {
            var WindowMode = ApplicationView.GetForCurrentView();
            var WindowPrefrence = ViewModePreferences.CreateDefault(ApplicationViewMode.CompactOverlay);
            WindowPrefrence.CustomSize = new Windows.Foundation.Size(410, 212);
            if (WindowMode.ViewMode != ApplicationViewMode.CompactOverlay) {
                 await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay, WindowPrefrence);
                return;
            }

            if(WindowMode.ViewMode == ApplicationViewMode.CompactOverlay)
            {
                await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default);
                return;
            }


        }

        private async void ClockStart()
        {
            for (; ; ) {
                var currentTime = System.DateTime.Now;
                int Hr = currentTime.Hour;
                int Min = currentTime.Minute;
                int Sec = currentTime.Second;
                TimeTextBlock.Text = Hr.ToString() + ":" + Trim2num(Min) + ":" + Trim2num(Sec) ;
                await Task.Delay(100);
            }
        }

        public string Trim2num(int i)
        {
            string o;
            if (i < 10)
            {
                o = "0" + i.ToString();
            }
            else
            {
                o = i.ToString();
            }
            

            return o;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClockStart();
        }

        private void SwitchFullscreen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
