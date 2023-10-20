﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectGameInteraction2DRacingGame.Components
{
    /// <summary>
    /// Interaction logic for AudioOptionsComponent.xaml
    /// </summary>
    public partial class AudioOptionsComponent : Page
    {
        public AudioOptionsComponent()
        {
            InitializeComponent();
            LanguageManager.Instance.LanguageSwitchRequested += OnLanguageSwitchRequested;
        }
        public void OnLanguageSwitchRequested(string languageCode)
        {
            ResourceDictionary dict = new ResourceDictionary()
            {
                Source = new Uri($"../Resources/Strings.{languageCode}.xaml", UriKind.Relative)
            };

            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dict);
        }
    }
}
