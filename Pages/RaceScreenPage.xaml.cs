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

        AutoRijden autoRijden = new AutoRijden();
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

            mainWindow.KeyDown += autoRijden.KnopIngedrukt;
            mainWindow.KeyUp += autoRijden.KnopLos;

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
                newCar.Height = 80;
                newCar.Fill = new ImageBrush( ImageColorConverter.ConvertColorToSource(uri, mainWindow.gameInfo.GetAllPlayers()[i - 1].GetColor().Color));
                Canvas.SetLeft(newCar, 400+i*60);
                Canvas.SetTop(newCar, 400);
                GameCanvas.Children.Add(newCar);

                playerCars[i] = newCar;
            }
        }
        void ChangeAngle(Rectangle newCar, int angle)
        {
            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.Angle = -angle;
            newCar.RenderTransform = rotateTransform;
            newCar.RenderTransformOrigin = new Point(.5, .5);
        }


        double currentSpeed1 = 0;
        double versnelling = 0.05;
        int topSpeed = 5;
        double bottomSpeed = -2.5;

        public void AutoMovementChecken(object sender, EventArgs e)
        {
            // Player 1
            if (autoRijden.moveUp1 && playerCars.ContainsKey(1))
            {
                if (currentSpeed1 < topSpeed)
                {
                    currentSpeed1 += versnelling;
                }
                double newTop = Canvas.GetTop(playerCars[1]) - currentSpeed1;
                if (!IsCollisionWithRedBarrier(playerCars[1], newTop))
                {
                    Canvas.SetTop(playerCars[1], newTop);
                }
                else
                {
                    StopCar(1);
                }
                Canvas.SetTop(playerCars[1], Canvas.GetTop(playerCars[1]) - currentSpeed1);
                //ChangeAngle(playerCars[1], 0);
            }
            
            if (autoRijden.moveDown1 && playerCars.ContainsKey(1))
            {
                if (currentSpeed1 > bottomSpeed)
                {
                    currentSpeed1 -= versnelling;

                }
                double newTop = Canvas.GetTop(playerCars[1]) - currentSpeed1;
                if (!IsCollisionWithRedBarrier(playerCars[1], newTop))
                {
                    Canvas.SetTop(playerCars[1], newTop);
                }
                else
                {
                    StopCar(1);
                }

                
            }
            if (autoRijden.moveUp1 == false && autoRijden.moveDown1 == false && currentSpeed1 >= bottomSpeed && currentSpeed1 <= topSpeed && currentSpeed1 != 0) 
            {
                
                if (currentSpeed1 < 0)
                    currentSpeed1 = currentSpeed1 + versnelling; // als currentSpeed > 0
                else if (currentSpeed1 > 0)
                    currentSpeed1 = currentSpeed1 - versnelling; // als currentSeed < 0
                Canvas.SetTop(playerCars[1], Canvas.GetTop(playerCars[1]) - currentSpeed1);
            }
            
            /* if (moveLeft1 && playerCars.ContainsKey(1))
             { 
                 Canvas.SetLeft(playerCars[1], Canvas.GetLeft(playerCars[1]) - 5);
                 ChangeAngle(playerCars[1], 90);
             }
             if (moveRight1 && playerCars.ContainsKey(1))
             {
                 Canvas.SetLeft(playerCars[1], Canvas.GetLeft(playerCars[1]) + 5);
                 ChangeAngle(playerCars[1], -90);
             }*/
            // Player 2
            if (autoRijden.moveUp2 && playerCars.ContainsKey(2))
            {
                Canvas.SetTop(playerCars[2], Canvas.GetTop(playerCars[2]) - 5);
                ChangeAngle(playerCars[2], 0);
            }

            if (autoRijden.moveDown2 && playerCars.ContainsKey(2))
            {
                Canvas.SetTop(playerCars[2], Canvas.GetTop(playerCars[2]) + 5);
                ChangeAngle(playerCars[2], 180);
            }
            if (autoRijden.moveLeft2 && playerCars.ContainsKey(2))
            {
                Canvas.SetLeft(playerCars[2], Canvas.GetLeft(playerCars[2]) - 5);
                ChangeAngle(playerCars[2], 90);
            }
            if (autoRijden.moveRight2 && playerCars.ContainsKey(2))
            {
                Canvas.SetLeft(playerCars[2], Canvas.GetLeft(playerCars[2]) + 5);
                ChangeAngle(playerCars[2], -90);
            }
            // Player 3
            if (autoRijden.moveUp3 && playerCars.ContainsKey(3))
            {
                Canvas.SetTop(playerCars[3], Canvas.GetTop(playerCars[3]) - 5);
                ChangeAngle(playerCars[3], 0);
            }

            if (autoRijden.moveDown3 && playerCars.ContainsKey(3))
            {
                Canvas.SetTop(playerCars[3], Canvas.GetTop(playerCars[3]) + 5);
                ChangeAngle(playerCars[3], 180);
            }
            if (autoRijden.moveUp3 && playerCars.ContainsKey(3))
            {
                Canvas.SetLeft(playerCars[3], Canvas.GetLeft(playerCars[3]) - 5);
                ChangeAngle(playerCars[3], 90);
            }
            if (autoRijden.moveRight3 && playerCars.ContainsKey(3))
            {
                Canvas.SetLeft(playerCars[3], Canvas.GetLeft(playerCars[3]) + 5);
                ChangeAngle(playerCars[3], -90);
            }
            // Player 4
            if (autoRijden.moveUp4 && playerCars.ContainsKey(4))
            {
                Canvas.SetTop(playerCars[4], Canvas.GetTop(playerCars[4]) - 5);
                ChangeAngle(playerCars[4], 0);
            }

            if (autoRijden.moveDown4 && playerCars.ContainsKey(4))
            {
                Canvas.SetTop(playerCars[4], Canvas.GetTop(playerCars[4]) + 5);
                ChangeAngle(playerCars[4], 180);
            }
            if (autoRijden.moveLeft4 && playerCars.ContainsKey(4))
            {
                Canvas.SetLeft(playerCars[4], Canvas.GetLeft(playerCars[4]) - 5);
                ChangeAngle(playerCars[4], 90);
            }
            if (autoRijden.moveRight4 && playerCars.ContainsKey(4))
            {
                Canvas.SetLeft(playerCars[4], Canvas.GetLeft(playerCars[4]) + 5);
                ChangeAngle(playerCars[4], -90);
            }
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
        private bool IsCollisionWithRedBarrier(Rectangle car, double newTop)
        {
            if (newTop < 0 || newTop + car.Height > GameCanvas.Height) return true;
            Rect carRect = new Rect(Canvas.GetLeft(car), newTop, car.Width, car.Height);

            foreach (var rect in recs.SelectMany(row => row))
            {
                if (GetBrushColor(CircuitSurfaces.Wall) == rect.Fill)
                {
                    Rect barrierRect = new Rect(Canvas.GetLeft(rect), Canvas.GetTop(rect), rect.Width, rect.Height);
                    if (carRect.IntersectsWith(barrierRect)) return true;
                }
            }
            return false;
        }
        private void StopCar(int playerNumber)
        {
            currentSpeed1 = 0;
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
