using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectGameInteraction2DRacingGame
{
    /// <summary>
    /// Interaction logic for Circuit.xaml
    /// </summary>
    public partial class Circuit : Window
    {
        int SnakeSquareSize = 50;
        public Circuit()
        {
            InitializeComponent();
            this.SizeChanged += OnWindowSizeChanged;

            //CreateRectangle(400, 0, new Thickness(500,25,500,30));


        }
        
        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            GameGrid.Height = e.NewSize.Height;
            GameGrid.Width = e.NewSize.Width;

            SnakeSquareSize = (int)((float)GameGrid.Width / 200f);
            GenerateLevel();
        }
        
        void CreateRectangle(int width, float angle, Thickness thickness)
        {
            Rectangle rec = new Rectangle
            {
                Width = width,
                Height = 10,
                Fill = Brushes.Blue,
                Margin = thickness
            };

            RotateTransform rt = new RotateTransform();
            rt.Angle = angle;   

            TransformGroup tg = new TransformGroup();
            tg.Children.Add(rt);

            rec.RenderTransform = tg;

            //Canvas.SetLeft(rec, left);
            //Canvas.SetRight(rec, 100);
            ////Canvas.SetTop(rec, top);
            //Canvas.SetBottom(rec, 970);

            gameCanvas.Children.Add(rec);
            

        }
        void GenerateLevel()
        {
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            bool nextIsOdd = false;

            int i = 0;

            while (doneDrawingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Fill = nextIsOdd ? Brushes.White : Brushes.Black
                };
                gameCanvas.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                nextIsOdd = !nextIsOdd;
                nextX += SnakeSquareSize;
                i++;



                int type = 1;
                switch (type)
                {
                    case 0:
                        rect.Fill = Brushes.Green;
                        break;
                    case 1:
                        rect.Fill = Brushes.Blue;
                        break;
                    case 2:
                        rect.Fill = Brushes.Black;
                        break;
                }
                if (i > 0 & i < 860)
                    rect.Fill = Brushes.Green;
                if (i > 870&i < 1069)
                    rect.Fill = Brushes.Gray;
                if (i >1086& i <1282)
                    rect.Fill = Brushes.White;
                if (i >1397& i <1403)
                        rect.Fill = Brushes.Black;

                if (nextX >= GameGrid.Width)
                {
                    nextX = 0;
                    nextY += SnakeSquareSize;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                }

                if (nextY >= GameGrid.Height)
                    doneDrawingBackground = true;
            }
        }
    }
}
