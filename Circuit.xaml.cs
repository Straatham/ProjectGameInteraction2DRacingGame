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
        public Circuit()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Uri imageUri = new Uri("pack://application:,,,/ProjectGameInteraction2DRacinggame;component/images/circuit 3.png");
            BitmapImage imageSource = new BitmapImage(imageUri);
            myImage.Source = imageSource;

            CreateRectangle(239, 100, 400, 40);

        }
        void CreateRectangle(int left, int top, int width, float angle)
        {
            Rectangle rec = new Rectangle
            {
                Width = width,
                Height = 20,
                Fill = Brushes.Blue
             };

            TranslateTransform tt = new TranslateTransform();
            RotateTransform rt = new RotateTransform();
            rt.Angle = angle;   

            TransformGroup tg = new TransformGroup();
            tg.Children.Add(tt);
            tg.Children.Add(rt);

            rec.RenderTransform = tg;

            Canvas.SetLeft(rec, left);
            Canvas.SetTop(rec, top);

            gameCanvas.Children.Add(rec);


        }
    }
}
