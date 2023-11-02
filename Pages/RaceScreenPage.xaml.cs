using ProjectGameInteraction2DRacingGame.Components;
using ProjectGameInteraction2DRacingGame.OOP;
using ProjectGameInteraction2DRacingGame.Public;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Timers;
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

        //Player list for the models and controls
        List<PlayerCar> cars = new List<PlayerCar>();

        public DispatcherTimer timer = new DispatcherTimer();
        DateTime start = DateTime.Now;

        public RaceScreenPage()
        {
            InitializeComponent();

            //Game Timer;
            timer.Interval = TimeSpan.FromMilliseconds(16);
            //timer.Tick += AutoMovementChecken;
            timer.Tick += UpdateRaceTimer;
            timer.Start();

            GameCanvas.Focus();
 
            SizeChanged += RaceScreenPage_SizeChanged;
            PausedFrame.Content = new PausedDialogComponent(PausedFrame);

            //Add this seperately as FindVisualChildren doesn't work properly
            positionFrames.Add(Position_1);
            positionFrames.Add(Position_2);
            positionFrames.Add(Position_3);
            positionFrames.Add(Position_4);
            DisplayPlayersInTower();
        }

        private void SetUpPlayersList()
        {
            for (int i = 0; i < mainWindow.gameInfo.GetAllPlayers().Count; i++)
            {
                //Create rectangle car
                var imageSource = $"SportsCar1_{mainWindow.gameInfo.GetAllPlayers()[i].GetCarID()}.png";
                var path = System.IO.Path.Combine("/Images/Autos", imageSource);
                Uri uri = new Uri(path, UriKind.Relative);
                Rectangle newCar = new Rectangle();

                newCar.Name = mainWindow.gameInfo.GetAllPlayers()[i].GetPlayerName();
                newCar.Width = 50;
                newCar.Height = 80;
                newCar.Fill = new ImageBrush( ImageColorConverter.ConvertColorToSource(uri, mainWindow.gameInfo.GetAllPlayers()[i].GetColor().Color));

                //Get current circuit
                Circuit circuit = mainWindow.Tracks.Find(x => x.GetTrackID() == mainWindow.gameInfo.GetTrackID()).GetCircuit();

                //Get canvas value from coords
                double valueLeft = Canvas.GetLeft(recs[circuit.spawnPositions[i].Y][circuit.spawnPositions[i].X]);
                double valueTop = Canvas.GetTop(recs[circuit.spawnPositions[i].Y][circuit.spawnPositions[i].X]);

                //And set them for the car
                Canvas.SetLeft(newCar, valueLeft);
                Canvas.SetTop(newCar, valueTop);

                //Rotate if necessary
                if (mainWindow.Tracks.Find(x => x.GetTrackID() == mainWindow.gameInfo.GetTrackID()).GetCircuit().spawnPositions[i].Rotation != 0)
                {
                    RotateTransform rotateTransform = new RotateTransform();
                    rotateTransform.Angle = mainWindow.Tracks.Find(x => x.GetTrackID() == mainWindow.gameInfo.GetTrackID()).GetCircuit().spawnPositions[i].Rotation;
                    newCar.RenderTransform = rotateTransform;
                    newCar.RenderTransformOrigin = new Point(.5, .5);

                    newCar.RenderTransform = rotateTransform;
                }
                //Create the playerCar
                PlayerCar playCar = new PlayerCar(mainWindow.gameInfo.GetAllPlayers()[i].GetPlayerID(), newCar, mainWindow.Tracks.Find(x => x.GetTrackID() == mainWindow.gameInfo.GetTrackID()).GetCircuit().spawnPositions[i].Rotation);
                GameCanvas.Children.Add(newCar);

                switch (i)
                {
                    default:
                        playCar.SetControls(new List<Key> { Key.W, Key.S, Key.A, Key.D });
                        break;
                    case 1:
                        playCar.SetControls(new List<Key> { Key.Up, Key.Down, Key.Left, Key.Right });
                        break;
                    case 2:
                        playCar.SetControls(new List<Key> { Key.I, Key.K, Key.J, Key.L });
                        break;
                    case 3:
                        playCar.SetControls(new List<Key> { Key.NumPad8, Key.NumPad5, Key.NumPad4, Key.NumPad6 });
                        break;
                };

                //Set events for each car
                mainWindow.KeyDown += delegate (object sender, KeyEventArgs e) { playCar.PressButtonEvent(e, playCar.Forward, playCar.Backward, playCar.Left, playCar.Right); };
                mainWindow.KeyUp += delegate (object sender, KeyEventArgs e) { playCar.ReleaseButtonEvent(e, playCar.Forward, playCar.Backward); };
                //mainWindow.KeyDown += playCar.PressButtonEvent;
                //mainWindow.KeyUp += playCar.ReleaseButtonEvent;
                playCar.carTimer.Tick += delegate
                {
                    CheckCarMovement(playCar);
                }; 
                playCar.carTimer.Start();
                cars.Add(playCar);
            }
        }

        public void UpdateRaceTimer(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - start;
            TimerText.Text = elapsed.ToString("mm\\:ss\\:fff");
        }
        public void CheckCarMovement(PlayerCar car)
        {
            if (car.isMovingForward && !car.isBlockedForwards)
            {
                if (car.CarSpeed < car.controller.topSpeed)
                {
                    car.isBlockedBackwards = false;
                    car.CarSpeed += car.controller.carAcceleration;
                }
                CheckCarShared(car, ref car.isBlockedForwards);
            }
            else if (car.isMovingBackward && !car.isBlockedBackwards)
            {
                if (car.CarSpeed > car.controller.bottomSpeed)
                {
                    car.isBlockedForwards = false;
                    car.CarSpeed -= car.controller.carAcceleration;
                }
                CheckCarShared(car, ref car.isBlockedBackwards);
            }
            else
            {
                if (car.CarSpeed > 0.1f)
                    car.CarSpeed -= car.controller.carAcceleration;
                else if (car.CarSpeed < -0.1f)
                    car.CarSpeed += car.controller.carAcceleration;
                else car.CarSpeed = 0;
            }

            car.controller.carX += car.CarSpeed * Math.Cos(car.controller.carRotation);
            car.controller.carY += car.CarSpeed * Math.Sin(car.controller.carRotation);
            Canvas.SetLeft(car.Car, car.controller.carX);
            Canvas.SetTop(car.Car, car.controller.carY);

            var rotateTransform = new RotateTransform(car.controller.carRotation * (180 / Math.PI) - 270, car.Car.Width / 2, car.Car.Height / 2);
            car.Car.RenderTransform = rotateTransform;
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
                        if (index! >= track.GetCircuit().Track.Count - 1)
                            recs[j][i].Fill = GetBrushColor(track.GetCircuit().Track[index].surfaceType);
                        else
                        {
                            if (track.GetCircuit().Track[index + 1].column == i && j == track.GetCircuit().Track[index + 1].row)
                                index++;
                            recs[j][i].Fill = GetBrushColor(track.GetCircuit().Track[index].surfaceType);
                        }
                    }
                }
            }
        }
        private bool IsCollisionWithRedBarrier(PlayerCar car, double newTop)
        {
            if (car.isBlockedForwards || car.isBlockedBackwards || newTop < 0 || newTop + car.Car.Height > GameCanvas.Height)
                return true;

            Rect carRect = new Rect(Canvas.GetLeft(car.Car), newTop, car.Car.Width, car.Car.Height);
            foreach (var rect in recs)
            {
                foreach (var item in rect.Where(x => ((SolidColorBrush)x.Fill).Color == ((SolidColorBrush)GetBrushColor(CircuitSurfaces.Wall)).Color))
                {
                    Rect barrierRect = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                    if (carRect.IntersectsWith(barrierRect))
                        return true;                    
                }
            }
            return false;
        }

        private void CheckCarShared(PlayerCar car, ref bool b)
        {
            Canvas.SetTop(car.Car, Canvas.GetTop(car.Car) - car.CarSpeed);

            double newTop = Canvas.GetTop(car.Car) - car.CarSpeed;
            if (IsCollisionWithRedBarrier(car, newTop))
            {
                car.CarSpeed = 0;
                b = true;
            }
            else
                Canvas.SetTop(car.Car, newTop);
        }

        Brush GetBrushColor(CircuitSurfaces type)
        {
            return type switch
            {
                CircuitSurfaces.Tarmac => new SolidColorBrush(mainWindow.Colors.GetColorGray()),
                CircuitSurfaces.Grass => new SolidColorBrush(mainWindow.Colors.GetColorGreen()),
                CircuitSurfaces.Sand => new SolidColorBrush(mainWindow.Colors.GetColorLightBrown()),
                CircuitSurfaces.Wall => new SolidColorBrush(mainWindow.Colors.GetColorRed()),
                CircuitSurfaces.checkpoint => new SolidColorBrush(mainWindow.Colors.GetColorWhite()),
                CircuitSurfaces.finishline => new SolidColorBrush(mainWindow.Colors.GetColorWhite()),
                CircuitSurfaces.asphalt2 => new SolidColorBrush(mainWindow.Colors.GetColorDarkGray()),
                CircuitSurfaces.dirt => new SolidColorBrush(mainWindow.Colors.GetColorLightYellow()),
                _ => new SolidColorBrush(mainWindow.Colors.GetColorBlack()),

            };
        }
    }
} 
