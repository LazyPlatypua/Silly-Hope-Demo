//Скрипт LevelLoader загружает сцену уровня, в том числе рыцаря, врагов, декораций, меню и подменю, интерфейса

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization; //Подключить списки

//Подключить классы unity

namespace Level.Load_and_Manager
{
    public class LevelLoader : MonoBehaviour
    {
        public static LevelLoader instance; //Ссылка на этот загрузчик уровня
        [FormerlySerializedAs("game_manager")] [Header("Scene Links")]
        public GameManager gameManager;    //Ссылка на игровой менеджер
        [FormerlySerializedAs("pause_menu")] public MenuManager pauseMenu;           //Меню паузы на сцене
        [FormerlySerializedAs("rhythm_manager")] public RhythmManager rhythmManager;   //ссылка на менеждер ритм игры
        public PointSpawner pointSpawner;   //спавнер точек
        [FormerlySerializedAs("attack_menu")] public AttackMenu attackMenu;  //Ссылка на меню атак
        private KnightBehaviour knightBehaviour;    //Ссылка на поведение рыцаря
        private List<GameObject> enemies;   //Список загруженных врагов

        [FormerlySerializedAs("point_images")] [Header("Creature and points prefab")]
        public List<Sprite> pointImages;
        [FormerlySerializedAs("knight_prefab")] public GameObject knightPrefab;            //Префаб рыцаря
        [FormerlySerializedAs("enemies_location_1")] public List<GameObject> enemiesLocation1; //Префабы врагов первой локации (деревня Унхаймберг) [0 - житель с серпом, 1 - житель с совками, 2 - житель с граблями, 3 - житель с лопатой]
        [FormerlySerializedAs("enemies_location_2")] public List<GameObject> enemiesLocation2; //Префабы врагов второй локации (Узловатый лес) [0 - заяц, 1 - боров, 2 - дриада, 3 - мантикора]
        [FormerlySerializedAs("enemies_location_3")] public List<GameObject> enemiesLocation3; //Префабы врагов третьей локации (Могильник - первый этаж) [0 - скелет с мечом, 1 - скелет с клевцом]
        [FormerlySerializedAs("enemies_location_4")] public List<GameObject> enemiesLocation4; //Префабы врагов третьей локации (Могильник - лаборатории) [0 - экаеримент 1, 1 - эксперимент 2]
        [FormerlySerializedAs("enemies_location_5")] public List<GameObject> enemiesLocation5; //Префабы врагов третьей локации (Могильник - силуэты) [0 - 12]
        [FormerlySerializedAs("enemies_memories")] public List<GameObject> enemiesMemories;   //Префабы врагов воспомнаний Себастьяна
        [FormerlySerializedAs("enemies_bosses")] public List<GameObject> enemiesBosses;     //Префабы боссов. [0 - Энт, 1 - Бральтаир]

        public DecorationsScript decorationsScript;

        [FormerlySerializedAs("village_background")] [Header("Локации: Деревня")]
        public GameObject villageBackground;    //Префаб предустановленных декораций первой локации (деревня Унхаймберг)

        [FormerlySerializedAs("forest_background")] [Header("Локации: Лес")]
        public GameObject forestBackground;    //Префаб предустановленных декораций второй локации (Узловатый лес)

        [FormerlySerializedAs("dungeon_background")] [Header("Локации: Могильник - темница")]
        public GameObject dungeonBackground;    //Префаб предустановленных декораций третьей локации (Могильник - первый этаж)

        [FormerlySerializedAs("labs_background")] [Header("Локации: Могильник - лаборатории")]
        public GameObject labsBackground;    //Префаб предустановленных декораций четвертой локации (Могильник - лаборатории)

        [FormerlySerializedAs("throne_background")] [Header("Локации: Могильник - тронный зал")]
        public GameObject throneBackground;    //Префаб предустановленных декораций третьей локации (Могильник - тронный зал)

        [FormerlySerializedAs("castle_background")] [Header("Локации: Воспоминания - замок")]
        public GameObject castleBackground;  //Префаб предустановленных декораций локации воспоминаний

        [Header("UI")]
        public GameObject combometer;           //Комбометр на сцене
        [FormerlySerializedAs("knight_healthbar")] public GameObject knightHealthbar;     //Здоровье рыцаря на сцене
        public GameObject progress;             //Прогресс игрока на сцене

        [FormerlySerializedAs("decorations_pos")] [Header("Positions")]
        public Vector3 decorationsPos;
        [FormerlySerializedAs("knight_position")] public Vector3 knightPosition;         //Позиция  рыцаря на экране
        [FormerlySerializedAs("enemies_position")] public List<Vector3> enemiesPosition;  //Позиция врагов на экране
        [FormerlySerializedAs("uni_menu_position")] public Vector3 menuPosition;       //Позиция меню паузы
        [FormerlySerializedAs("point_spawn_point")] public List<Vector3> pointSpawnPoint;     //Спавн точки для точек
        [FormerlySerializedAs("point_finish_point")] public Vector3 pointFinishPoint;          //Конечная точка для точек

        [FormerlySerializedAs("best_score")] [Header("Score and ink")]   //очки и чернила
        public short bestScore;    //Лучший результат
        [FormerlySerializedAs("black_ink")] public short blackInk;     //Количество чернил

        [Header("Settings")]        //Настройки игры
        public short language;      //Текущий язык
        [FormerlySerializedAs("master_volume")] public float masterVolume; //Общая громкость игры
        [FormerlySerializedAs("music_volume")] public float musicVolume;  //Громкость музыки
        [FormerlySerializedAs("sfx_volume")] public float sfxVolume;    //Громкость звуковых эффектов

        [FormerlySerializedAs("sword_damage_modificator")] [Header("Equipment Settings")]  //Настройки снаряжения
        public int swordDamageModificator = 0;        //Модификатор урона меча
        [FormerlySerializedAs("knight_health")] public int knightHealth = 5;                   //Здоровье рыцаря
        [FormerlySerializedAs("score_for_point_modifier")]
        public bool scoreForPointModifier; //Модификатор для получнения очков за точки
        [FormerlySerializedAs("combometer_needed_points")] public int combometerNeededPoints = 3;        //Количество точек, необходимых для заполнения одной ячейки комбометра
        private readonly Figures figure = null;                   //Фигура для спецприема

        [FormerlySerializedAs("audio_clips")] [Header("Music")]   //Музыка
        public List<AudioClip> audioClips;                             //Список музыкальных дорожек уровней

        [FormerlySerializedAs("string_settings")] [Header("Settings")]    //Общие настройки
        public StringSettings stringSettings;                          //Файл с языками
        [FormerlySerializedAs("language_settings")]
        public Language.LanguageType
            languageSettings =
                Language.LanguageType
                    .english; //Выбор языка. 0 - английский, 1 - русский, 2 - немецкий, 3 - французский, 4 - эсперанто. В будущем написать класс для него и добавить в класс сохранений
        [FormerlySerializedAs("travel_time")] public float travelTime = 2.5f;                                //Время достижения точкой конца экрана
        [FormerlySerializedAs("start_running_delta")] public float startRunningDelta = 3.0f;                        //разница между позицией врага и той, с которой он начинает дфижение
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

            LoadDecorations(DataHolder.current_scene);              
            LoadCreatures(DataHolder.current_scene);    
            LoadUI();

            RhytmGameSettings(DataHolder.current_scene);                                        
            LoadEquipment(DataHolder.current_weapon, DataHolder.current_armor, DataHolder.current_charm_0, DataHolder.current_charm_1, DataHolder.current_charm_2); 
            GameManagerSettings();    
        
            attackMenu.enemies_position = this.enemiesPosition;
            attackMenu.start_running_delta = this.startRunningDelta;
            attackMenu.StartAttackMenu(swordDamageModificator, DataHolder.combometer_size, combometerNeededPoints, DataHolder.current_weapon);   
            attackMenu.knight_combometer = knightBehaviour.SetKnightBehaviour(knightHealth, DataHolder.current_weapon, DataHolder.combometer_size, figure); 
        
            pauseMenu.game_is_paused = true;
            pauseMenu.SetPosition();
        }

        //Функция подгружает декорации на уровне
        private void LoadDecorations(int currentScene)
        {
            switch (currentScene)
            {
                case 0:
                case 1:
                case 2:
                {
                    if (villageBackground != null)
                        decorationsScript =
                            Instantiate(villageBackground, decorationsPos, Quaternion.identity)
                            .GetComponent<DecorationsScript>();
                    break;
                }

                case 3:
                {
                    goto case 5;
                }

                case 4:
                {
                    if (castleBackground != null)
                    {
                        decorationsScript =
                            Instantiate(castleBackground, decorationsPos, Quaternion.identity)
                            .GetComponent<DecorationsScript>();
                    }

                    break;
                }

                case 5:
                case 6:
                case 7:
                {
                    if (forestBackground != null)
                        decorationsScript =
                            Instantiate(forestBackground, decorationsPos, Quaternion.identity)
                            .GetComponent<DecorationsScript>();
                    break;
                }

                case 8:
                {
                    if(dungeonBackground != null)
                        decorationsScript =
                            Instantiate(dungeonBackground, decorationsPos, Quaternion.identity)
                            .GetComponent<DecorationsScript>();
                    break;
                }

                case 9:
                {
                    if (labsBackground != null)
                        decorationsScript =
                            Instantiate(labsBackground, decorationsPos, Quaternion.identity)
                            .GetComponent<DecorationsScript>();
                    break;
                }

                case 10:
                case 11:
                {
                    if (throneBackground != null)
                        decorationsScript =
                            Instantiate(throneBackground, decorationsPos, Quaternion.identity)
                            .GetComponent<DecorationsScript>();
                    break;
                }

                default:
                {
                    Debug.LogError("LevelLoader.LoadDecorations(): cutscene is not recognised");
                    break;
                }
            }
            decorationsScript.SetUpGraphics(Convert.ToBoolean((int)DataHolder.graphics_tier));
        }

        //Функция подгружает существ на уровень
        private int LoadCreatures(int currentScene)
        {
            knightBehaviour = Instantiate(knightPrefab, knightPosition, Quaternion.Euler(0.0f, 180.0f, 0.0f))
                .GetComponent<KnightBehaviour>();

            int i;
            if (enemiesLocation1 != null)
            {
                GameObject firstEnemy = enemiesLocation1[0];
                GameObject newGo;
                switch (currentScene)
                {
                    case 0:
                    case 1:
                    case 2:
                    {
                        //Деревня
                        i = 0;
                        enemies.Clear();
                        foreach (GameObject enemy in enemiesLocation1)
                        {
                            newGo = Instantiate(enemy,
                                new Vector3(enemiesPosition[i].x + startRunningDelta, enemiesPosition[i].y,
                                    enemiesPosition[i].z), Quaternion.identity);
                            newGo.SetActive(false);
                            enemies.Add(newGo);
                            enemy.GetComponent<EnemyBehaviour>().position = enemiesPosition[i];
                            enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                            i++;
                            if (i >= enemiesPosition.Count)
                            {
                                i = 0;
                            }
                        }
                        break;
                    }

                    case 3:
                    {
                        //Лес, заяц и боров
                        enemies.Clear();

                        newGo = Instantiate(enemiesLocation2[0],
                            new Vector3(enemiesPosition[2].x + startRunningDelta, enemiesPosition[2].y,
                                enemiesPosition[2].z), Quaternion.identity);
                        newGo.SetActive(false);
                        enemies.Add(newGo);
                        newGo.GetComponent<EnemyBehaviour>().spawn_point_index = 2;
                        newGo.GetComponent<EnemyBehaviour>().position = enemiesPosition[2];

                        newGo = Instantiate(enemiesLocation2[1],
                            new Vector3(enemiesPosition[1].x + startRunningDelta, enemiesPosition[1].y,
                                enemiesPosition[1].z), Quaternion.identity);
                        newGo.SetActive(false);
                        enemies.Add(newGo);
                        newGo.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                        newGo.GetComponent<EnemyBehaviour>().position = enemiesPosition[1];
                        break;
                    }

                    case 4:
                        //Воспоминания
                        enemies.Clear();

                        i = 0;
                        foreach (GameObject enemy in enemiesMemories)
                        {
                            newGo = Instantiate(enemy,
                                new Vector3(enemiesPosition[i].x + startRunningDelta, enemiesPosition[i].y,
                                    enemiesPosition[i].z), Quaternion.identity);
                            newGo.SetActive(false);
                            enemies.Add(newGo);
                            enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                            enemy.GetComponent<EnemyBehaviour>().position = enemiesPosition[i];

                            i++;
                            if (i >= enemiesMemories.Count - 1)
                            {
                                i = 0;
                            }
                        }
                        break;

                    case 5:
                    case 6:
                        //Лес, все враги
                        i = 0;
                        enemies.Clear();
                        foreach (GameObject enemy in enemiesLocation2)
                        {
                            newGo = Instantiate(enemy,
                                new Vector3(enemiesPosition[i].x + startRunningDelta, enemiesPosition[i].y,
                                    enemiesPosition[i].z), Quaternion.identity);
                            newGo.SetActive(false);
                            enemies.Add(newGo);
                            enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                            enemy.GetComponent<EnemyBehaviour>().position = enemiesPosition[i];

                            i++;
                            if (i >= enemiesLocation2.Count - 1)
                            {
                                i = 0;
                            }
                        }
                        break;

                    case 7:
                        //Энт
                        enemies.Clear();
                        newGo = Instantiate(enemiesBosses[0],
                            new Vector3(enemiesPosition[2].x + startRunningDelta, enemiesPosition[2].y,
                                enemiesPosition[2].z), Quaternion.identity);
                        newGo.SetActive(false);
                        enemies.Add(newGo);
                        newGo.GetComponent<EnemyBehaviour>().spawn_point_index = 2;
                        newGo.GetComponent<EnemyBehaviour>().position = enemiesPosition[2];
                        break;

                    case 8:
                        //Первый этаж могильника
                        i = 0;
                        enemies.Clear();
                        foreach (GameObject enemy in enemiesLocation3)
                        {
                            newGo = Instantiate(enemy,
                                new Vector3(enemiesPosition[i].x + startRunningDelta, enemiesPosition[i].y,
                                    enemiesPosition[i].z), Quaternion.identity);
                            newGo.SetActive(false);
                            enemies.Add(newGo);
                            enemy.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                            enemy.GetComponent<EnemyBehaviour>().position = enemiesPosition[1];

                            i++;
                            if (i >= enemiesLocation3.Count - 1)
                            {
                                i = 0;
                            }
                        }
                        break;

                    case 9:
                        //Лаборатории
                        i = 0;
                        enemies.Clear();
                        foreach (GameObject enemy in enemiesLocation4)
                        {
                            newGo = Instantiate(enemy,
                                new Vector3(enemiesPosition[i].x + startRunningDelta, enemiesPosition[i].y,
                                    enemiesPosition[i].z), Quaternion.identity);
                            newGo.SetActive(false);
                            enemies.Add(newGo);
                            enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                            enemy.GetComponent<EnemyBehaviour>().position = enemiesPosition[i];

                            i++;
                            if (i >= enemiesLocation4.Count - 1)
                            {
                                i = 0;
                            }
                        }
                        break;

                    case 10:
                        //Тронный зал
                        i = 0;
                        enemies.Clear();
                        foreach (GameObject enemy in enemiesLocation5)
                        {
                            newGo = Instantiate(enemy,
                                new Vector3(enemiesPosition[i].x + startRunningDelta, enemiesPosition[i].y,
                                    enemiesPosition[i].z), Quaternion.identity);
                            newGo.SetActive(false);
                            enemies.Add(newGo);
                            enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                            enemy.GetComponent<EnemyBehaviour>().position = enemiesPosition[i];

                            i++;
                            if (i >= enemiesLocation5.Count - 1)
                            {
                                i = 0;
                            }
                        }
                        break;

                    case 11:
                        //Некромант
                        enemies.Clear();
                        newGo = Instantiate(enemiesBosses[1],
                            new Vector3(enemiesPosition[1].x + startRunningDelta, enemiesPosition[1].y,
                                enemiesPosition[1].z), Quaternion.identity);
                        newGo.SetActive(false);
                        enemies.Add(newGo);
                        newGo.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                        newGo.GetComponent<EnemyBehaviour>().position = enemiesPosition[1];
                        break;

                    case 12:    //Туториал
                        newGo = Instantiate(firstEnemy,
                            new Vector3(enemiesPosition[1].x + startRunningDelta, enemiesPosition[1].y,
                                enemiesPosition[1].z), Quaternion.identity);
                        newGo.SetActive(false);
                        enemies.Add(newGo);
                        firstEnemy.GetComponent<EnemyBehaviour>().position = enemiesPosition[1];
                        firstEnemy.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                        break;

                    default:
                        Debug.LogError("LevelLoader.LoadDecorations(): cutscene is not recognised");
                        break;
                }
            }

            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyBehaviour>().attack_menu = this.attackMenu;
                enemy.GetComponent<EnemyBehaviour>().game_manager = this.gameManager;
            }

            attackMenu.enemies = this.enemies;

            return enemies.Count;
        }

        //Функция подгружает интерфейс игрока на уровне
        private void LoadUI()
        {
            stringSettings = new StringSettings(Language.LanguageToInt(languageSettings));

            pauseMenu.SetMenu(stringSettings);

            gameManager.attack_menu = attackMenu;
            gameManager.pause_menu = pauseMenu;
            gameManager.combometer = combometer;

            pauseMenu.DeactivateMenu();

        }

        //Настроить игровой менеджер
        private void GameManagerSettings()
        {
            gameManager.current_record = bestScore;   //Текущий рекорд игрока
            gameManager.black_ink = blackInk;      //Общее количество добытых чернил
            gameManager.pause_menu = this.pauseMenu;  //ссылка на меню паузы

            gameManager.UpdateEquipment(scoreForPointModifier, musicVolume);

            gameManager.StartManager();
        }


        //Настроить музыкальную дорожку и ритм менеджер
        private void RhytmGameSettings(int currentScene)
        {
            var beatTempo = 0;
            Sprite sprite;
            switch (currentScene)
            {
                case 0:
                    //Деревня
                    sprite = pointImages[0];
                    beatTempo = 150;
                    break;
                case 1:
                    //деревня
                    sprite = pointImages[0];
                    beatTempo = 120;
                    break;
                case 2:
                    //деревня
                    sprite = pointImages[0];
                    beatTempo = 120;
                    break;

                case 3:
                    //лес
                    sprite = pointImages[1];
                    beatTempo = 120;
                    break;

                case 4:
                    //воспоминания
                    sprite = pointImages[2];
                    beatTempo = 120;
                    break;

                case 5:
                    sprite = pointImages[1];
                    beatTempo = 120;
                    //лес
                    break;
                case 6:
                    //лес
                    sprite = pointImages[1];
                    beatTempo = 120;
                    break;

                case 7:
                    sprite = pointImages[3];
                    //энт
                    beatTempo = 158;
                    break;

                case 8:
                    //первый этаж подземелья
                    sprite = pointImages[4];
                    beatTempo = 110;
                    break;

                case 9:
                    sprite = pointImages[4];
                    //лаборатория
                    beatTempo = 120;
                    break;

                case 10:
                    //тронный зал
                    sprite = pointImages[4];
                    beatTempo = 120;
                    break;

                case 11:
                    //некромант
                    sprite = pointImages[5];
                    beatTempo = 135;
                    break;

                default:
                    sprite = pointImages[6];
                    Debug.LogError("LevelLoader.AudioClipSettings(): udefined cutscene!");
                    break;
            }

            PointBehaviour.beat_tempo = beatTempo;
            gameManager.audio_clip = audioClips[currentScene];
            pointSpawner.StartPointSpawner(beatTempo, audioClips[currentScene], rhythmManager, gameManager, sprite);
            pointSpawner.pointImage = sprite;
            rhythmManager.StartRhytmManager();
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
