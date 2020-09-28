//Класс отвечает за происходящие на уровне действия. Поддерживает функции SpawnPoint(), DeletePoint(), AddInk(int ink),
using UnityEngine;  //Подключить классы unity

public class GameManager : MonoBehaviour
{
    public static GameManager instance;         //Ссылка на этот игровой менеджер

    [Header("Rhytm Manager and Music Settings")]
    public RhythmManager rhythm_manager;        //Ссылка на ритм менеджер
    public float highest_screen_point = 4f;     //самая высокая точка экрана
    public float music_volume = 0.5f;           //громкость музыки
    public float point_acceleration = 1.0f;     //Ускорение точек
    public bool score_for_point_modificator = false;    //Модификатор очков за точку
    public int score = 0;                       //Текущие очки игрока
    public AudioSource audio_source;            //Источник звука
    public float audio_lenght;                  //длинна аудио дорожки
    public float musicDelay;
    public AudioClip audio_clip;                //музыкальная дорожка уровня

    [Header("UI")]
    public int combometer_size;                 //размер комбометра
    public int language_settings = 0;           //текщие языковые настройки
    public int black_ink = 0;                   //Черные чернила
    public int current_record;                  //текущий рекорд игрока
    public AttackMenu attack_menu;              //Меню атак
    public MenuManager pause_menu;               //Меню паузы
    public GameObject progress;                 //прогресс игрока на уровне
    public GameObject combometer;               //игровой объект комбометра
    public GameObject knight_healthbar;         //Шкала здоровья рыцаря
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
        if (rhythm_manager == null)
        {
            rhythm_manager = RhythmManager.instance;
        }

        if (attack_menu == null)
        {
            attack_menu = AttackMenu.instance;
        }

        if (pause_menu == null)
        {
            pause_menu = MenuManager.instance;
        }

        if (knight_healthbar != null)   //Если здороровье включено
        {
            healthbar = knight_healthbar.GetComponent<KnightHealth>();  //получить ссылку на скрипт здоровья
        }

        if (progress != null)   //если прогресс включен
        {
            progress_bar = progress.GetComponent<ProgressBar>();    //получить ссылку на скрипт слайдер прогресса
        }

        musicDelay = PointSpawner.musicDelay;
        audio_source = gameObject.GetComponent<AudioSource>(); //получить audioSource

        isLoaded = true;
        return isLoaded;
    }

    //Функция обновляет снаряжение
    public void UpdateEquipment(bool point_modifier, float volume)
    {
        score_for_point_modificator = point_modifier;
        audio_source.volume = volume;
    }

    //Функция вызывается в каждом кадре
    void Update()
    {
        if (progress_bar != null)
        {
            progress_bar.UpdateProgressBar(audio_source.time / audio_lenght * 100.0f);
        }
    }

    //Функция добавляет чернила
    public void AddInk(int ink)
    {
        black_ink += ink;
    }

    //Функция добавляет очки
    public bool AddScore(bool is_red)
    {
        attack_menu.AddToKnight(is_red);
        if(!score_for_point_modificator)
        {
            score += rhythm_manager.combo_count;
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
        attack_menu.UpdateImages();
        return true;
    }

    //Добавить очко врагу
    public void AddToEnemy()
    {
        attack_menu.AddToEnemyCombometer();
    }

    //Включить поражение
    public void Defeat()
    {
        pause_menu.ActivateDefeatScreen();
    }

    //Включить победу
    public void Victory()
    {
        pause_menu.ActivateVictoryScreen();
    }

    //Функция срабатывает при сворачивании / развороте приложения
    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            pause_menu.Pause();
        }
    }
}