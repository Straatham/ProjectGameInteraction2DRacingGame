using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectGameInteraction2DRacingGame.Components
{
    public class LeaderbordEntryComponent
    {
        int Category;
        int Track;
        int Position;
        string PlayerName;
        TimeSpan RaceTime;
        TimeSpan GapToLeader;

        Grid Grid = new Grid();

        public LeaderbordEntryComponent(int category, int track, int positionIndex, string player, string raceTime)
        {
            Category = category;
            Track = track;
            SetPosition(positionIndex);
            SetPlayerName(player);
            SetRaceTime(raceTime);
            CreateItems();
        }
        public void SetPosition(int position)
        {
            Position = position;
        }
        public void SetPlayerName(string playerName)
        {
            PlayerName = playerName;
        }
        public void SetCategory(int category)
        {
            Category = category;
        }
        public void SetTrack(int track)
        {
            Track = track;
        }
        public void SetRaceTime(string raceTime)
        {
            RaceTime = TimeSpan.ParseExact(raceTime, @"m\:ss\.fff", System.Globalization.CultureInfo.CurrentCulture);
        }
        public void SetGapToLeader(TimeSpan leaderRaceTime)
        {
            GapToLeader = leaderRaceTime.Subtract(RaceTime);
        }
        public int GetCategory() => Category;
        public int GetTrack() => Track;
        public Grid GetGrid() => Grid;
        public TimeSpan GetGapToLeader() => GapToLeader;
        public TimeSpan GetRaceTime() => RaceTime;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////
        ////    Code for generating the visual items
        ////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        void CreateItems()
        {
            Grid = CreateBaseGrid();
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(80, GridUnitType.Pixel);
            Grid.ColumnDefinitions.Add(c1);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(1085, GridUnitType.Pixel);
            Grid.ColumnDefinitions.Add(c2);

            //creating the image if necessary
            Image image = CreateImage();
            image.SetValue(Grid.ColumnProperty, 0);
            Grid.Children.Add(image);

            Border border = CreateBorder();

            Grid grid = CreateGrid();
            ColumnDefinition column1 = new ColumnDefinition();
            column1.Width = new GridLength(80, GridUnitType.Pixel);
            grid.ColumnDefinitions.Add(column1);

            column1 = new ColumnDefinition();
            column1.Width = new GridLength(550, GridUnitType.Pixel);
            grid.ColumnDefinitions.Add(column1);

            column1 = new ColumnDefinition();
            column1.Width = new GridLength(200, GridUnitType.Pixel);
            grid.ColumnDefinitions.Add(column1);

            column1 = new ColumnDefinition();
            column1.Width = new GridLength(250, GridUnitType.Pixel);
            grid.ColumnDefinitions.Add(column1);

            TextBlock block = CreatePositionText();
            grid.Children.Add(block);
            block.SetValue(Grid.ColumnProperty, 0);

            TextBlock player = CreatePlayerNameText();
            grid.Children.Add(player);
            player.SetValue(Grid.ColumnProperty, 1);

            TextBlock raceTime = CreateRaceTimeText();
            grid.Children.Add(raceTime);
            raceTime.SetValue(Grid.ColumnProperty, 2);

            TextBlock gap = CreateGapToLeaderText();
            grid.Children.Add(gap);
            gap.SetValue(Grid.ColumnProperty, 3);

            border.SetValue(Grid.ColumnProperty, 1);
            border.Child = grid;
            Grid.Children.Add(border);
        }
        Grid CreateBaseGrid()
        {
            Grid grid = new Grid
            {
                Height = 54,
                Name = "DockPanelEntry",
                Margin = new Thickness(10,0,10,0),
                VerticalAlignment = VerticalAlignment.Center,
                ShowGridLines = true,
            }; 
            return grid;
        }
        Image CreateImage()
        {
            return new Image
            {
                Width = 54,
                Height = 54,
                Margin = new Thickness(0,0,0,0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                
                Source = Position switch
                {
                    1 => new BitmapImage(new Uri(Path.Combine("/Images", @"FirstPlaceTrophy.png"), UriKind.Relative)),
                    2 => new BitmapImage(new Uri(Path.Combine("/Images", @"SecondPlaceTrophy.png"), UriKind.Relative)),
                    3 => new BitmapImage(new Uri(Path.Combine("/Images", @"ThirdPlaceTrophy.png"), UriKind.Relative)),
                    _ => new BitmapImage(new Uri(Path.Combine(""), UriKind.Relative)),
                },
            };
        }
        Border CreateBorder()
        {
            BrushConverter brushConverter = new BrushConverter();
            return new Border
            {
                BorderBrush = (Brush)brushConverter.ConvertFrom("#1F1F1F"),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0,0,0,0),
                Height = 54,
                Background = Position switch
                {
                    1 => (Brush)brushConverter.ConvertFrom("#FFD600"),
                    2 => (Brush)brushConverter.ConvertFrom("#B1B1B1"),
                    3 => (Brush)brushConverter.ConvertFrom("#80450F"),
                    _ => Brushes.Transparent,
                },
            }; 
        }
        Grid CreateGrid()
        {
            return new Grid
            {
                Height = 54,
                Margin = new Thickness(0,-1,0,0),
            };
        }
        TextBlock CreatePositionText()
        {
            return new TextBlock
            {
                FontSize = 42,
                Text = Position.ToString(),
                Foreground = new SolidColorBrush(Colors.White),
                Width = 40,
                HorizontalAlignment = HorizontalAlignment.Center,
                //FontFamily = new FontFamily("file:///Font"),
            };
        }
        TextBlock CreatePlayerNameText()
        {
            return new TextBlock
            {
                FontSize = 42,
                Text = PlayerName,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10,10,0,0),
                Padding = new Thickness(0, 0, 0, 10),
                TextWrapping = TextWrapping.NoWrap,
                //FontFamily = new FontFamily("file:///Font"),
            };
        }
        TextBlock CreateRaceTimeText()
        {
            return new TextBlock
            {
                FontSize = 42,
                Text = RaceTime.ToString(@"m\:ss\.fff"),
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(20, 0, 0, 0),
                Padding = new Thickness(0, 0, 0, 10),
                TextWrapping = TextWrapping.NoWrap,
                //FontFamily = new FontFamily("file:///Font"),
            };
        }
        TextBlock CreateGapToLeaderText()
        {
            return new TextBlock
            {
                FontSize = 42,
                Text = GapToLeader == TimeSpan.Zero ? "-" : "+" + (GapToLeader.TotalMinutes < 1 ? GapToLeader.ToString(@"ss\.fff") : GapToLeader.ToString(@"m\:ss\.fff")),
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(20, 0, 30, 0),
                Padding = new Thickness(0, 0, 0, 10),
                TextWrapping = TextWrapping.NoWrap,
                //FontFamily = new FontFamily("file:///Font"),
            };
        }
    }
}
