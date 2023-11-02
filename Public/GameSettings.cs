using ProjectGameInteraction2DRacingGame.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameInteraction2DRacingGame.Public
{
    public class GameSettings
    {
        static float musicVolume = 0.1f;
        static float _musicVolume
        {
            set
            {
                musicVolume = value;
                if (OnMusicVariableChange != null)
                    OnMusicVariableChange(musicVolume);
            }
            get { return musicVolume; }
        }
        public delegate void OnVariableChangeDelegate(float value);
        public static event OnVariableChangeDelegate OnMusicVariableChange;

        static float carVolume = 0.5f;
        static float effectsVolume = 0.5f;


        static int Translation = 0; //0 = Dutch, 1 = Frysk, 2 = English

        static int _Translation
        {
            set
            {
                Translation = value;
                OnTranslationVariableChange?.Invoke(Translation);
            }
            get { return Translation; }
        }
        public delegate void OnTranslationChangeDelegate(int value);
        public static event OnTranslationChangeDelegate OnTranslationVariableChange;

        public static float GetMusicVolume() => _musicVolume * 10;
        public static void SetMusicVolume(float volume = 5)
        {
            _musicVolume = volume / 10;
        }
        public static float GetCarVolume() => carVolume * 10;
        public static float GetEffectsVolume() => effectsVolume * 10;
        public static void SetCarVolume(float volume = 5)
        {
            carVolume = volume / 10;
        }
        public static void SetEffectsVolume(float volume = 5)
        {
            effectsVolume = volume / 10;
        }

        public static void SetTranslation(int translation = 0)
        {
            _Translation = translation;
            var languageManager = LanguageManager.Instance;
            languageManager.SetTitleTranslation();
        }
        public static int GetTranslation() => _Translation;
    }
}
