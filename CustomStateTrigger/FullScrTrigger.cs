using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace Clock.CustomStateTrigger
{
    public class Fullscreen : StateTriggerBase
    {
        private string _WindowMode, _WindowModeCurrent;

        public string WindowMode
        {
            get { return _WindowMode; }
            set
            {
                _WindowMode = value;
                
            
                
            }
        }

        private void _WinModeChange(object sender, SizeChangedEventArgs e)
        {

            var _currentHeight = e.NewSize.Height;
            var _currentWidth = e.NewSize.Width;
            if (ApplicationView.GetForCurrentView().IsFullScreenMode == true)
            {
                _WindowModeCurrent = "Fullscreen";
                SetActive(_WindowMode == _WindowModeCurrent);

            }
            if (ApplicationView.GetForCurrentView().ViewMode == ApplicationViewMode.CompactOverlay)
            {
                _WindowModeCurrent = "CompactOverlay";
                SetActive(_WindowMode == _WindowModeCurrent);
            }
            if (ApplicationView.GetForCurrentView().ViewMode == ApplicationViewMode.Default)
            {
                _WindowModeCurrent = "Default";
                SetActive(_WindowMode == _WindowModeCurrent);
            }
        }


    }

 /*   public class OverlayOrDefault : StateTriggerBase
    {
        private 
    }*/

}
