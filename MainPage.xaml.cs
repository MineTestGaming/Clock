using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Clock.CustomStateTrigger;

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
            if (SecondDisplay.IsOn)
            {
                WindowPrefrence.CustomSize = new Windows.Foundation.Size(360, 160);
            }
            else
            {
                WindowPrefrence.CustomSize = new Windows.Foundation.Size(260, 160);
            }

            if (WindowMode.ViewMode != ApplicationViewMode.CompactOverlay)
            {
                await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay, WindowPrefrence);
                //   SFW_Text.Text = "";
                return;
            }

            if (WindowMode.ViewMode == ApplicationViewMode.CompactOverlay)
            {
                await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default);
                //  SFW_Text.Text = "";
                return;
            }


        }

        private async void ClockStart()
        {
            for (; ; )
            {
                var currentTime = System.DateTime.Now;
                int Hr = currentTime.Hour;
                int Min = currentTime.Minute;
                int Sec = currentTime.Second;
                if (SecondDisplay.IsOn)
                {
                    TimeTextBlock.Text = Hr.ToString() + ":" + Min.ToString("00") + ":" + Sec.ToString("00");
                }
                else
                {
                    TimeTextBlock.Text = Hr.ToString() + ":" + Min.ToString("00") ;
                }

                await Task.Delay(100);
            }
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClockStart();
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationView.GetForCurrentView().TitleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(0, 0, 0, 0);
            ApplicationView.GetForCurrentView().TitleBar.ButtonInactiveBackgroundColor = Windows.UI.Color.FromArgb(0, 0, 0, 0);
        }

        private void SwitchFullscreen_Click(object sender, RoutedEventArgs e)
        {
            var WindowMode = ApplicationView.GetForCurrentView();
            if (WindowMode.IsFullScreenMode == false)
            {
                WindowMode.TryEnterFullScreenMode();
               // SF_Symbol.Symbol = Symbol.BackToWindow;
                return;
            }

            if (WindowMode.IsFullScreenMode == true)
            {
                WindowMode.ExitFullScreenMode();
               // SF_Symbol.Symbol = Symbol.FullScreen;
            }
        }

    }
}
