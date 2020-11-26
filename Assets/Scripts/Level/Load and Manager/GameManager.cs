//Класс отвечает за происходящие на уровне действия. Поддерживает функции SpawnPoint(), DeletePoint(), AddInk(int ink),

using System;
using UnityEngine;
using UnityEngine.Serialization;

//Подключить классы unity

namespace Level.Load_and_Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;         //Ссылка на этот игровой менеджер

        [FormerlySerializedAs("rhythm_manager")] [Header("Rhytm Manager and Music Settings")]
        public RhythmManager rhythmManager;        //Ссылка на ритм менеджер
        [FormerlySerializedAs("highest_screen_point")] public float highestScreenPoint = 4f;     //самая высокая точка экрана
        [FormerlySerializedAs("music_volume")] public float musicVolume = 0.5f;           //громкость музыки
        [FormerlySerializedAs("point_acceleration")] public float pointAcceleration = 1.0f;     //Ускорение точек
        [FormerlySerializedAs("score_for_point_modificator")] public bool scoreForPointModificator = false;    //Модификатор очков за точку
        public int score = 0;                       //Текущие очки игрока
        [FormerlySerializedAs("audio_source")] public AudioSource audioSource;            //Источник звука
        [FormerlySerializedAs("audio_lenght")] public float audioLenght;                  //длинна аудио дорожки
        [NonSerialized] public readonly float musicDelay = 3;
        [FormerlySerializedAs("audio_clip")] public AudioClip audioClip;                //музыкальная дорожка уровня

        [FormerlySerializedAs("combometer_size")] [Header("UI")]
        public int combometerSize;                 //размер комбометра
        [FormerlySerializedAs("language_settings")] public int languageSettings = 0;           //текщие языковые настройки
        [FormerlySerializedAs("black_ink")] public int blackInk = 0;                   //Черные чернила
        [FormerlySerializedAs("current_record")] public int currentRecord;                  //текущий рекорд игрока
        [FormerlySerializedAs("attack_menu")] public AttackMenu attackMenu;              //Меню атак
        [FormerlySerializedAs("pause_menu")] public MenuManager pauseMenu;               //Меню паузы
        public GameObject progress;                 //прогресс игрока на уровне
        public GameObject combometer;               //игровой объект комбометра
        [FormerlySerializedAs("knight_healthbar")] public GameObject knightHealthbar;         //Шкала здоровья рыцаря
        private KnightHealth healthbar;             //полоска здоровья рыцаря
        private ProgressBar progress_bar;           //дорожка прогресса
        private bool isLoaded = false;              //загружен ли менеджер
        private void Awake()
        {
            instance = this;
        }

        //Функция вызывается при окончании работы загрузчика уровней
        public bool StartManager()
        {
            if (rhythmManager == null)
            {
                rhythmManager = RhythmManager.instance;
            }

            if (attackMenu == null)
            {
                attackMenu = AttackMenu.instance;
            }

            if (pauseMenu == null)
            {
                pauseMenu = MenuManager.instance;
            }

            if (knightHealthbar != null)   //Если здороровье включено
            {
                healthbar = knightHealthbar.GetComponent<KnightHealth>();  //получить ссылку на скрипт здоровья
            }

            if (progress != null)   //если прогресс включен
            {
                progress_bar = progress.GetComponent<ProgressBar>();    //получить ссылку на скрипт слайдер прогресса
            }

            audioSource = gameObject.GetComponent<AudioSource>(); //получить audioSource

            isLoaded = true;
            return isLoaded;
        }

        //Функция обновляет снаряжение
        public void UpdateEquipment(bool pointModifier, float volume)
        {
            scoreForPointModificator = pointModifier;
            audioSource.volume = volume;
        }

        //Функция вызывается в каждом кадре
        void Update()
        {
            if (progress_bar != null)
            {
                progress_bar.UpdateProgressBar(audioSource.time / audioLenght * 100.0f);
            }
        }

        //Функция добавляет чернила
        public void AddInk(int ink)
        {
            blackInk += ink;
        }

        //Функция добавляет очки
        public bool AddScore(bool isRed)
        {
            attackMenu.AddToKnight(isRed);
            if(!scoreForPointModificator)
            {
                score += rhythmManager.combo_count;
            }
            return true;
        }

        //Функция обновляет полоску здоровья
        public void UpdateHealthBar(int health)
        {
            if (healthbar != null)
            {
                healthbar.UpdateHealth(health);
            }
        }

        //Функция обновляет изображения
        public bool EnemyDefeat()
        {
            attackMenu.UpdateImages();
            return true;
        }

        //Добавить очко врагу
        public void AddToEnemy()
        {
            attackMenu.AddToEnemyCombometer();
        }

        //Включить поражение
        public void Defeat()
        {
            pauseMenu.ActivateDefeatScreen();
        }

        //Включить победу
        public void Victory()
        {
            pauseMenu.ActivateVictoryScreen();
        }

        //Функция срабатывает при сворачивании / развороте приложения
        public void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                pauseMenu.Pause();
            }
        }
    }
}