using ProjectGameInteraction2DRacingGame.Components;
using ProjectGameInteraction2DRacingGame.OOP;
using ProjectGameInteraction2DRacingGame.Public;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
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

        // Create a car for each player
        private Dictionary<int, Rectangle> playerCars = new Dictionary<int, Rectangle>();
        private void SetUpPlayersList()
        {
            for (int i = 1; i <= mainWindow.gameInfo.GetAllPlayers().Count; i++)
            {
                var imageSource = $"SportsCar1_{mainWindow.gameInfo.GetAllPlayers()[i-1].GetCarID()}.png";
                var path = System.IO.Path.Combine("/Images/Autos", imageSource);
                Uri uri = new Uri(path, UriKind.Relative);
                Rectangle newCar = new Rectangle();
                newCar.Name = mainWindow.gameInfo.GetAllPlayers()[i-1].GetPlayerName();
                newCar.Width = 50;
                newCar.Height = 50;
                newCar.Fill = new ImageBrush( ImageColorConverter.ConvertColorToSource(uri, mainWindow.gameInfo.GetAllPlayers()[i - 1].GetColor().Color));
                Canvas.SetLeft(newCar, 400+i*60);
                Canvas.SetTop(newCar, 400);
                GameCanvas.Children.Add(newCar);

                playerCars[i] = newCar;
            }
        }
        public bool moveUp1, moveDown1, moveLeft1, moveRight1; // Player 1
        public bool moveUp2, moveDown2, moveLeft2, moveRight2; // Player 2
        public bool moveUp3, moveDown3, moveLeft3, moveRight3; // Player 3
        public bool moveUp4, moveDown4, moveLeft4, moveRight4; // Player 4
        public void KnopIngedrukt(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W) moveUp1 = true; // Player 1
            if (e.Key == Key.S) moveDown1 = true;
            if (e.Key == Key.A) moveLeft1 = true;
            if (e.Key == Key.D) moveRight1 = true;
            if (e.Key == Key.Up)
                moveUp2 = true; // Player 2
            if (e.Key == Key.Down) moveDown2 = true;
            if (e.Key == Key.Left) moveLeft2 = true;
            if (e.Key == Key.Right) moveRight2 = true;
            if (e.Key == Key.I) moveUp3 = true; // Player 3
            if (e.Key == Key.K) moveDown3 = true;
            if (e.Key == Key.J) moveLeft3 = true;
            if (e.Key == Key.L) moveRight3 = true;
            if (e.Key == Key.NumPad8) moveUp4 = true; // Player 4
            if (e.Key == Key.NumPad5) moveDown4 = true;
            if (e.Key == Key.NumPad4) moveLeft4 = true;
            if (e.Key == Key.NumPad6) moveRight4 = true;
        }

        public void KnopLos(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W) moveUp1 = false; // Player 1
            if (e.Key == Key.S) moveDown1 = false;
            if (e.Key == Key.A) moveLeft1 = false;
            if (e.Key == Key.D) moveRight1 = false;
            if (e.Key == Key.Up) moveUp2 = false; // Player 2
            if (e.Key == Key.Down) moveDown2 = false;
            if (e.Key == Key.Left) moveLeft2 = false;
            if (e.Key == Key.Right) moveRight2 = false;
            if (e.Key == Key.I) moveUp3 = false; // Player 3
            if (e.Key == Key.K) moveDown3 = false;
            if (e.Key == Key.J) moveLeft3 = false;
            if (e.Key == Key.L) moveRight3 = false;
            if (e.Key == Key.NumPad8) moveUp4 = false; // Player 4
            if (e.Key == Key.NumPad5) moveDown4 = false;
            if (e.Key == Key.NumPad4) moveLeft4 = false;
            if (e.Key == Key.NumPad6) moveRight4 = false;
        }
        public void AutoMovementChecken(object sender, EventArgs e)
        {
            // Player 1
            if (moveUp1 && playerCars.ContainsKey(1))
                Canvas.SetTop(playerCars[1], Canvas.GetTop(playerCars[1]) - 5);
            if (moveDown1 && playerCars.ContainsKey(1))
                Canvas.SetTop(playerCars[1], Canvas.GetTop(playerCars[1]) + 5);
            if (moveLeft1 && playerCars.ContainsKey(1))
                Canvas.SetLeft(playerCars[1], Canvas.GetLeft(playerCars[1]) - 5);
            if (moveRight1 && playerCars.ContainsKey(1))
                Canvas.SetLeft(playerCars[1], Canvas.GetLeft(playerCars[1]) + 5);
            // Player 2
            if (moveUp2 && playerCars.ContainsKey(2))
                Canvas.SetTop(playerCars[2], Canvas.GetTop(playerCars[2]) - 5);
            if (moveDown2 && playerCars.ContainsKey(2))
                Canvas.SetTop(playerCars[2], Canvas.GetTop(playerCars[2]) + 5);
            if (moveLeft2 && playerCars.ContainsKey(2))
                Canvas.SetLeft(playerCars[2], Canvas.GetLeft(playerCars[2]) - 5);
            if (moveRight2 && playerCars.ContainsKey(2))
                Canvas.SetLeft(playerCars[2], Canvas.GetLeft(playerCars[2]) + 5);
            // Player 3
            if (moveUp3 && playerCars.ContainsKey(3))
                Canvas.SetTop(playerCars[3], Canvas.GetTop(playerCars[3]) - 5);
            if (moveDown3 && playerCars.ContainsKey(3))
                Canvas.SetTop(playerCars[3], Canvas.GetTop(playerCars[3]) + 5);
            if (moveLeft3 && playerCars.ContainsKey(3))
                Canvas.SetLeft(playerCars[3], Canvas.GetLeft(playerCars[3]) - 5);
            if (moveRight3 && playerCars.ContainsKey(3))
                Canvas.SetLeft(playerCars[3], Canvas.GetLeft(playerCars[3]) + 5);
            // Player 4
            if (moveUp4 && playerCars.ContainsKey(4))
                Canvas.SetTop(playerCars[4], Canvas.GetTop(playerCars[4]) - 5);
            if (moveDown4 && playerCars.ContainsKey(4))
                Canvas.SetTop(playerCars[4], Canvas.GetTop(playerCars[4]) + 5);
            if (moveLeft4 && playerCars.ContainsKey(4))
                Canvas.SetLeft(playerCars[4], Canvas.GetLeft(playerCars[4]) - 5);
            if (moveRight4 && playerCars.ContainsKey(4))
                Canvas.SetLeft(playerCars[4], Canvas.GetLeft(playerCars[4]) + 5);
        }
        private void RaceScreenPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GameCanvas.Height = e.NewSize.Height;
            GameCanvas.Width = e.NewSize.Width;


            squareSize = (int)((float)GameCanvas.Width / 200f);
            GenerateLevel();
            LoadCircuitData();
            SetUpPlayersList();
        }
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
