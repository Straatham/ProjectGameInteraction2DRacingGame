using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProjectGameInteraction2DRacingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool _allowDirectNavigation = false;
        private NavigatingCancelEventArgs _navArgs = null;
        private Duration _duration = new Duration(TimeSpan.FromMilliseconds(100));
        private double _oldOpacity = 0;

        /// <summary>
        /// Main method to call if you want to fade in/out frames
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (Content != null && !_allowDirectNavigation)
            {
                e.Cancel = true;

                _navArgs = e;
                _oldOpacity = MainFrameWindow.Opacity;

                DoubleAnimation animation0 = new DoubleAnimation();
                animation0.From = MainFrameWindow.Opacity;
                animation0.To = 0;
                animation0.Duration = _duration;
                animation0.Completed += SlideCompleted;
                MainFrameWindow.BeginAnimation(OpacityProperty, animation0);
            }
            _allowDirectNavigation = false;
        }

        private void SlideCompleted(object sender, EventArgs e)
        {
            _allowDirectNavigation = true;
            switch (_navArgs.NavigationMode)
            {
                case NavigationMode.New:
                    if (_navArgs.Uri == null)
                        MainFrameWindow.Navigate(_navArgs.Content);
                    else
                        MainFrameWindow.Navigate(_navArgs.Uri);
                    break;
                case NavigationMode.Back:
                    MainFrameWindow.GoBack();
                    break;
                case NavigationMode.Forward:
                    MainFrameWindow.GoForward();
                    break;
                case NavigationMode.Refresh:
                    MainFrameWindow.Refresh();
                    break;
            }

            Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                (ThreadStart)delegate ()
                {
                    DoubleAnimation animation0 = new DoubleAnimation();
                    animation0.From = 0;
                    animation0.To = _oldOpacity;
                    animation0.Duration = _duration;
                    MainFrameWindow.BeginAnimation(OpacityProperty, animation0);
                });
        }
    }
}
