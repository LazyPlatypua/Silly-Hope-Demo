//Скрипт LevelLoader загружает сцену уровня, в том числе рыцаря, врагов, декораций, меню и подменю, интерфейса

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Level.Decoration;
using Level.FightGame;
using Scriptable_Objects;
using Temp;
using UnityEngine;

namespace Level.Load_and_Manager
{
    public class LevelLoader : MonoBehaviour
    {
        public static LevelLoader instance; //Ссылка на этот загрузчик уровня
        [Header("Scene Links")] 
        [Tooltip("Link to Game Manager.")] 
        public GameManager gameManager;
        [Tooltip("Link to Pause Menu.")] [NotNull] 
        public MenuManager pauseMenu;
        [Tooltip("Link to Rhythm Manager.")] [NotNull]
        public RhythmManager rhythmManager;
        [Tooltip("Link to Point Spawner.")] [NotNull]
        public PointSpawner pointSpawner;
        [Tooltip("Link to Attack Menu.")] [NotNull] 
        public AttackMenu attackMenu;
        
        private KnightBehaviour knightBehaviour;    //Ссылка на поведение рыцаря
        private List<GameObject> enemies;   //Список загруженных врагов

        [Header("Data"), Tooltip("Scriptable objects of locations. " +
                 "It must be 12 in total.")]
        public List<LocationData> locationDatas;
        [Tooltip("Scriptable objects of swords. " +
                 "It must be 8 in total.")]
        public List<SwordData> swordDatas;
        [Tooltip("Scriptable objects of charms. " +
                 "It must be 8 in total.")]
        public List<CharmData> charmDatas;

        [Header("UI")]
        public GameObject combometer;           //Комбометр на сцене
        

        [Header("Positions")]
        [Tooltip("Knight prefab")]public GameObject knightPrefab;
        public Vector3 decorationsPos;
        public Vector3 knightPosition;         //Позиция  рыцаря на экране
        public List<Vector3> enemiesPosition;  //Позиция врагов на экране

        [Header("Score and ink")]   //очки и чернила
        public short bestScore;    //Лучший результат
        public short blackInk;     //Количество чернил

        [Header("Settings")]        //Настройки игры
        public short language;      //Текущий язык
        public float masterVolume; //Общая громкость игры
        public float musicVolume;  //Громкость музыки
        public float sfxVolume;    //Громкость звуковых эффектов

        public int knightHealth = 5;                   //Здоровье рыцаря
        public bool scoreForPointModifier; //Модификатор для получнения очков за точки
        
        [Header("Settings")]    //Общие настройки
        public StringSettings stringSettings;                          //Файл с языками
        
        public Language.LanguageType
            languageSettings =
                Language.LanguageType
                    .English; //Выбор языка. 0 - английский, 1 - русский, 2 - немецкий, 3 - французский, 4 - эсперанто. В будущем написать класс для него и добавить в класс сохранений

        public float startRunningDelta = 3.0f;                        //разница между позицией врага и той, с которой он начинает дфижение

        //Функция срабатывает при включении сцены раньше Start
        private void Start()
        {
            instance = this;
            enemies = new List<GameObject>();

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
                             
            LoadEquipment(swordDatas[DataHolder.current_weapon], DataHolder.current_armor,
                new CharmData[3] {charmDatas[DataHolder.current_charm_0], charmDatas[DataHolder.current_charm_1],
                charmDatas[DataHolder.current_charm_2]});

            pauseMenu.gameIsPaused = true;
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
                    enemy.GetComponent<EnemyBehaviour>().spawnPointIndex = placement;
                    placement++;
                    if (placement >= enemiesPosition.Count)
                    {
                        placement = 0;
                    }
                }

                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyBehaviour>().attackMenu = this.attackMenu;
                    enemy.GetComponent<EnemyBehaviour>().gameManager = this.gameManager;
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

        //Функция загружает настройки, согласно снаряжению рыцаря
        private void LoadEquipment(SwordData currentWeapon, int currentArmor, CharmData[] charms)
        {
            gameManager.currentRecord = bestScore;
            gameManager.blackInk = blackInk;
            gameManager.pauseMenu = this.pauseMenu; 
            gameManager.UpdateEquipment(scoreForPointModifier, musicVolume);
            gameManager.StartManager();
            
            attackMenu.enemiesPosition = this.enemiesPosition;
            attackMenu.startRunningDelta = this.startRunningDelta;

            foreach (var charm in charms)
            {
                charm.ExecuteEffect();
            }
            
            knightHealth += currentArmor;
            attackMenu.StartAttackMenu(currentWeapon, DataHolder.combometer_size); 
            knightBehaviour.SetKnightBehaviour(knightHealth, currentWeapon, DataHolder.combometer_size);
            
            attackMenu.knightCombometer = knightBehaviour.GetCombometer();
        }
    }
}
