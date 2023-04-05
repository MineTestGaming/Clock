using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.UI.WindowManagement;
using Windows.UI.ViewManagement;
using Windows.Security.Cryptography.Core;
using static Clock.CustomStateTrigger.viewModeTrigger;

namespace Clock.CustomStateTrigger
{

    public class viewModeTrigger : StateTriggerBase
    {


        private FrameworkElement _targetElement;
        private WindowType _viewType;
        private WindowType _latestViewType;



        public FrameworkElement TargetElement
        {
            get
            {
                return _targetElement;
            }
            set
            {
                if (_targetElement != null)
                {
                    _targetElement.SizeChanged -= OnSizeChanged;
                }
                _targetElement = value;
                _targetElement.SizeChanged += OnSizeChanged;
            }
        }
        public enum WindowType
        {
            Normal = 0,
            FullScreen = 1,
            PIP = 2
        }
        public WindowType ViewType
        {
            get { return _viewType; }
            set { _viewType = value; }
        }

        
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateTrigger();
        }
       /* public void ViewModeSwitch()
        {
            var fullScrEventTrigger = new WeakEventListener<viewModeTrigger, ApplicationView, object>(this)
            {
                OnEventAction = (instance, source, EventArgs) => viewModeTrigger_viewBoundsChange(source, EventArgs),
                OnDetachAction = (weakEventListener) => ApplicationView.GetForCurrentView().VisibleBoundsChanged -= weakEventListener.OnEvent
            };
            ApplicationView.GetForCurrentView().VisibleBoundsChanged += fullScrEventTrigger.OnEvent;
        }
        private void viewModeTrigger_viewBoundsChange(ApplicationView source, object sender)
        {
            UpdateTrigger();
        }*/

        private void UpdateState()
        {
            var view = ApplicationView.GetForCurrentView();

                if (view.IsFullScreenMode)
                {
                    _latestViewType = WindowType.FullScreen;
                    
                }
                else if (view.ViewMode == ApplicationViewMode.CompactOverlay)
                {
                    _latestViewType = WindowType.PIP;
                }
                else
                {
                    _latestViewType = WindowType.Normal;
                }
        }

        private void UpdateTrigger()
        {
            UpdateState();
            SetActive(_viewType == _latestViewType);
            
        }
    }
    
}
