using ProjectGameInteraction2DRacingGame.OOP;
using ProjectGameInteraction2DRacingGame.Public;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
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
using System.Windows.Xps.Packaging;

namespace ProjectGameInteraction2DRacingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MediaPlayer player = new MediaPlayer();
        public Session gameInfo = new Session();
        public CircuitImporter circuitImporter = new CircuitImporter();

        public List<Color> GameColors = new List<Color>();
        public Public.Colors Colors = new Public.Colors();

        //Important class lists
        public List<CarClass> CarClasses = new List<CarClass>();
        public List<Track> Tracks = new List<Track>();

        public MainWindow()
        {
            InitializeComponent();
            GameSettings.OnMusicVariableChange += UpdateMusicVolume;
            GameSettings.OnTranslationVariableChange += UpdateTranslation;

            CarClasses = new List<CarClass>(OOPClassesImporter.ImportClasses());
            Tracks = new List<Track>(OOPClassesImporter.ImportTracks());

            GameSettingsImporter.ReadFromFile();
            PlayMusic();
            GameColors = new List<Color>(Colors.GetAllColors());
            circuitImporter.ImportTracks();

            for (int i = 0; i < Tracks.Count; i++)
            {
                for (int j = 0; j < circuitImporter.CircuitList.Count; j++)
                {
                    if (circuitImporter.CircuitList[j].reference == Tracks[i].GetName())
                        Tracks[i].SetModel(circuitImporter.CircuitList[j]);
                }
            }
        }

        /// <summary>
        /// Necessary code for frame navigation
        /// </summary>
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

        /// <summary>
        /// Play backgroundmusic
        /// </summary>
        void PlayMusic()
        {
            string audioFilePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Audio/Music/", "MainMenu.wav");

            player.Open(new Uri(audioFilePath, UriKind.RelativeOrAbsolute));
            player.Volume = GameSettings.GetMusicVolume() / 10;
            player.MediaEnded += LoopMusic;            
        }
        /// <summary>
        /// Event for mediaplayer so it can start again once the music has ended
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoopMusic(object sender, EventArgs e)
        {
            player.Position = TimeSpan.Zero;
            player.Play();
        }
        /// <summary>
        /// Update the volume event
        /// </summary>
        /// <param name="volume"></param>
        void UpdateMusicVolume(float volume)
        {
            //Stops player if volume is 0
            if (volume <= 0)
            {
                player.Volume = 0;
                player.Stop();
            }
            //Starts player again at the beginning
            else if (player.Volume == 0 && volume > 0)
            {
                LoopMusic(null, new EventArgs());
                player.Volume = volume;
            }
            else
                player.Volume = volume;
        }
        /// <summary>
        /// Update the translation
        /// </summary>
        void UpdateTranslation(int value)
        {

        }
    }
}
