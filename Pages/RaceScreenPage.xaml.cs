using ProjectGameInteraction2DRacingGame.Components;
using ProjectGameInteraction2DRacingGame.OOP;
using ProjectGameInteraction2DRacingGame.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProjectGameInteraction2DRacingGame.Pages
{
    /// <summary>
    /// Interaction logic for RaceScreenPage.xaml
    /// </summary>
    public partial class RaceScreenPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();

        List<PlayerRaceTickerComponent> players = new List<PlayerRaceTickerComponent>();
        List<Frame> positionFrames = new List<Frame>();
        List<List<Rectangle>> recs = new List<List<Rectangle>>();
        int squareSize;
        public void KnopIngedrukt(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
                autoRijden.moveUp = true;
            if (e.Key == Key.S)
                autoRijden.moveDown = true;
            if (e.Key == Key.A)
                autoRijden.moveLeft = true;
            if (e.Key == Key.D)
                autoRijden.moveRight = true;
        }

        public void KnopLos(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
                autoRijden.moveUp = false;
            if (e.Key == Key.S)
                autoRijden.moveDown = false;
            if (e.Key == Key.A)
                autoRijden.moveLeft = false;
            if (e.Key == Key.D)
                autoRijden.moveRight = false;
        }
        public void AutoMovementChecken(object sender, EventArgs e)
        {
            if (autoRijden.moveUp)
                Canvas.SetTop(autoRijden.car, Canvas.GetTop(autoRijden.car) - 5);
            if (autoRijden.moveDown)
                Canvas.SetTop(autoRijden.car, Canvas.GetTop(autoRijden.car) + 5);
            if (autoRijden.moveLeft)
                Canvas.SetLeft(autoRijden.car, Canvas.GetLeft(autoRijden.car) - 5);
            if (autoRijden.moveRight)
                Canvas.SetLeft(autoRijden.car, Canvas.GetLeft(autoRijden.car) + 5);
        }

        public RaceScreenPage()
        {
            InitializeComponent();
            /// Game Timer;

            timer.Interval = TimeSpan.FromMilliseconds(5);
            timer.Tick += AutoMovementChecken;
            timer.Start();

            mainWindow.KeyDown += KnopIngedrukt;
            mainWindow.KeyUp += KnopLos;

            GameCanvas.Focus();

            /// 
            SizeChanged += RaceScreenPage_SizeChanged;
            PausedFrame.Content = new PausedDialogComponent(PausedFrame);

            //Add this seperately as FindVisualChildren doesn't work properly
            positionFrames.Add(Position_1);
            positionFrames.Add(Position_2);
            positionFrames.Add(Position_3);
            positionFrames.Add(Position_4);
            DisplayPlayersInTower();



        }

        private void RaceScreenPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GameCanvas.Height = e.NewSize.Height;
            GameCanvas.Width = e.NewSize.Width;


            squareSize = (int)((float)GameCanvas.Width / 200f);
            GenerateLevel();
            LoadCircuitData();
            
            Canvas.SetLeft(autoRijden.car, 200);
            Canvas.SetTop(autoRijden.car, 200);
            GameCanvas.Children.Add(autoRijden.car);
        }
        AutoRijden autoRijden = new AutoRijden();
        public DispatcherTimer timer = new DispatcherTimer();
        /// <summary>
        /// Display players in random position order
        /// </summary>
        void DisplayPlayersInTower()
        {
            mainWindow.gameInfo.GetAllPlayers().ShuffleMe();

            for (int i = 0; i < mainWindow.gameInfo.GetAllPlayers().Count; i++)
            {
                PlayerRaceTickerComponent tickerItem = new PlayerRaceTickerComponent(mainWindow.gameInfo.GetAllPlayers()[i].GetColor().Color, (i + 1), $"{mainWindow.gameInfo.GetAllPlayers()[i].GetPlayerName()}");

                //Stupid calculation :|
                tickerItem.Width = mainWindow.Width / mainWindow.gameInfo.GetAllPlayers().Count - (mainWindow.gameInfo.GetAllPlayers().Count == 2 ? 46 : (mainWindow.gameInfo.GetAllPlayers().Count == 3 ? 34.5f : 23));
                positionFrames[i].Content = tickerItem;
                players.Add(tickerItem);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PausedFrame.Visibility = Visibility.Visible;
        }

        //TEMP METHOD (FOR GOING TO PODIUM
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                mainWindow.MainFrameWindow.Content = new ResultPodiumPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Generate the rectangle grid
        /// </summary>
        void GenerateLevel()
        {
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            bool nextIsOdd = false;

            recs.Add(new List<Rectangle>());
            while (doneDrawingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = squareSize,
                    Height = squareSize,
                    Fill = nextIsOdd ? Brushes.White : Brushes.Black
                };
                GameCanvas.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                nextIsOdd = !nextIsOdd;
                nextX += squareSize;
                if (nextX >= GameCanvas.Width)
                {
                    nextX = 0;
                    nextY += squareSize;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                    recs.Add(new List<Rectangle>());
                }

                if (nextY >= GameCanvas.Height)
                    doneDrawingBackground = true;
                recs.Last().Add(rect);
            }
        }

        /// <summary>
        /// Load all data from the circuitList into the grid
        /// </summary>
        void LoadCircuitData()
        {
            Track track = mainWindow.Tracks.Find(x => x.GetTrackID() == mainWindow.gameInfo.GetTrackID());
            if (track.GetCircuit() == null)
                MessageBox.Show("TRACK IS NULL");

            else
            {
                int index = 0;
                for (int j = 0; j < recs.Count; j++)
                {
                    for (int i = 0; i < recs[j].Count; i++)
                    {
                        if (index! >= track.GetCircuit().Count - 1)
                            recs[j][i].Fill = GetBrushColor(track.GetCircuit()[index].surfaceType);
                        else
                        {
                            if (track.GetCircuit()[index + 1].column == i && j == track.GetCircuit()[index + 1].row)
                                index++;
                            recs[j][i].Fill = GetBrushColor(track.GetCircuit()[index].surfaceType);
                        }
                    }
                }
            }          
        }

        Brush GetBrushColor(CircuitSurfaces type)
        {
            return type switch {
                CircuitSurfaces.Tarmac => Brushes.Gray,
                CircuitSurfaces.Grass => Brushes.Green,
                CircuitSurfaces.Sand => Brushes.Yellow,
                CircuitSurfaces.Wall => Brushes.Red,
                CircuitSurfaces.checkpoint => Brushes.White,
                CircuitSurfaces.finishline => Brushes.White,
                _ => Brushes.Black
            };
        }
    }
}
