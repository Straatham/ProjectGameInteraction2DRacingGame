using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectGameInteraction2DRacingGame.Components
{
    public class LargeButtonSelectionComponentTest
    {
        int ID;
        TextBlock TrackNameText = new TextBlock();
        Image TrackImage = new Image();
        Button TrackSelectButton = new Button();

        public LargeButtonSelectionComponentTest(string name, int id, string source)
        {
            CreateButton();
            SetTrackName(name);
            SetID(id);
            SetTrackImage(source);
        }

        public void SetTrackName(string name)
        {
            TrackNameText.Text = name;
        }
        /// <summary>
        /// Set ID for the track, important!
        /// </summary>
        /// <param name="id"></param>
        public void SetID(int id)
        {
            ID = id;
        }
        public int GetID() => ID;
        /// <summary>
        /// Set image of the component, image source should be path to image
        /// </summary>
        /// <param name="imageSource"></param>
        public void SetTrackImage(string imageSource)
        {
            var path = Path.Combine("/Images", imageSource);
            TrackImage.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }
        public Button GetButton() => TrackSelectButton;


        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////
        ////    Code for generating the visual items
        ////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        
        void CreateButton()
        {
            var bc = new BrushConverter();
            TrackSelectButton = new Button
            {
                Background = Brushes.Transparent,
                Foreground = Brushes.Transparent,
                BorderBrush = (Brush)bc.ConvertFrom("#FFA800"),
                VerticalContentAlignment = VerticalAlignment.Stretch,
                BorderThickness = new Thickness(2),
                
            }; 
            Grid dock = new Grid
            {
                Margin = new Thickness(0),
            };
            TrackImage = new Image
            { 
                Margin = new Thickness(0, 0, 0, 60), 
                Stretch = Stretch.UniformToFill,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            dock.Children.Add(TrackImage);
            TrackNameText = new TextBlock
            {
                FontSize = 26,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 15),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
                //FontFamily = new FontFamily("file:///Font"),

            };
            dock.Children.Add(TrackNameText);
            TrackSelectButton.Content = dock;
        }
    }
}
