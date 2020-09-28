//Скрипт LevelLoader загружает сцену уровня, в том числе рыцаря, врагов, декораций, меню и подменю, интерфейса

using System;
using System.Collections.Generic;   //Подключить списки
using UnityEngine;  //Подключить классы unity

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance; //Ссылка на этот загрузчик уровня
    [Header("Scene Links")]
    public GameManager game_manager;    //Ссылка на игровой менеджер
    public MenuManager pause_menu;           //Меню паузы на сцене
    public RhythmManager rhythm_manager;   //ссылка на менеждер ритм игры
    public PointSpawner pointSpawner;   //спавнер точек
    public AttackMenu attack_menu;  //Ссылка на меню атак
    private KnightBehaviour knight_behaviour;    //Ссылка на поведение рыцаря
    private List<GameObject> enemies;   //Список загруженных врагов

    [Header("Creature and points prefab")]
    public List<Sprite> point_images;
    public GameObject knight_prefab;            //Префаб рыцаря
    public List<GameObject> enemies_location_1; //Префабы врагов первой локации (деревня Унхаймберг) [0 - житель с серпом, 1 - житель с совками, 2 - житель с граблями, 3 - житель с лопатой]
    public List<GameObject> enemies_location_2; //Префабы врагов второй локации (Узловатый лес) [0 - заяц, 1 - боров, 2 - дриада, 3 - мантикора]
    public List<GameObject> enemies_location_3; //Префабы врагов третьей локации (Могильник - первый этаж) [0 - скелет с мечом, 1 - скелет с клевцом]
    public List<GameObject> enemies_location_4; //Префабы врагов третьей локации (Могильник - лаборатории) [0 - экаеримент 1, 1 - эксперимент 2]
    public List<GameObject> enemies_location_5; //Префабы врагов третьей локации (Могильник - силуэты) [0 - 12]
    public List<GameObject> enemies_memories;   //Префабы врагов воспомнаний Себастьяна
    public List<GameObject> enemies_bosses;     //Префабы боссов. [0 - Энт, 1 - Бральтаир]

    public DecorationsScript decorationsScript;

    [Header("Локации: Деревня")]
    public GameObject village_background;    //Префаб предустановленных декораций первой локации (деревня Унхаймберг)

    [Header("Локации: Лес")]
    public GameObject forest_background;    //Префаб предустановленных декораций второй локации (Узловатый лес)

    [Header("Локации: Могильник - темница")]
    public GameObject dungeon_background;    //Префаб предустановленных декораций третьей локации (Могильник - первый этаж)

    [Header("Локации: Могильник - лаборатории")]
    public GameObject labs_background;    //Префаб предустановленных декораций четвертой локации (Могильник - лаборатории)

    [Header("Локации: Могильник - тронный зал")]
    public GameObject throne_background;    //Префаб предустановленных декораций третьей локации (Могильник - тронный зал)

    [Header("Локации: Воспоминания - замок")]
    public GameObject castle_background;  //Префаб предустановленных декораций локации воспоминаний

    [Header("UI")]
    public GameObject combometer;           //Комбометр на сцене
    public GameObject knight_healthbar;     //Здоровье рыцаря на сцене
    public GameObject progress;             //Прогресс игрока на сцене
    public GameObject green_line;           //Зеленая линия
    public GameObject yellow_line;          //Желтая линия
    public GameObject red_line;             //Красная линия

    [Header("Positions")]
    public Vector3 decorations_pos;
    public Vector3 knight_position;         //Позиция  рыцаря на экране
    public List<Vector3> enemies_position;  //Позиция врагов на экране
    public Vector3 uni_menu_position;       //Позиция меню паузы
    public List<Vector3> point_spawn_point;     //Спавн точки для точек
    public Vector3 point_finish_point;          //Конечная точка для точек

    [Header("Score and ink")]   //очки и чернила
    public short best_score;    //Лучший результат
    public short black_ink;     //Количество чернил

    [Header("Settings")]        //Настройки игры
    public short language;      //Текущий язык
    public float master_volume; //Общая громкость игры
    public float music_volume;  //Громкость музыки
    public float sfx_volume;    //Громкость звуковых эффектов

    [Header("Equipment Settings")]  //Настройки снаряжения
    public int sword_damage_modificator = 0;        //Модификатор урона меча
    public int knight_health = 3;                   //Здоровье рыцаря
    public bool score_for_point_modifier = false;   //Модификатор для получнения очков за точки
    public int combometer_needed_points = 3;        //Количество точек, необходимых для заполнения одной ячейки комбометра
    public Figures figure = null;                   //Фигура для спецприема

    [Header("Music")]   //Музыка
    public List<AudioClip> audio_clips;                             //Список музыкальных дорожек уровней

    [Header("Settings")]    //Общие настройки
    public StringSettings string_settings;                          //Файл с языками
    public Language.LanguageType language_settings = Language.LanguageType.english;           //Выбор языка. 0 - английский, 1 - русский, 2 - немецкий, 3 - французский, 4 - эсперанто. В будущем написать класс для него и добавить в класс сохранений
    public float travel_time = 2.5f;                                //Время достижения точкой конца экрана
    public float start_running_delta = 3.0f;                        //разница между позицией врага и той, с которой он начинает дфижение
    public float endline = -2.7f;                                   //конец экрана
    public float startline = 2.7f;                                  //конец экрана

    //Функция срабатывает при включении сцены раньше Start
    void Start()
    {
        instance = this;

        enemies = new List<GameObject>();

        if(game_manager == null)
        {
            game_manager = GameManager.instance;
        }

        if(pause_menu == null)
        {
            pause_menu = MenuManager.instance;
        }

        if (attack_menu == null)
        {
            attack_menu = AttackMenu.instance;
        }

        if(rhythm_manager == null)
        {
            rhythm_manager = RhythmManager.instance;
        }

        if (pointSpawner == null)
        {
            pointSpawner = PointSpawner.instance;
        }

        master_volume = DataHolder.master_volume; 
        music_volume = DataHolder.music_volume;  
        sfx_volume = DataHolder.sfx_volume;   

        LoadDecorations(DataHolder.current_scene);              
        LoadCreatures(DataHolder.current_scene);    
        LoadUI();

        RhytmGameSettings(DataHolder.current_scene);                                        
        LoadEquipment(DataHolder.current_weapon, DataHolder.current_armor, DataHolder.current_charm_0, DataHolder.current_charm_1, DataHolder.current_charm_2); 
        GameManagerSettings();    
        
        attack_menu.enemies_position = this.enemies_position;
        attack_menu.start_running_delta = this.start_running_delta;
        attack_menu.StartAttackMenu(sword_damage_modificator, DataHolder.combometer_size, combometer_needed_points, DataHolder.current_weapon);   
        attack_menu.knight_combometer = knight_behaviour.SetKnightBehaviour(knight_health, DataHolder.current_weapon, DataHolder.combometer_size, figure); 
        
        pause_menu.game_is_paused = true;
        pause_menu.SetPosition();
    }

    //Функция подгружает декорации на уровне
    private void LoadDecorations(int current_scene)
    {
        switch (current_scene)
        {
            case 0:
            case 1:
            case 2:
                if (village_background != null)
                    decorationsScript = ((GameObject)Instantiate(village_background, decorations_pos, Quaternion.identity)).GetComponent<DecorationsScript>();
                break;

            case 3:
                goto case 5;

            case 4:
                if (castle_background != null)
                    decorationsScript = ((GameObject)Instantiate(castle_background, decorations_pos, Quaternion.identity)).GetComponent<DecorationsScript>();
                break;

            case 5:
            case 6:
            case 7:
                if (forest_background != null)
                    decorationsScript = ((GameObject)Instantiate(forest_background, decorations_pos, Quaternion.identity)).GetComponent<DecorationsScript>();
                break;

            case 8:
                if(dungeon_background != null)
                    decorationsScript = ((GameObject)Instantiate(dungeon_background, decorations_pos, Quaternion.identity)).GetComponent<DecorationsScript>();
                break;

            case 9:
                if (labs_background != null)
                    decorationsScript = ((GameObject)Instantiate(labs_background, decorations_pos, Quaternion.identity)).GetComponent<DecorationsScript>();
                break;

            case 10:
            case 11:
                if (throne_background != null)
                    decorationsScript = ((GameObject)Instantiate(throne_background, decorations_pos, Quaternion.identity)).GetComponent<DecorationsScript>();
                break;

            default:
                Debug.LogError("LevelLoader.LoadDecorations(): cutscene is not recognised");
                break;
        }
        decorationsScript.SetUpGraphics(Convert.ToBoolean((int)DataHolder.graphics_tier));
    }

    //Функция подгружает существ на уровень
    private int LoadCreatures(int current_scene)
    {
        knight_behaviour = Instantiate(knight_prefab, knight_position, Quaternion.Euler(0.0f, 180.0f, 0.0f)).GetComponent<KnightBehaviour>();

        GameObject newGo;
        int i;
        switch (current_scene)
        {
            case 0:
            case 1:
            case 2:
                //Деревня
                i = 0;
                enemies.Clear();
                foreach (GameObject enemy in enemies_location_1)
                {
                    newGo = Instantiate(enemy, new Vector3(enemies_position[i].x + start_running_delta, enemies_position[i].y, enemies_position[i].z), Quaternion.identity);
                    newGo.SetActive(false);
                    enemies.Add(newGo);
                    enemy.GetComponent<EnemyBehaviour>().position = enemies_position[i];
                    enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                    i++;
                    if (i >= enemies_position.Count)
                    {
                        i = 0;
                    }
                    Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + i);
                }
                break;

            case 3:
                //Лес, заяц и боров
                enemies.Clear();

                newGo = Instantiate(enemies_location_2[0], new Vector3(enemies_position[2].x + start_running_delta, enemies_position[2].y, enemies_position[2].z), Quaternion.identity);
                newGo.SetActive(false);
                enemies.Add(newGo);
                newGo.GetComponent<EnemyBehaviour>().spawn_point_index = 2;
                newGo.GetComponent<EnemyBehaviour>().position = enemies_position[2];
                Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + 2);

                newGo = (GameObject)Instantiate(enemies_location_2[1], new Vector3(enemies_position[1].x + start_running_delta, enemies_position[1].y, enemies_position[1].z), Quaternion.identity);
                newGo.SetActive(false);
                enemies.Add(newGo);
                newGo.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                newGo.GetComponent<EnemyBehaviour>().position = enemies_position[1];
                Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + 1);
                break;

            case 4:
                //Воспоминания
                enemies.Clear();
                i = 0;
                foreach (GameObject enemy in enemies_memories)
                {
                    newGo = Instantiate(enemy, new Vector3(enemies_position[i].x + start_running_delta, enemies_position[i].y, enemies_position[i].z), Quaternion.identity);
                    newGo.SetActive(false);
                    enemies.Add(newGo);
                    enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                    enemy.GetComponent<EnemyBehaviour>().position = enemies_position[i];

                    i++;
                    if (i >= enemies_memories.Count - 1)
                    {
                        i = 0;
                    }
                    Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + i);
                }
                break;

            case 5:
            case 6:
                //Лес, все враги
                i = 0;
                enemies.Clear();
                foreach (GameObject enemy in enemies_location_2)
                {
                    newGo = Instantiate(enemy, new Vector3(enemies_position[i].x + start_running_delta, enemies_position[i].y, enemies_position[i].z), Quaternion.identity);
                    newGo.SetActive(false);
                    enemies.Add(newGo);
                    enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                    enemy.GetComponent<EnemyBehaviour>().position = enemies_position[i];

                    i++;
                    if (i >= enemies_location_2.Count - 1)
                    {
                        i = 0;
                    }
                    Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + i);
                }
                break;

            case 7:
                //Энт
                enemies.Clear();
                newGo = Instantiate(enemies_bosses[0], new Vector3(enemies_position[1].x + start_running_delta, enemies_position[1].y, enemies_position[1].z), Quaternion.identity);
                newGo.SetActive(false);
                enemies.Add(newGo);
                newGo.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                newGo.GetComponent<EnemyBehaviour>().position = enemies_position[1];
                Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + 1);
                break;

            case 8:
                //Первый этаж могильника
                i = 0;
                enemies.Clear();
                foreach (GameObject enemy in enemies_location_3)
                {
                    newGo = Instantiate(enemy, new Vector3(enemies_position[i].x + start_running_delta, enemies_position[i].y, enemies_position[i].z), Quaternion.identity);
                    newGo.SetActive(false);
                    enemies.Add(newGo);
                    enemy.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                    enemy.GetComponent<EnemyBehaviour>().position = enemies_position[1];

                    i++;
                    if (i >= enemies_location_3.Count - 1)
                    {
                        i = 0;
                    }
                    Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + i);
                }
                break;

            case 9:
                //Лаборатории
                i = 0;
                enemies.Clear();
                foreach (GameObject enemy in enemies_location_4)
                {
                    newGo = Instantiate(enemy, new Vector3(enemies_position[i].x + start_running_delta, enemies_position[i].y, enemies_position[i].z), Quaternion.identity);
                    newGo.SetActive(false);
                    enemies.Add(newGo);
                    enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                    enemy.GetComponent<EnemyBehaviour>().position = enemies_position[i];

                    i++;
                    if (i >= enemies_location_4.Count - 1)
                    {
                        i = 0;
                    }
                    Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + i);
                }
                break;

            case 10:
                //Тронный зал
                i = 0;
                enemies.Clear();
                foreach (GameObject enemy in enemies_location_5)
                {
                    newGo = Instantiate(enemy, new Vector3(enemies_position[i].x + start_running_delta, enemies_position[i].y, enemies_position[i].z), Quaternion.identity);
                    newGo.SetActive(false);
                    enemies.Add(newGo);
                    enemy.GetComponent<EnemyBehaviour>().spawn_point_index = i;
                    enemy.GetComponent<EnemyBehaviour>().position = enemies_position[i];

                    i++;
                    if (i >= enemies_location_5.Count - 1)
                    {
                        i = 0;
                    }
                    Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + i);
                }
                break;

            case 11:
                //Некромант
                enemies.Clear();
                newGo = Instantiate(enemies_bosses[1], new Vector3(enemies_position[1].x + start_running_delta, enemies_position[1].y, enemies_position[1].z), Quaternion.identity);
                newGo.SetActive(false);
                enemies.Add(newGo);
                newGo.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                newGo.GetComponent<EnemyBehaviour>().position = enemies_position[1];
                Debug.Log("LevelLoader.LoadCreatures(): Loaded enemy at position " + 1);
                break;

            case 12:    //Туториал
                GameObject _enemy = enemies_location_1[0];
                newGo = Instantiate(_enemy, new Vector3(enemies_position[1].x + start_running_delta, enemies_position[1].y, enemies_position[1].z), Quaternion.identity);
                newGo.SetActive(false);
                enemies.Add(newGo);
                _enemy.GetComponent<EnemyBehaviour>().position = enemies_position[1];
                _enemy.GetComponent<EnemyBehaviour>().spawn_point_index = 1;
                break;

            default:
                Debug.LogError("LevelLoader.LoadDecorations(): cutscene is not recognised");
                break;
        }

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyBehaviour>().attack_menu = this.attack_menu;
            enemy.GetComponent<EnemyBehaviour>().game_manager = this.game_manager;
        }

        attack_menu.enemies = this.enemies;

        return enemies.Count;
    }

    //Функция подгружает интерфейс игрока на уровне
    private void LoadUI()
    {
        string_settings = new StringSettings(Language.LanguageToInt(language_settings));

        pause_menu.SetMenu(string_settings);

        game_manager.attack_menu = attack_menu;
        game_manager.pause_menu = pause_menu;
        game_manager.combometer = combometer;

        pause_menu.DeactivateMenu();

    }

    //Настроить игровой менеджер
    private void GameManagerSettings()
    {
        game_manager.current_record = best_score;   //Текущий рекорд игрока
        game_manager.black_ink = black_ink;      //Общее количество добытых чернил
        game_manager.pause_menu = this.pause_menu;  //ссылка на меню паузы

        game_manager.UpdateEquipment(score_for_point_modifier, music_volume);

        game_manager.StartManager();
    }


    //Настроить музыкальную дорожку и ритм менеджер
    private void RhytmGameSettings(int current_scene)
    {
        int beat_tempo = 0;
        Sprite _sprite;
        switch (current_scene)
        {
            case 0:
                //Деревня
                _sprite = point_images[0];
                beat_tempo = 150;
                break;
            case 1:
                //деревня
                _sprite = point_images[0];
                beat_tempo = 120;
                break;
            case 2:
                //деревня
                _sprite = point_images[0];
                beat_tempo = 120;
                break;

            case 3:
                //лес
                _sprite = point_images[1];
                beat_tempo = 120;
                break;

            case 4:
                //воспоминания
                _sprite = point_images[2];
                beat_tempo = 120;
                break;

            case 5:
                _sprite = point_images[1];
                beat_tempo = 120;
                //лес
                break;
            case 6:
                //лес
                _sprite = point_images[1];
                beat_tempo = 120;
                break;

            case 7:
                _sprite = point_images[3];
                //энт
                beat_tempo = 158;
                break;

            case 8:
                //первый этаж подземелья
                _sprite = point_images[4];
                beat_tempo = 110;
                break;

            case 9:
                _sprite = point_images[4];
                //лаборатория
                beat_tempo = 120;
                break;

            case 10:
                //тронный зал
                _sprite = point_images[4];
                beat_tempo = 120;
                break;

            case 11:
                //некромант
                _sprite = point_images[5];
                beat_tempo = 135;
                break;

            default:
                _sprite = point_images[6];
                Debug.LogError("LevelLoader.AudioClipSettings(): udefined cutscene!");
                break;
        }

        PointBehaviour.beat_tempo = beat_tempo;
        game_manager.audio_clip = audio_clips[current_scene];
        pointSpawner.StartPointSpawner(beat_tempo, audio_clips[current_scene], rhythm_manager, game_manager, _sprite);
        pointSpawner.pointImage = _sprite;
        pointSpawner.endLine = this.endline;
        rhythm_manager.StartRhytmManager();
    }

    //Функция загружает настройки, согласно снаряжению рыцаря
    private void LoadEquipment(int current_weapon, int current_armor, int current_charm_0, int current_charm_1, int current_charm_2)
    {
        //current_equipment index = 0 - оружие, = 1 - броня, = 2 - талисман 1, = 3 - талисман 2, = 4 - талисман 3

        //оружие
        switch (current_weapon)
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
        knight_health += current_armor;

        //талисманы
        switch (current_charm_0)
        {
            case 1:
                sword_damage_modificator += 1; //Талисман благоденствия
                break;

            case 2:
                combometer_needed_points = 6; //Таллисман еретика
                knight_health += 1;
                break;

            case 3:
                knight_health += 1;    //Талисман ордена
                break;

            case 4:
                combometer_needed_points = 1;    //Нагрудный крест
                score_for_point_modifier = true;
                break;

            case 5:
                game_manager.progress = this.progress; //Навершие из слоновой кости
                progress.SetActive(true);
                break;

            case 6:
                knight_healthbar.SetActive(true);    //Печать папы
                break;

            case 7:
                music_volume = 1.0f;  //Подвеска предателя
                break;

            default:
                Debug.Log("LevelLoader.LoadEquipment(): undefined Charm");
                break;
        }

        switch (current_charm_1)
        {
            case 1:
                sword_damage_modificator += 1; //Талисман благоденствия
                break;

            case 2:
                combometer_needed_points = 6; //Таллисман еретика
                knight_health += 1;
                break;

            case 3:
                knight_health += 1;    //Талисман ордена
                break;

            case 4:
                combometer_needed_points = 1;    //Нагрудный крест
                score_for_point_modifier = true;
                break;

            case 5:
                game_manager.progress = this.progress; //Навершие из слоновой кости
                progress.SetActive(true);
                break;

            case 6:
                knight_healthbar.SetActive(true);    //Печать папы
                break;

            case 7:
                music_volume = 1.0f;  //Подвеска предателя
                break;

            default:
                Debug.Log("LevelLoader.LoadEquipment(): undefined Charm");
                break;
        }

        switch (current_charm_2)
        {
            case 1:
                sword_damage_modificator += 1; //Талисман благоденствия
                break;

            case 2:
                combometer_needed_points = 6; //Таллисман еретика
                knight_health += 1;
                break;

            case 3:
                knight_health += 1;    //Талисман ордена
                break;

            case 4:
                combometer_needed_points = 1;    //Нагрудный крест
                score_for_point_modifier = true;
                break;

            case 5:
                game_manager.progress = this.progress; //Навершие из слоновой кости
                progress.SetActive(true);
                break;

            case 6:
                knight_healthbar.SetActive(true);    //Печать папы
                break;

            case 7:
                music_volume = 1.0f;  //Подвеска предателя
                break;

            default:
                Debug.Log("LevelLoader.LoadEquipment(): undefined Charm");
                break;
        }
        knight_behaviour.default_health = knight_health;


        if ((current_charm_0 == 4 || current_charm_1 == 4 || current_charm_2 == 4) && (current_charm_0 == 2 || current_charm_1 == 2 || current_charm_2 == 2))
        {
            combometer_needed_points = 1;
        }

    }
}
