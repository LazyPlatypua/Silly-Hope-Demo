//Скрипт LevelLoader загружает сцену уровня, в том числе рыцаря, врагов, декораций, меню и подменю, интерфейса

using System;
using System.Collections.Generic;
using Level.Decoration;
using UnityEngine;

namespace Level.Load_and_Manager
{
    public class LevelLoader : MonoBehaviour
    {
        public static LevelLoader instance; //Ссылка на этот загрузчик уровня

        [Tooltip("Link to Game Manager"), Header("Scene Links")] 
        public GameManager gameManager;
        [Tooltip("Link to Pause Menu")] public MenuManager pauseMenu;
        [Tooltip("Link to Rhythm Manager")] public RhythmManager rhythmManager;
        [Tooltip("Link to Point Spawner")] public PointSpawner pointSpawner;
        [Tooltip("Link to Attack Menu")] public AttackMenu attackMenu;
        [Tooltip("Knight prefab")]public GameObject knightPrefab;
        private KnightBehaviour knightBehaviour;    //Ссылка на поведение рыцаря
        private List<GameObject> enemies;   //Список загруженных врагов

        [Header("Locations objects")] 
        [Tooltip("Scriptable objects of locations")]public List<LocationData> locationDatas;

        [Header("UI")]
        public GameObject combometer;           //Комбометр на сцене
        public GameObject knightHealthbar;     //Здоровье рыцаря на сцене
        public GameObject progress;             //Прогресс игрока на сцене

        [Header("Positions")]
        public Vector3 decorationsPos;
        public Vector3 knightPosition;         //Позиция  рыцаря на экране
        public List<Vector3> enemiesPosition;  //Позиция врагов на экране
        public Vector3 menuPosition;       //Позиция меню паузы
        public List<Vector3> pointSpawnPoint;     //Спавн точки для точек
        public Vector3 pointFinishPoint;          //Конечная точка для точек

        [Header("Score and ink")]   //очки и чернила
        public short bestScore;    //Лучший результат
        public short blackInk;     //Количество чернил

        [Header("Settings")]        //Настройки игры
        public short language;      //Текущий язык
        public float masterVolume; //Общая громкость игры
        public float musicVolume;  //Громкость музыки
        public float sfxVolume;    //Громкость звуковых эффектов

        [Header("Equipment Settings")]  //Настройки снаряжения
        public int swordDamageModificator = 0;        //Модификатор урона меча
        public int knightHealth = 5;                   //Здоровье рыцаря
        public bool scoreForPointModifier; //Модификатор для получнения очков за точки
        public int combometerNeededPoints = 3;        //Количество точек, необходимых для заполнения одной ячейки комбометра
        private readonly Figures figure = null;                   //Фигура для спецприема

        //Музыка
        public List<AudioClip> audioClips;                             //Список музыкальных дорожек уровней

        [Header("Settings")]    //Общие настройки
        public StringSettings stringSettings;                          //Файл с языками
        
        public Language.LanguageType
            languageSettings =
                Language.LanguageType
                    .english; //Выбор языка. 0 - английский, 1 - русский, 2 - немецкий, 3 - французский, 4 - эсперанто. В будущем написать класс для него и добавить в класс сохранений
        public float travelTime = 2.5f;                                //Время достижения точкой конца экрана
        public float startRunningDelta = 3.0f;                        //разница между позицией врага и той, с которой он начинает дфижение
        public float endline = 6f;                                   //конец экрана

        //Функция срабатывает при включении сцены раньше Start
        private void Start()
        {
            instance = this;

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            enemies = new List<GameObject>();

            if(gameManager == null)
            {
                gameManager = GameManager.instance;
            }

            if(pauseMenu == null)
            {
                pauseMenu = MenuManager.instance;
            }

            if (attackMenu == null)
            {
                attackMenu = AttackMenu.instance;
            }

            if(rhythmManager == null)
            {
                rhythmManager = RhythmManager.instance;
            }

            if (pointSpawner == null)
            {
                pointSpawner = PointSpawner.instance;
            }

            if (DataHolder.current_scene >= 3)
            {
                DataHolder.combometer_size = 2;
                if (DataHolder.current_scene >= 8)
                {
                    DataHolder.combometer_size = 3;
                }
            }
            else
            {
                DataHolder.combometer_size = 1;
            }

            masterVolume = DataHolder.master_volume; 
            musicVolume = DataHolder.music_volume;  
            sfxVolume = DataHolder.sfx_volume;   

            LoadLocation(locationDatas[DataHolder.current_scene]); 
            LoadUI();
                             
            LoadEquipment(DataHolder.current_weapon, DataHolder.current_armor, DataHolder.current_charm_0, DataHolder.current_charm_1, DataHolder.current_charm_2); 
            GameManagerSettings();    
        
            attackMenu.enemies_position = this.enemiesPosition;
            attackMenu.start_running_delta = this.startRunningDelta;
            attackMenu.StartAttackMenu(swordDamageModificator, DataHolder.combometer_size, combometerNeededPoints, DataHolder.current_weapon);   
            attackMenu.knight_combometer = knightBehaviour.SetKnightBehaviour(knightHealth, DataHolder.current_weapon, DataHolder.combometer_size, figure); 
        
            pauseMenu.game_is_paused = true;
            pauseMenu.SetPosition();
        }

        private void LoadLocation(LocationData locationData)
        {
            {   // Спавн декораций
                DecorationsScript decorationsScript =
                    Instantiate(locationData.decorationPrefab, decorationsPos, Quaternion.identity)
                        .GetComponent<DecorationsScript>() ?? throw new ArgumentNullException(
                        nameof(locationData));
                decorationsScript.SetUpGraphics(Convert.ToBoolean((int) DataHolder.graphics_tier));
            }

            {     // Спавн рыцаря
                knightBehaviour = Instantiate(knightPrefab, knightPosition, Quaternion.Euler(0.0f, 180.0f, 0.0f))
                    .GetComponent<KnightBehaviour>();
            }

            {   // Спавн врагов
                int placement = 0;
                GameObject newGo;
                System.Diagnostics.Debug.Assert(locationData.enemiesPrefabs != null,
                    "locationData.enemiesPrefabs != null");
                foreach (GameObject enemy in locationData.enemiesPrefabs)
                {
                    newGo = Instantiate(enemy,
                        new Vector3(enemiesPosition[placement].x + startRunningDelta, enemiesPosition[placement].y,
                            enemiesPosition[placement].z), Quaternion.identity);
                    newGo.SetActive(false);
                    enemies.Add(newGo);
                    enemy.GetComponent<EnemyBehaviour>().position = enemiesPosition[placement];
                    enemy.GetComponent<EnemyBehaviour>().spawn_point_index = placement;
                    placement++;
                    if (placement >= enemiesPosition.Count)
                    {
                        placement = 0;
                    }
                }

                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyBehaviour>().attack_menu = this.attackMenu;
                    enemy.GetComponent<EnemyBehaviour>().game_manager = this.gameManager;
                }

                attackMenu.enemies = this.enemies;
            }

            {    // Настройки ритм менеджера и спавнера точек
                
                gameManager.audioClip = locationData.audioClip;
                pointSpawner.StartPointSpawner(locationData, rhythmManager, gameManager);
                rhythmManager.StartRhytmManager();
            }
        }
        
        //Функция подгружает интерфейс игрока на уровне
        private void LoadUI()
        {
            stringSettings = new StringSettings(Language.LanguageToInt(languageSettings));

            pauseMenu.SetMenu(stringSettings);

            gameManager.attackMenu = attackMenu;
            gameManager.pauseMenu = pauseMenu;
            gameManager.combometer = combometer;

            pauseMenu.DeactivateMenu();

        }

        //Настроить игровой менеджер
        private void GameManagerSettings()
        {
            gameManager.currentRecord = bestScore; //Текущий рекорд игрока
            gameManager.blackInk = blackInk; //Общее количество добытых чернил
            gameManager.pauseMenu = this.pauseMenu; //ссылка на меню паузы

            gameManager.UpdateEquipment(scoreForPointModifier, musicVolume);

            gameManager.StartManager();
        }

        //Функция загружает настройки, согласно снаряжению рыцаря
        private void LoadEquipment(int currentWeapon, int currentArmor, int currentCharm0, int currentCharm1, int currentCharm2)
        {
            //current_equipment index = 0 - оружие, = 1 - броня, = 2 - талисман 1, = 3 - талисман 2, = 4 - талисман 3

            //оружие
            switch (currentWeapon)
            {
                case 0: //длинный меч
                
                    break;

                case 1: //сломанный меч
                
                    break;

                case 2: //фальшион

                    break;

                case 3: //двуручный меч 
                
                    break;

                case 4: //Меч святого Петра
                
                    //figure = new Figures("Zet");
                    break;

                case 5: //кинжал из крови святого Януария
                
                    //figure = new Figures("Omega");
                    break;

                case 6: //Венское копье
                
                    //figure = new Figures("Mu");
                    break;

                case 7: //Меч, покрытый елеем
                
                    //figure = new Figures("Sigma");
                    break;

                default:
                    Debug.LogError("LevelLoader.LoadEquipment(): undefined sword!");
                    break;
            }

            //броня
            knightHealth += currentArmor;

            //талисманы
            switch (currentCharm0)
            {
                case 1:
                    swordDamageModificator += 1; //Талисман благоденствия
                    break;

                case 2:
                    combometerNeededPoints = 6; //Таллисман еретика
                    knightHealth += 1;
                    break;

                case 3:
                    knightHealth += 1;    //Талисман ордена
                    break;

                case 4:
                    combometerNeededPoints = 1;    //Нагрудный крест
                    scoreForPointModifier = true;
                    break;

                case 5:
                    gameManager.progress = this.progress; //Навершие из слоновой кости
                    progress.SetActive(true);
                    break;

                case 6:
                    knightHealthbar.SetActive(true);    //Печать папы
                    break;

                case 7:
                    musicVolume = 1.0f;  //Подвеска предателя
                    break;

                default:
                    Debug.Log("LevelLoader.LoadEquipment(): undefined Charm");
                    break;
            }

            switch (currentCharm1)
            {
                case 1:
                    swordDamageModificator += 1; //Талисман благоденствия
                    break;

                case 2:
                    combometerNeededPoints = 6; //Таллисман еретика
                    knightHealth += 1;
                    break;

                case 3:
                    knightHealth += 1;    //Талисман ордена
                    break;

                case 4:
                    combometerNeededPoints = 1;    //Нагрудный крест
                    scoreForPointModifier = true;
                    break;

                case 5:
                    gameManager.progress = this.progress; //Навершие из слоновой кости
                    progress.SetActive(true);
                    break;

                case 6:
                    knightHealthbar.SetActive(true);    //Печать папы
                    break;

                case 7:
                    musicVolume = 1.0f;  //Подвеска предателя
                    break;

                default:
                    Debug.Log("LevelLoader.LoadEquipment(): undefined Charm");
                    break;
            }

            switch (currentCharm2)
            {
                case 1:
                    swordDamageModificator += 1; //Талисман благоденствия
                    break;

                case 2:
                    combometerNeededPoints = 6; //Таллисман еретика
                    knightHealth += 1;
                    break;

                case 3:
                    knightHealth += 1;    //Талисман ордена
                    break;

                case 4:
                    combometerNeededPoints = 1;    //Нагрудный крест
                    scoreForPointModifier = true;
                    break;

                case 5:
                    gameManager.progress = this.progress; //Навершие из слоновой кости
                    progress.SetActive(true);
                    break;

                case 6:
                    knightHealthbar.SetActive(true);    //Печать папы
                    break;

                case 7:
                    musicVolume = 1.0f;  //Подвеска предателя
                    break;

                default:
                    Debug.Log("LevelLoader.LoadEquipment(): undefined Charm");
                    break;
            }
            knightBehaviour.default_health = knightHealth;


            if ((currentCharm0 == 4 || currentCharm1 == 4 || currentCharm2 == 4) && (currentCharm0 == 2 || currentCharm1 == 2 || currentCharm2 == 2))
            {
                combometerNeededPoints = 1;
            }

        }
    }
}
