using Newtonsoft.Json;
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
using static ProjectGameInteraction2DRacingGame.Components.LanguageManager;

namespace ProjectGameInteraction2DRacingGame.Components
{
    /// <summary>
    /// Interaction logic for LeaderbordPrefabComponent.xaml
    /// </summary>
    public partial class LeaderbordPrefabComponent : Page
    {
        int Category;
        int Track;
        int Position;
        TimeSpan RaceTime;
        TimeSpan GapToLeader;
        public LeaderbordPrefabComponent(int category, int track, int positionIndex, string player, string raceTime, double width)
        {
            InitializeComponent();
            MainPanel.Width = width;
            Category = category;
            Track = track;
            SetPosition(positionIndex);
            SetPlayerName(player);
            SetRaceTime(raceTime);
            Loaded += NavigationService_Navigated;
            if (positionIndex < 4)
            {
                SetBackgroundColor();
                SetImage();
            }
        }
        private void NavigationService_Navigated(object sender, RoutedEventArgs e)
        {
            OnLanguageSwitchRequested();
        }
        public string LoadSelectedLanguage()
        {
            if (File.Exists("cache.json"))
            {
                // Lees de opgeslagen JSON uit het cachebestand
                string json = File.ReadAllText("cache.json");

                // Deserialiseer het JSON naar een object
                var languageData = JsonConvert.DeserializeObject<LanguageData>(json);

                return languageData.LanguageCode;
            }

            return "nl"; // Stel een standaard taalcode in als er niets is opgeslagen
        }
        public void OnLanguageSwitchRequested()
        {
            string languageCode = LoadSelectedLanguage();
            ResourceDictionary dict = new()
            {
                Source = new Uri($"../Resources/Strings.{languageCode}.xaml", UriKind.Relative)
            };

            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(dict);
        }
        public void SetPosition(int position)
        {
            Position = position;
            PositionText.Content = position.ToString();
        }
        public void SetPlayerName(string playerName)
        {
            PositionNameText.Content = playerName;
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
            TimeText.Content = RaceTime.ToString(@"m\:ss\.fff");
        }
        public void SetGapToLeader(TimeSpan leaderRaceTime)
        {
            TimeSpan GapToLeader = leaderRaceTime.Subtract(RaceTime);
            GapToLeaderText.Content = GapToLeader == TimeSpan.Zero ? "-" : "+" + (GapToLeader.TotalMinutes < 1 ? GapToLeader.ToString(@"ss\.fff") : GapToLeader.ToString(@"m\:ss\.fff"));
        }
        public void SetImage() => TrophyImage.Source = Position switch
        {
            1 => new BitmapImage(new Uri(Path.Combine("/Images", @"FirstPlaceTrophy.png"), UriKind.Relative)),
            2 => new BitmapImage(new Uri(Path.Combine("/Images", @"SecondPlaceTrophy.png"), UriKind.Relative)),
            3 => new BitmapImage(new Uri(Path.Combine("/Images", @"ThirdPlaceTrophy.png"), UriKind.Relative)),
            _ => new BitmapImage(new Uri(Path.Combine(""), UriKind.Relative)),
        };
        public void SetBackgroundColor()
        {
            BrushConverter brushConverter = new();
            Border.Background = Position switch
            {
                1 => brushConverter.ConvertFrom("#FFD600") as Brush,
                2 => brushConverter.ConvertFrom("#B1B1B1") as Brush,
                3 => brushConverter.ConvertFrom("#80450F") as Brush,
                _ => Brushes.Transparent,
            };
        }
        public int GetCategory() => Category;
        public int GetTrack() => Track;
        //public Grid GetGrid() => Grid;
        public TimeSpan GetGapToLeader() => GapToLeader;
        public TimeSpan GetRaceTime() => RaceTime;

    }
}
